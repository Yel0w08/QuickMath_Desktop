# QuickMath Architecture

## Goal

QuickMath is a **mono-user Windows Forms desktop app** that stores all data in a local SQL database.

The project follows a simple layered architecture:

1. `UI` (`WinForms`)
2. `Services`
3. `Repositories / DAL`
4. `SQL schema`

## Project structure

### UI

- `QuickMath/Form1.cs`
- `QuickMath/Register.cs`
- `QuickMath/Shop.cs`
- `QuickMath/Statistics.cs`

Responsibilities:

- display data
- collect user input
- call services
- never execute SQL directly
- never own business rules that should be reusable

### Domain

- `QuickMath/Domain/*`

Responsibilities:

- lightweight models exchanged between services, repositories and forms
- enums and read/write DTO-style records for gameplay, shop and stats

### Services

- `QuickMath/Services/*`

Responsibilities:

- orchestrate use cases
- keep business logic out of WinForms
- refresh the in-memory user session after SQL-backed operations

Main services:

- `UserService`
- `MathEngineService`
- `ShopService`
- `ScoreService`

### DAL / Repositories

- `QuickMath/Infrastructure/Repositories/*`
- `QuickMath/Infrastructure/Data/*`

Responsibilities:

- own all SQL access
- open connections
- execute parameterized queries
- manage transactions on write operations
- map SQL rows to domain models

Main repositories:

- `UserRepository`
- `ExerciseRepository`
- `ShopRepository`
- `ScoreRepository`

## Runtime flow

### Startup

1. `Program.cs` creates the service graph.
2. `DatabaseInitializer` ensures the local LocalDB database exists.
3. The SQL schema is applied through `SqlScripts`.
4. Registration is shown only if no local user exists yet.
5. The active user is loaded into `UserSession`.

### Exercise flow

1. The main form asks `MathEngineService` for a new exercise.
2. `ExerciseRepository` loads the difficulty definition and unlock state from SQL.
3. The user answers in the form.
4. `MathEngineService.SubmitAnswer` stores the attempt through `ExerciseRepository`.
5. SQL updates:
   - exercise history
   - XP
   - coins
   - coin ledger

### Shop flow

1. The shop form loads a category through `ShopService`.
2. `ShopRepository` returns the visible catalog for the current user.
3. The form builds a temporary UI cart.
4. `ShopService.Purchase` validates and commits the transaction in SQL.
5. Inventory and coin ledger are updated atomically.

### Statistics flow

1. The statistics form asks `ScoreService` for one aggregate snapshot.
2. `ScoreRepository` returns all required counters in one query.

## Persistence rules

QuickMath must not use:

- JSON persistence
- XML persistence
- SQLite persistence
- in-memory persistent collections
- SQL in WinForms

All business data must go through SQL Server LocalDB.

## Why LocalDB

LocalDB keeps the SQL Server programming model while staying local:

- no remote server
- no shared infra
- per-user local files
- good fit for a mono-user Windows desktop app

## Extension points

To add a new math operation:

1. add enum/domain support if needed
2. seed the operation and difficulty rows in SQL
3. extend `MathEngineService`
4. extend UI selection labels
5. extend statistics if the operation needs dedicated counters
