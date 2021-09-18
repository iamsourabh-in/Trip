#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProfileService/Trip.Profile.Api/Trip.Profile.Api.csproj", "ProfileService/Trip.Profile.Api/"]
COPY ["Common/Trip.Api.Common/Trip.Api.Common.csproj", "Common/Trip.Api.Common/"]
COPY ["ProfileService/Core/Trip.Profile.Application/Trip.Profile.Application.csproj", "ProfileService/Core/Trip.Profile.Application/"]
COPY ["Common/Trip.Application.Common/Trip.Application.Common.csproj", "Common/Trip.Application.Common/"]
COPY ["Common/Trip.Domain.Common/Trip.Domain.Common.csproj", "Common/Trip.Domain.Common/"]
COPY ["ProfileService/Core/Trip.Profile.Domain/Trip.Profile.Domain.csproj", "ProfileService/Core/Trip.Profile.Domain/"]
COPY ["ProfileService/Infrastructure/Trip.Profile.Messaging/Trip.Profile.Messaging.csproj", "ProfileService/Infrastructure/Trip.Profile.Messaging/"]
COPY ["Common/Trip.Infrastructure.Common/Trip.Infrastructure.Common.csproj", "Common/Trip.Infrastructure.Common/"]
COPY ["ProfileService/Infrastructure/Trip.Profile.Persistance/Trip.Profile.Persistance.csproj", "ProfileService/Infrastructure/Trip.Profile.Persistance/"]
RUN dotnet restore "ProfileService/Trip.Profile.Api/Trip.Profile.Api.csproj"
COPY . .
WORKDIR "/src/ProfileService/Trip.Profile.Api"

FROM build AS publish
RUN dotnet publish "Trip.Profile.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trip.Profile.Api.dll"]