using System.Data.SqlClient;

namespace Location.Repository.Services.SqlCommandHandler;

public class SqlCommandNonQueryHandler
    : ISqlCommandHandler<SqlCommand, int>
{
    private const string _strConnexion = @"Data Source=(LocalDB)\MSSQLLocalDB; Integrated Security=SSPI;Initial Catalog=LOCATION_VEHICULE";

    public async Task<int> Execute(SqlCommand command)
    {
        using var sqlConnection = new SqlConnection(_strConnexion);

        command.Connection = sqlConnection;

        sqlConnection.Open();

        return await command.ExecuteNonQueryAsync();
    }
}
