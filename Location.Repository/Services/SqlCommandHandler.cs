using System.Data.SqlClient;

namespace Location.Repository.Services;

public class SqlCommandHandler
{
	private const string CONNEXION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB; Integrated Security=SSPI;Initial Catalog=LOCATION_VEHICULE";

	/// <summary>
	/// Execute a non query command
	/// </summary>
	/// <param name="command">The command to execute</param>
	/// <returns>The sqldatareader containing the query response rows</returns>
	/// <exception cref="System.Data.Common.DbException"></exception>
	public async Task<SqlDataReader> ExecuteReaderAsync(SqlCommand command)
	{
		using var sqlConnection = new SqlConnection(CONNEXION_STRING);
		command.Connection = sqlConnection;

		await sqlConnection.OpenAsync();

		return await command.ExecuteReaderAsync();
	}

	/// <summary>
	/// Execute a non query command
	/// </summary>
	/// <param name="command">The command to execute</param>
	/// <returns>The number of column modified</returns>
	/// <exception cref="System.Data.Common.DbException"></exception>
	public async Task<int> ExecuteNonQueryAsync(SqlCommand command)
	{
		using var sqlConnection = new SqlConnection(CONNEXION_STRING);
		command.Connection = sqlConnection;

		await sqlConnection.OpenAsync();

		return await command.ExecuteNonQueryAsync();
	}
}
