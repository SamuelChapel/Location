using Location.Repository.Contracts;
using Location.Repository.Services;
using System.Data.SqlClient;

namespace Location.Repository.Repositories;

public class LocationRepositoryADO(SqlCommandHandler sqlCommandHandler) : ILocationRepository
{
    private readonly SqlCommandHandler _sqlCommandHandler = sqlCommandHandler;

    public async Task<Entities.Entities.Location?> GetById(int id)
    {
        var command = new SqlCommand("SELECT * FROM LOCATION WHERE Id = @id");
        command.Parameters.AddWithValue("Id", id);

        var location = await _sqlCommandHandler.ExecuteReaderAndMapAsync<Entities.Entities.Location>(command);

        return location.FirstOrDefault();
    }

    public async Task<IEnumerable<Entities.Entities.Location>> GetByClientId(int clientId)
    {
        var command = new SqlCommand("SELECT * FROM LOCATION WHERE Id_Client = @IdClient");
        command.Parameters.AddWithValue("IdClient", clientId);

        var locations = await _sqlCommandHandler.ExecuteReaderAndMapAsync<Entities.Entities.Location>(command);

        return locations;
    }

    public async Task<IEnumerable<Entities.Entities.Location>> GetAll()
    {
        var command = new SqlCommand("SELECT * FROM LOCATION");

        var locations = await _sqlCommandHandler.ExecuteReaderAndMapAsync<Entities.Entities.Location>(command);

        return locations;
    }

    public async Task<int> Create(Entities.Entities.Location location)
    {
        var command = new SqlCommand("insert into LOCATION VALUES(@Id_Client, @id_vehicle, @distance, @startDate, @endDate)");

        command.Parameters.AddWithValue("Id_Client", location.Id_Client);
        command.Parameters.AddWithValue("id_vehicle", location.Id_Vehicule);
        command.Parameters.AddWithValue("distance", location.Nb_Km);
        command.Parameters.AddWithValue("startDate", location.Date_Debut);
        command.Parameters.AddWithValue("endDate", location.Date_Fin);

        return await _sqlCommandHandler.ExecuteNonQueryAsync(command);
    }

    public async Task<int> Update(Entities.Entities.Location location)
    {
        var command = new SqlCommand("UPDATE LOCATION SET Id_Client = @Id_Client, Id_Vehicle = @id_vehicle, Nb_Km = @distance, DATE_DEBUT = @startDate, DATE_FIN = @endDate WHERE Id = @id");

        command.Parameters.AddWithValue("Id_Client", location.Id_Client);
        command.Parameters.AddWithValue("id_vehicle", location.Id_Vehicule);
        command.Parameters.AddWithValue("distance", location.Nb_Km);
        command.Parameters.AddWithValue("startDate", location.Date_Debut);
        command.Parameters.AddWithValue("endDate", location.Date_Fin);
        command.Parameters.AddWithValue("id", location.Id);

        return await _sqlCommandHandler.ExecuteNonQueryAsync(command);
    }

    public async Task<int> Delete(int id)
    {
        var command = new SqlCommand("DELETE FROM LOCATION WHERE Id = @id");
        command.Parameters.AddWithValue("Id", id);

        return await _sqlCommandHandler.ExecuteNonQueryAsync(command);
    }
}
