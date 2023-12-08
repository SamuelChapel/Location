using System.Data.SqlClient;
using Location.Entities;
using Location.Repository.Contracts.Repositories;
using Location.Repository.Services;

namespace Location.Repository.Repositories;

public class ClientRepositoryADO(SqlCommandHandler sqlCommandHandler)
	: IClientRepository
{
	private readonly SqlCommandHandler _sqlCommandHandler = sqlCommandHandler;

	public async Task<Client> GetById(int id)
	{
		var command = new SqlCommand("SELECT * FROM WHERE Id = @id");
		command.Parameters.AddWithValue("Id", id);

		var reader = await _sqlCommandHandler.ExecuteReaderAsync(command);

		var client =  new Client(
				reader.GetInt32(0),
				reader.GetString(1),
				reader.GetString(2),
				reader.GetDateTime(3),
				reader.GetString(4),
				reader.GetString(5),
				reader.GetString(6));

		return client;
	}

	public async Task<IEnumerable<Client>> GetAll()
	{
		var command = new SqlCommand("SELECT * FROM CLIENT");

		var reader = await _sqlCommandHandler.ExecuteReaderAsync(command);

		var clients = new List<Client>();

		while (reader.Read())
		{
			clients.Add(new Client(
				reader.GetInt32(0),
				reader.GetString(1),
				reader.GetString(2),
				reader.GetDateTime(3),
				reader.GetString(4),
				reader.GetString(5),
				reader.GetString(6)));
		}

		return clients;
	}

	public async Task<int> Create(Client client)
	{
		var command = new SqlCommand("insert into CLIENT VALUES(@lastName, @firstName, @birthDate, @address, @postalCode, @city)");

		command.Parameters.AddWithValue("lastName", client.LastName);
		command.Parameters.AddWithValue("firstName", client.FirstName);
		command.Parameters.AddWithValue("birthDate", client.BirthDate);
		command.Parameters.AddWithValue("address", client.Address);
		command.Parameters.AddWithValue("postalCode", client.PostalCode);
		command.Parameters.AddWithValue("city", client.City);

		return await _sqlCommandHandler.ExecuteNonQueryAsync(command);
	}

	public async Task<int> Update(Client client)
	{
		var command = new SqlCommand("UPDATE client SET LastName = @lastName, FirstName = @firstName, BirthDate = @birthDate, Address = @address, PostalCode = @postalCode, City = @city WHERE Id = @id");
		command.Parameters.AddWithValue("lastName", client.LastName);
		command.Parameters.AddWithValue("firstName", client.FirstName);
		command.Parameters.AddWithValue("birthDate", client.BirthDate);
		command.Parameters.AddWithValue("address", client.Address);
		command.Parameters.AddWithValue("postalCode", client.PostalCode);
		command.Parameters.AddWithValue("city", client.City);

		return await _sqlCommandHandler.ExecuteNonQueryAsync(command);
	}

	public async Task<int> Delete(int id)
	{
		var command = new SqlCommand("delete from CLIENT where Id = @id");
		command.Parameters.AddWithValue("Id", id);

		return await _sqlCommandHandler.ExecuteNonQueryAsync(command);
	}
}
