# QuickMath SQL Server Migration Audit

## Legacy persistence found

- `QuickMath/DatabaseManager.cs`
  - Local SQLite database under `%AppData%\\QuickMath\\QuickMath.db`.
- `QuickMath/LiveAppData.cs`
  - Process-wide mutable state acting as a local persistence proxy.
- `QuickMath/UserData.cs`
  - Aggregated persistence model mixing profile, unlocks, economy and stats.
- `QuickMath/Register.cs`
  - Direct JSON writes to `QuickMath_UserData.json` and `QuickMath_UserStats.json`.
- `QuickMath/Shop.cs`
  - Direct JSON reads and writes for economy, unlocks and stars.
- `QuickMath/Statistics.cs`
  - Direct JSON reads for player and stats data.
- `QuickMath/Form1.cs`
  - Business rules and progression logic embedded in the WinForms layer.
- `QuickMath/bin/*`
  - Residual generated local artifacts: `QuickMath.db`, `QuickMath_UserData.json`, `QuickMath_UserStats.json`.

## Migration target

- SQL Server is the only source of truth for:
  - users
  - exercise attempts
  - rewards
  - coins ledger
  - inventory and unlocks
  - shop catalog metadata
- WinForms now calls only services.
- Services call repositories.
- Repositories encapsulate all SQL.
