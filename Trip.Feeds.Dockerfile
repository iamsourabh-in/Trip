#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FeedsServer/Trip.Feeds.Api/Trip.Feeds.Api.csproj", "FeedsServer/Trip.Feeds.Api/"]
COPY ["FeedsServer/Infrastructure/Trip.Feeds.Persistence/Trip.Feeds.Persistence.csproj", "FeedsServer/Infrastructure/Trip.Feeds.Persistence/"]
COPY ["FeedsServer/Core/Trip.Feeds.Application/Trip.Feeds.Application.csproj", "FeedsServer/Core/Trip.Feeds.Application/"]
COPY ["Common/Trip.Application.Common/Trip.Application.Common.csproj", "Common/Trip.Application.Common/"]
COPY ["Common/Trip.Domain.Common/Trip.Domain.Common.csproj", "Common/Trip.Domain.Common/"]
COPY ["FeedsServer/Core/Trip.Feeds.Domain/Trip.Feeds.Domain.csproj", "FeedsServer/Core/Trip.Feeds.Domain/"]
COPY ["FeedsServer/Infrastructure/Trip.Feeds.Messaging/Trip.Feeds.Messaging.csproj", "FeedsServer/Infrastructure/Trip.Feeds.Messaging/"]
COPY ["Common/Trip.Infrastructure.Common/Trip.Infrastructure.Common.csproj", "Common/Trip.Infrastructure.Common/"]
RUN dotnet restore "FeedsServer/Trip.Feeds.Api/Trip.Feeds.Api.csproj"
COPY . .
WORKDIR "/src/FeedsServer/Trip.Feeds.Api"

FROM build AS publish
RUN dotnet publish "Trip.Feeds.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trip.Feeds.Api.dll"]