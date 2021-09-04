# Trip

# Identity
dotnet ef migrations add InitialCreate -c PersistedGrantDbContext

dotnet ef migrations add InitialCreate -c ConfigurationDbContext

dotnet ef migrations add InitialCreate -c ApplicationDbContext

Update Database

dotnet ef database update -c  PersistedGrantDbContext
dotnet ef database update -c  ConfigurationDbContext
dotnet ef database update -c  ApplicationDbContext

/seed

# Profile Service
dotnet ef migrations add InitialCreate -c ProfileWriterDbContext

dotnet ef migrations add InitialCreate -c ProfileReaderDbContext

-Update Database
dotnet ef database update -c ProfileReaderDbContext
