# Trip

##### A microservices based approach for a scalable architecture.(_This project is a skeleton for experimental purpose._)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

This is full stack solution using .Net Technologies.

>A user can upload a photo, video the video and photos thumbnails would be generated and the user can later browser his photos and can share them with friends.
>

# Gateway

Soon...


# Backend
The backend is built using .net5 

We are trying to sperate individual domain in the complete work flow and 

- **Identity Service (Identity Server 4)**  - This service is built using Identity server 4 and have uses SQLite for the Database and is built using a code first approach.
- **Profile Service**   This service is built using Identity server 4 and have uses SQLite for the Database and is built using a code first approach.
- **Creator Service**   This service is built using Identity server 4 and have uses SQLite for the Database and is built using a code first approach.
- **Feeder Service**  This service is built using Identity server 4 and have uses SQLite for the Database and is built using a code first approach.


|                |HTTP              |HTTPS    |
|----------------|------------------|---------|
|Identity Service|`5000`            |`5443`   |
|Profile Service |`6000`            |`6443`   |
|Creator Service |`7000`            |`7443`   |
|Feeder Service  |`8000`            |`8443`   |


# Frontend
- **Tripper.UI** - 1000,1443(s)

# Key Features

- The services use a Clean Architecture approach using CQRS
- We have used Serrilog for Logging andcan be visible in Serrilog Dashboad.
- The Identity Service has an in build simple Admin Panel to view and edit roles/users.
- The Service exposes an health check endpoint with system resources info.
- The Service also expose metrics for Promethues
- Can be Integrated With Grafana.
- The Service communicates to each other via MSMQ -> RabbitMQ

# Initial Setup

# Services

### Identity Service

#### Create Migrations 
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


## Creator Service
```sh
dotnet ef migrations add InitialCreate -c CreatorWriterDbContext
dotnet ef migrations add InitialCreate -c CreatorReaderDbContext
```

Update Database
```sh
dotnet ef database update -c CreatorReaderDbContext
```

## Identity Auth Flow


```mermaid
sequenceDiagram
TripperUI ->> Identity Service: .well-know endpoint 
Identity Service -->>TripperUI: Auth code Flow
TripperUI ->> Identity Service: Redirects  
Identity Service ->>TripperUI: User Login Success
TripperUI ->> Profile Service: Get Profile details
TripperUI ->> Creator Service: Add Creation
TripperUI ->> Feed Service: Get Memories 
```

And this will produce a flow chart:

```mermaid
graph LR
A[Square Rect] -- Link text --> B((Circle))
A --> C(Round Rect)
B --> D{Rhombus}
C --> D
```