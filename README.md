# Trip

##### A microservices based approach for a scalable architecture.(_This project is a skeleton for experimental purpose._)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)
 

The  services are segregated as
- Identity Service (Identity Server 4) - 5000,5443
- Profile Service - 6000,6443
- Creator Service - 7000,7443
- Feeder Service - 8000,8443

- Tripper.UI - 1000,1443

Additionally, 
- The services use a Clean Architecture approach using CQRS
- Serrilog Loging.
- Serrilog Dashboad.
- The Identity Service has an in build simple Admin Panel.
- The Service exposes an healthcheck endpoint.
- The servies also expose metrics for Promethues
- Can be Integrated With Grafana.
- The Service communicates to each other via MSMQ -> RabbitMQ

# Services

## Identity
```sh
dotnet ef migrations add InitialCreate -c PersistedGrantDbContext
dotnet ef migrations add InitialCreate -c ConfigurationDbContext
dotnet ef migrations add InitialCreate -c ApplicationDbContext
```

Update Database
```sh
dotnet ef database update -c  PersistedGrantDbContext
dotnet ef database update -c  ConfigurationDbContext
dotnet ef database update -c  ApplicationDbContext
```

```sh
dotnet run /seed
```

## Profile Service
```sh
dotnet ef migrations add InitialCreate -c ProfileWriterDbContext
dotnet ef migrations add InitialCreate -c ProfileReaderDbContext
```

-Update Database
```sh
dotnet ef database update -c ProfileReaderDbContext
```
