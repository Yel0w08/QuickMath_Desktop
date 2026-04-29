# QuickMath Local Runtime

## Overview

QuickMath is designed to run:

- locally
- on one Windows machine
- for one active user session at a time
- without any remote server

## Database engine

The app uses:

- `.NET 10`
- `Windows Forms`
- `SQL Server LocalDB`
- `Dapper`

Database files are created under:

- `%LocalAppData%\QuickMath\QuickMath_Local.mdf`
- `%LocalAppData%\QuickMath\QuickMath_Local_log.ldf`

## Requirements

The machine must have:

1. Windows
2. .NET Desktop runtime / SDK compatible with the build
3. SQL Server LocalDB installed

## First run behavior

On first launch:

1. the application creates the local application data directory
2. it creates the LocalDB database if missing
3. it applies the schema and seed data
4. it asks for a username if no user exists yet

## Data ownership

All business data is local to the current Windows user profile:

- player profile
- XP
- coins
- exercise history
- shop purchases
- inventory
- statistics

## Troubleshooting

### Error: local SQL database cannot start

Cause:

- SQL Server LocalDB is not installed

Action:

- install SQL Server Express LocalDB on the machine

### Error: no active user found

Cause:

- registration was canceled before a user profile was created

Action:

- relaunch the app and complete registration

### Need to reset local data

Delete the local files:

- `%LocalAppData%\QuickMath\QuickMath_Local.mdf`
- `%LocalAppData%\QuickMath\QuickMath_Local_log.ldf`

Then relaunch the app.
