# Equipment Management API

Small ASP.NET Core Web API for managing equipment records using PostgreSQL and Entity Framework Core.

## Technologies
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core 10 (Npgsql provider)
- PostgreSQL

## Prerequisites
- .NET 10 SDK installed
- PostgreSQL server running and accessible
- (Optional) `dotnet-ef` global tool for CLI migrations: `dotnet tool install --global dotnet-ef`

## Configuration
- Connection string is read from `appsettings.json` using the key `DefaultConnection`.
- Example (already in repo):

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=EquipmentDB;Username=YourUsername;Password=Yourpasword"
}
```

- If you use an environment-specific settings file such as `appsettings.Development.json`, ensure it contains the `DefaultConnection` key or is not overriding it with an empty value.

## Design-time DbContext
The project includes `Infrastructure/DesignTimeDbContextFactory.cs` so EF tools can instantiate the `EfDbContext` during design-time operations (migrations / update-database).

## Migrations and Database
Using Package Manager Console (Visual Studio):
- Set the **Default project** dropdown to `Equipment Management` (the project with the migrations).
- Run: `Update-Database`

Using CLI (from solution or project folder):
- Ensure `dotnet-ef` is installed.
- Create migration: `dotnet ef migrations add InitialCreate --project "Equipment Management" --startup-project "Equipment Management"`
- Apply migration: `dotnet ef database update --project "Equipment Management" --startup-project "Equipment Management"`

If EF tools cannot find the connection string or DbContext, confirm the `DefaultConnection` key exists in the `appsettings.json` file located in the project directory.

## Run the API
From the project directory:

```bash
dotnet run --project "Equipment Management"
```

Open Swagger (if running in Development) at `https://localhost:{port}/swagger` or use the API endpoints described below.

## API Endpoints
- `GET /api/v1/equipment` - Get all equipment
- `GET /api/v1/equipment/{id}` - Get equipment by id
- `POST /api/v1/equipment` - Add equipment
- `PUT /api/v1/equipment/{id}` - Update equipment
- `DELETE /api/v1/equipment/{id}` - Delete equipment

Example curl to get all:

```bash
curl https://localhost:5001/api/equipment
```

## Project Structure (important files)
- `Program.cs` - app startup and DbContext registration
- `Infrastructure/EfCoreDbContext.cs` - EF Core DbContext
- `Infrastructure/DesignTimeDbContextFactory.cs` - EF design-time factory
- `Infrastructure/Repository.cs` - repository implementation
- `Domain/Equipment.cs` - domain model
- `Migrations/` - EF migration files

## Troubleshooting
- "ConnectionString property has not been initialized" — means EF couldn't find a connection string. Check `DefaultConnection` key and that the migration tools run from the project folder or the design-time factory can locate `appsettings.json`.
- If `dotnet ef` is not found, install the global tool: `dotnet tool install --global dotnet-ef`.

## Contributing
Feel free to open issues or submit pull requests.

## License
MIT
