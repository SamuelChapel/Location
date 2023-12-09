using System.Data.SqlClient;
using Location.Entities;
using Location.Repository.Contracts;
using Location.Repository.ObjectExtensions;
using Location.Repository.Services;

namespace Location.Repository.Repositories;

public class ClientRepositoryADO(SqlCommandHandler sqlCommandHandler)
	: IClientRepository
{
	private readonly SqlCommandHandler _sqlCommandHandler = sqlCommandHandler;

	public async Task<Client?> GetById(int id)
	{
		var command = new SqlCommand("SELECT * FROM CLIENT WHERE Id = @id");
		command.Parameters.AddWithValue("Id", id);

		var client = await _sqlCommandHandler.ExecuteReaderAsync<Client>(command);

		return client.FirstOrDefault();
	}

	public async Task<IEnumerable<Client>> GetAll()
	{
		var command = new SqlCommand("SELECT * FROM CLIENT");

		var clients = await _sqlCommandHandler.ExecuteReaderAsync<Client>(command);

		return clients;
	}

	public async Task<int> Create(Client client)
	{
		var command = new SqlCommand("insert into CLIENT VALUES(@lastName, @firstName, @birthDate, @address, @postalCode, @city)");

		command.Parameters.AddWithValue("lastName", client.Nom.ToUpper());
		command.Parameters.AddWithValue("firstName", client.Prenom.ToCapitalize());
		command.Parameters.AddWithValue("birthDate", client.Date_Naissance);
		command.Parameters.AddWithValue("address", client.Adresse);
		command.Parameters.AddWithValue("postalCode", client.Code_Postal);
		command.Parameters.AddWithValue("city", client.Ville);

		return await _sqlCommandHandler.ExecuteNonQueryAsync(command);
	}

	public async Task<int> Update(Client client)
	{
		var command = new SqlCommand("UPDATE client SET NOM = @lastName, PRENOM = @firstName, DATE_NAISSANCE = @birthDate, ADRESSE = @address, CODE_POSTAL = @postalCode, VILLE = @city WHERE Id = @id");
		command.Parameters.AddWithValue("lastName", client.Nom.ToUpper());
		command.Parameters.AddWithValue("firstName", client.Prenom.ToCapitalize());
		command.Parameters.AddWithValue("birthDate", client.Date_Naissance);
		command.Parameters.AddWithValue("address", client.Adresse);
		command.Parameters.AddWithValue("postalCode", client.Code_Postal);
		command.Parameters.AddWithValue("city", client.Ville);
		command.Parameters.AddWithValue("id", client.Id);

		return await _sqlCommandHandler.ExecuteNonQueryAsync(command);
	}

	public async Task<int> Delete(int id)
	{
		var command = new SqlCommand("delete from CLIENT where Id = @id");
		command.Parameters.AddWithValue("Id", id);

		return await _sqlCommandHandler.ExecuteNonQueryAsync(command);
	}
}
