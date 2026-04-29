using Microsoft.Data.SqlClient;

namespace QuickMath.Infrastructure.Data;

public sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory()
    {
        _connectionString = Environment.GetEnvironmentVariable("QUICKMATH_SQLSERVER_CONNECTION_STRING")
            ?? throw new InvalidOperationException(
                "Missing SQL Server connection string. Set QUICKMATH_SQLSERVER_CONNECTION_STRING before starting QuickMath.");
    }

    public SqlConnection Create() => new(_connectionString);
}
