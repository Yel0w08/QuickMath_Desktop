using Microsoft.Data.SqlClient;

namespace QuickMath.Infrastructure.Data;

/// <summary>
/// Factory abstraction used by repositories to open SQL Server connections.
/// </summary>
public interface ISqlConnectionFactory
{
    /// <summary>
    /// Creates a connection targeting the application database.
    /// </summary>
    SqlConnection Create();
}
