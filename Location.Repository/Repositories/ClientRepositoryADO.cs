using Location.Business.Contracts.Clients;
using Location.Entities;
using Location.Repository.Contracts;
using Location.Repository.Services.SqlCommandHandler;
using System.Data.SqlClient;

namespace Location.Repository.Repositories;

public class ClientRepositoryADO : IClientRepository
{
    private readonly ISqlCommandHandler<SqlCommand, int> _sqlCommandNonQueryHandler;
    private readonly ISqlCommandHandler<SqlCommand, SqlDataReader> _sqlCommandReaderHandler;

    public ClientRepositoryADO(ISqlCommandHandler<SqlCommand, int> sqlCommandNonQueryHandler, ISqlCommandHandler<SqlCommand, SqlDataReader> sqlCommandReaderHandler)
    {
        _sqlCommandNonQueryHandler = sqlCommandNonQueryHandler;
        _sqlCommandReaderHandler = sqlCommandReaderHandler;
    }

    public async Task<int> Create(CreateClientDto client)
    {
        var command = new SqlCommand("insert into CLIENT VALUES(@lastName, @firstName, @birthDate, @address, @postalCode, @city)");

        command.Parameters.AddWithValue("lastName", client.LastName);
        command.Parameters.AddWithValue("firstName", client.FirstName);
        command.Parameters.AddWithValue("birthDate", client.BirthDate);
        command.Parameters.AddWithValue("address", client.Address);
        command.Parameters.AddWithValue("postalCode", client.PostalCode);
        command.Parameters.AddWithValue("city", client.City);

        return await _sqlCommandNonQueryHandler.Execute(command);
    }

    public async Task<int> Delete(int id)
    {
        var command = new SqlCommand("delete from CLIENT where Id = @id");
        command.Parameters.AddWithValue("Id", id);

        return await _sqlCommandNonQueryHandler.Execute(command);
    }

    public async Task<IEnumerable<Client>> GetAll()
    {
        var command = new SqlCommand("SELECT * FROM CLIENT");

        var reader = await _sqlCommandReaderHandler.Execute(command);

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

    public async Task<Client> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> Update(UpdateClientDto client)
    {
        throw new NotImplementedException();
    }
}
