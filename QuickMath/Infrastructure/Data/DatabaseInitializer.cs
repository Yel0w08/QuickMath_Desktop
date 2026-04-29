using Dapper;
using Microsoft.Data.SqlClient;

namespace QuickMath.Infrastructure.Data;

/// <summary>
/// Ensures that the local SQL Server database and schema exist before the UI starts.
/// </summary>
public sealed class DatabaseInitializer
{
    private readonly SqlConnectionFactory _connectionFactory;

    public DatabaseInitializer(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    /// <summary>
    /// Creates the local database if needed, then applies the schema and seed script.
    /// </summary>
    public void Initialize()
    {
        try
        {
            Directory.CreateDirectory(_connectionFactory.ApplicationDataDirectory);
            EnsureDatabaseExists();

            using var connection = _connectionFactory.Create();
            connection.Open();
            connection.Execute(SqlScripts.InitialSchema);
        }
        catch (SqlException exception)
        {
            throw new InvalidOperationException(
                "QuickMath could not start its local SQL Server database. Install SQL Server LocalDB on this PC to run the app in 100% local mode.",
                exception);
        }
    }

    private void EnsureDatabaseExists()
    {
        using var masterConnection = _connectionFactory.CreateMasterConnection();
        masterConnection.Open();

        // We create the catalog once, then reuse it as the single source of truth
        // for every future run of the desktop app.
        var databaseExists = masterConnection.ExecuteScalar<int>(
            "SELECT COUNT(1) FROM sys.databases WHERE name = @DatabaseName;",
            new { DatabaseName = "QuickMath_Local" }) > 0;

        if (databaseExists)
        {
            return;
        }

        var sql = $"""
        CREATE DATABASE [QuickMath_Local]
        ON PRIMARY
        (
            NAME = N'QuickMath_Local',
            FILENAME = N'{_connectionFactory.DatabaseFilePath.Replace("'", "''")}'
        )
        LOG ON
        (
            NAME = N'QuickMath_Local_log',
            FILENAME = N'{_connectionFactory.DatabaseLogFilePath.Replace("'", "''")}'
        );
        """;

        masterConnection.Execute(sql);
    }
}
