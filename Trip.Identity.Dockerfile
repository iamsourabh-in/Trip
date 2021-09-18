#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["IdentityServer/Trip.Identity/Trip.Identity.csproj", "IdentityServer/Trip.Identity/"]
COPY ["IdentityServer/Core/Trip.Identity.Application/Trip.Identity.Application.csproj", "IdentityServer/Core/Trip.Identity.Application/"]
COPY ["IdentityServer/Infrastructure/Trip.Identity.Persistence/Trip.Identity.Persistence.csproj", "IdentityServer/Infrastructure/Trip.Identity.Persistence/"]
COPY ["Common/Trip.Infrastructure.Common/Trip.Infrastructure.Common.csproj", "Common/Trip.Infrastructure.Common/"]
COPY ["Common/Trip.Application.Common/Trip.Application.Common.csproj", "Common/Trip.Application.Common/"]
COPY ["Common/Trip.Domain.Common/Trip.Domain.Common.csproj", "Common/Trip.Domain.Common/"]
COPY ["IdentityServer/Infrastructure/Trip.Identity.Messaging/Trip.Identity.Messaging.csproj", "IdentityServer/Infrastructure/Trip.Identity.Messaging/"]

RUN dotnet restore "IdentityServer/Trip.Identity/Trip.Identity.csproj"
COPY . .
WORKDIR "/src/IdentityServer/Trip.Identity"


FROM build AS publish
RUN dotnet publish "Trip.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trip.Identity.dll"]