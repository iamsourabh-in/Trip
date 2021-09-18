#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CreatorService/Trip.Creator.Api/Trip.Creator.Api.csproj", "CreatorService/Trip.Creator.Api/"]
COPY ["CreatorService/Infrastructure/Trip.Creator.Messaging/Trip.Creator.Messaging.csproj", "CreatorService/Infrastructure/Trip.Creator.Messaging/"]
COPY ["Common/Trip.Infrastructure.Common/Trip.Infrastructure.Common.csproj", "Common/Trip.Infrastructure.Common/"]
COPY ["Common/Trip.Application.Common/Trip.Application.Common.csproj", "Common/Trip.Application.Common/"]
COPY ["Common/Trip.Domain.Common/Trip.Domain.Common.csproj", "Common/Trip.Domain.Common/"]
COPY ["CreatorService/Core/Trip.Creator.Application/Trip.Creator.Application.csproj", "CreatorService/Core/Trip.Creator.Application/"]
COPY ["ProfileService/Core/Trip.Profile.Application/Trip.Profile.Application.csproj", "ProfileService/Core/Trip.Profile.Application/"]
COPY ["ProfileService/Core/Trip.Profile.Domain/Trip.Profile.Domain.csproj", "ProfileService/Core/Trip.Profile.Domain/"]
COPY ["CreatorService/Core/Trip.Creator.Domain/Trip.Creator.Domain.csproj", "CreatorService/Core/Trip.Creator.Domain/"]
COPY ["Common/Trip.Api.Common/Trip.Api.Common.csproj", "Common/Trip.Api.Common/"]
COPY ["CreatorService/Infrastructure/Trip.Creator.Persistence/Trip.Creator.Persistence.csproj", "CreatorService/Infrastructure/Trip.Creator.Persistence/"]
RUN dotnet restore "CreatorService/Trip.Creator.Api/Trip.Creator.Api.csproj"
COPY . .
WORKDIR "/src/CreatorService/Trip.Creator.Api"

FROM build AS publish
RUN dotnet publish "Trip.Creator.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trip.Creator.Api.dll"]