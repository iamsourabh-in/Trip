#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0
EXPOSE 80
EXPOSE 443
COPY bin/Debug/net5.0 App/
WORKDIR /App
ENTRYPOINT ["dotnet", "Trip.Feeds.Api.dll"]