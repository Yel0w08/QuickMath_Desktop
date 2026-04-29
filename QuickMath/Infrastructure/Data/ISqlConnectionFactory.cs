using Microsoft.Data.SqlClient;

namespace QuickMath.Infrastructure.Data;

public interface ISqlConnectionFactory
{
    SqlConnection Create();
}
