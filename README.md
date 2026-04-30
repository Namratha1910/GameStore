# GameStore API

A RESTful API for managing video games and genres, built with ASP.NET Core and Entity Framework Core.

## Tech Stack

- **Framework:** ASP.NET Core 10
- **Database:** SQLite with Entity Framework Core
- **Language:** C#
- **Architecture:** Minimal APIs with Repository Pattern

## Features

- Create, Read, Update, Delete (CRUD) operations for games
- Genre management
- Database seeding with sample data
- Async/await for all database operations
- RESTful endpoint design
- Entity relationships (Games ↔ Genres)

## Prerequisites

- .NET 10 SDK or later
- SQLite (included with EF Core)

## Installation & Setup

1. **Clone or navigate to the project:**
   ```bash
   cd GameStore
   ```

2. **Restore dependencies:**
   ```bash
   dotnet restore
   ```

3. **Apply database migrations:**
   ```bash
   cd GameStore.Api
   dotnet ef database update
   ```

   *This creates the SQLite database and seeds sample genres.*

4. **Run the API:**
   ```bash
   dotnet run
   ```

   The API will start on `http://localhost:5074`

## API Endpoints

### Games

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/games` | Get all games with genres |
| GET | `/games/{id}` | Get a specific game by ID |
| POST | `/games` | Create a new game |
| PUT | `/games/{id}` | Update an existing game |
| DELETE | `/games/{id}` | Delete a game |

### Request/Response Examples

**GET /games**
```json
[
  {
    "id": 1,
    "name": "Street Fighter II",
    "genre": "Action",
    "price": 19.99,
    "releaseDate": "2024-10-19"
  }
]
```

**POST /games**
```json
{
  "name": "Super Mario",
  "genreId": 3,
  "price": 69.99,
  "releaseDate": "2023-02-20"
}
```

**PUT /games/{id}**
```json
{
  "name": "Street Fighter II Turbo",
  "genreId": 1,
  "price": 21.99,
  "releaseDate": "2024-10-19"
}
```

## Project Structure

```
GameStore/
├── GameStore.Api/
│   ├── Data/
│   │   ├── DataExtensions.cs       # DB configuration & migration runner
│   │   ├── GameStoreContext.cs     # EF Core DbContext
│   │   └── Migrations/             # Database migrations
│   ├── Models/
│   │   ├── Game.cs                 # Game entity
│   │   └── Genre.cs                # Genre entity
│   ├── Dtos/
│   │   ├── GameDto.cs              # Game display DTO
│   │   ├── GameDetailsDto.cs       # Full game details DTO
│   │   ├── GameSummaryDto.cs       # Game summary DTO
│   │   ├── CreateGameDto.cs        # Request DTO for creation
│   │   └── UpdateGameDto.cs        # Request DTO for updates
│   ├── Endpoints/
│   │   ├── GamesEndpoints.cs       # Game endpoint mappings
│   │   └── GenresEndpoints.cs      # Genre endpoint mappings (optional)
│   ├── Program.cs                  # Application entry point
│   ├── appsettings.json            # Configuration
│   └── games.http                  # REST Client test file
```

## Database Seeding

The database is automatically seeded with 5 genres on first run:
- Fighting
- RPG
- Platformer
- Racing
- Sports

## Configuration

All database and connection settings are configured in:
- `appsettings.json` - Connection string and logging
- `Program.cs` - EF Core setup and migrations

**Connection String:**
```
Data Source=GameStore.db
```

## Testing Endpoints

Use the included `games.http` file with VS Code REST Client extension, or use tools like:
- Postman
- Thunder Client
- cURL

Example with cURL:
```bash
curl http://localhost:5074/games
```

## Development

### Create a New Migration

After modifying entity models, create a migration:
```bash
dotnet ef migrations add MigrationName
```

Then apply it:
```bash
dotnet ef database update
```

## Notes

- Database file (`GameStore.db`) is gitignored and regenerated on first run
- All database operations are asynchronous
- Uses EF Core's Include() for eager loading related entities
- Bulk delete operations for performance optimization
