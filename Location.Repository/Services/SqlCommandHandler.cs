using System.Data.SqlClient;
using System.Reflection;
using Location.Entities.Base;

namespace Location.Repository.Services;

public class SqlCommandHandler
{
	private readonly string _connexionString = Properties.Resources.ConnexionStringMSI;

	/// <summary>
	/// Execute an <see cref="SqlCommand"/> and map the result into an <see cref="IEnumerable{T}"/>
	/// </summary>
	/// <typeparam name="T">The return Entity to map</typeparam>
	/// <param name="command">The <see cref="SqlCommand"/> containing the query to execute</param>
	/// <returns><see cref="IEnumerable{T}"/></returns>
	public async Task<IEnumerable<T>> ExecuteReaderAndMapAsync<T>(SqlCommand command) where T : IEntity<int>, new()
	{
		using var sqlConnection = new SqlConnection(_connexionString);
		command.Connection = sqlConnection;

		await sqlConnection.OpenAsync();

		var reader = await command.ExecuteReaderAsync();

		Type TypeT = typeof(T);
		ConstructorInfo ctor = TypeT.GetConstructor(Type.EmptyTypes)!;

		var entities = new List<T>();

		var props = TypeT.GetProperties();

		while (reader.Read())
		{
			var newInst = (T)ctor.Invoke(null);

			for (int i = 0; i < reader.FieldCount; i++)
			{
				string propName = reader.GetName(i);
				PropertyInfo? propInfo = props.FirstOrDefault(p => p.Name.Equals(propName, StringComparison.CurrentCultureIgnoreCase));

				if (propInfo != null)
				{
					var value = reader.GetValue(i);

					if (value == DBNull.Value)
					{
						propInfo.SetValue(newInst, null);
					}
					else
					{
						propInfo.SetValue(newInst, value);
					}
				}
			}

			entities.Add(newInst);
		}

		return entities;
	}

	/// <summary>
	/// Execute a non query command
	/// </summary>
	/// <param name="command">The command to execute</param>
	/// <returns>The number of column modified</returns>
	/// <exception cref="System.Data.Common.DbException"></exception>
	public async Task<int> ExecuteNonQueryAsync(SqlCommand command)
	{
		using var sqlConnection = new SqlConnection(_connexionString);
		command.Connection = sqlConnection;

		await sqlConnection.OpenAsync();

		return await command.ExecuteNonQueryAsync();
	}

	/// <summary>
	/// Execute multiple <see cref="SqlCommand"/> in a transaction
	/// </summary>
	/// <param name="commands">The <see cref="SqlCommand"/> <see cref="Array"/> to execute</param>
	/// <returns>The number of rows deleted</returns>
	public async Task<int> ExecuteTransactionAsync(params SqlCommand[] commands)
	{
		using var sqlConnection = new SqlConnection(_connexionString);

		await sqlConnection.OpenAsync();

		SqlTransaction transaction = sqlConnection.BeginTransaction();

		try
		{
			var rowsDeleted = 0;

			foreach (SqlCommand command in commands)
			{
				command.Connection = sqlConnection;
				command.Transaction = transaction;
				rowsDeleted += await command.ExecuteNonQueryAsync();
			}

			transaction.Commit();
			return rowsDeleted;
		}
		catch (Exception)
		{
			transaction.Rollback();
			return 0;
		}
	}
}
