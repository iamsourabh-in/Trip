# Trip

#Identity
dotnet ef migrations add InitialCreate -c ApplicationDbContext


#Profile Service
dotnet ef migrations add InitialCreate -c ProfileWriterDbContext

dotnet ef migrations add InitialCreate -c ProfileReaderDbContext

-Update Database
dotnet ef database update -c ProfileReaderDbContext
