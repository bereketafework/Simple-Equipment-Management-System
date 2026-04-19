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
  "DefaultConnection": "Host=localhost;Port=5432;Database=EquipmentDB;Username=yourusername;Password=yourpassword"
}
```

Replace `yourusername` and `yourpassword` with your actual PostgreSQL credentials before running the application or applying migrations.

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

Base URL (development): `https://localhost:{port}/api/equipment`

1) Get all equipment
 - Method: `GET`
 - URL: `/api/equipment`
 - Success: `200 OK`
 - Response: JSON array of equipment objects

Example curl:

```bash
curl -k https://localhost:5001/api/equipment
```

2) Get equipment by id
 - Method: `GET`
 - URL: `/api/equipment/{id}`
 - Success: `200 OK` (returns equipment)
 - Not found: `404 Not Found`

Example curl:

```bash
curl -k https://localhost:5001/api/equipment/00000000-0000-0000-0000-000000000000
```

3) Create equipment
 - Method: `POST`
 - URL: `/api/equipment`
 - Content-Type: `application/json`
 - Request body (use `CreateEquipmentDto`):

```json
{
  "name": "Laptop",
  "status": "Active",
  "serialNumber": "SN-12345",
  "purchaseDate": "2025-01-15T00:00:00"
}
```

 - Success: returns created equipment (usually `201 Created` or `200 OK`) with the saved object

Example curl:

```bash
curl -k -X POST https://localhost:5001/api/equipment \
  -H "Content-Type: application/json" \
  -d '{"name":"Laptop","status":"Active","serialNumber":"SN-12345","purchaseDate":"2025-01-15T00:00:00"}'
```

4) Update equipment
 - Method: `PUT`
 - URL: `/api/equipment/{id}`
 - Content-Type: `application/json`
 - Request body: full equipment object (same shape as domain `Equipment`)
 - Success: `200 OK` with updated equipment
 - Not found: `404 Not Found`

Example curl:

```bash
curl -k -X PUT https://localhost:5001/api/equipment/00000000-0000-0000-0000-000000000000 \
  -H "Content-Type: application/json" \
  -d '{"id":"00000000-0000-0000-0000-000000000000","name":"Updated","status":"Maintenance","serialNumber":"SN-12345","purchaseDate":"2025-01-15T00:00:00"}'
```

5) Delete equipment
 - Method: `DELETE`
 - URL: `/api/equipment/{id}`
 - Success: `200 OK` (or `204 No Content` in some implementations)
 - Not found: `404 Not Found`

Example curl:

```bash
curl -k -X DELETE https://localhost:5001/api/equipment/00000000-0000-0000-0000-000000000000
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
