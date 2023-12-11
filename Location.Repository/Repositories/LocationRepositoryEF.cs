using Location.Entities;
using Location.Repository.Contracts;
using Location.Repository.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Location.Repository.Repositories;

public class LocationRepositoryEF(LocationContext locationContext) : ILocationRepository
{
    private readonly LocationContext _locationContext = locationContext;


    public async Task<int> Create(Entities.Entities.Location location)
    {
        await _locationContext.Locations.AddAsync(location.ToModel());

        await _locationContext.SaveChangesAsync();

        return 1;
    }

    public async Task<int> Delete(int id)
    {
        return await _locationContext.Locations.Where(c => c.Id == id).ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<Entities.Entities.Location>> GetAll()
    {
        return await _locationContext.Locations.Select(l => l.ToEntity()).ToListAsync();
    }

    public async Task<IEnumerable<Entities.Entities.Location>> GetByClientId(int clientId)
    {
        return await _locationContext.Locations.Where(l => l.IdClient == clientId).Select(l => l.ToEntity()).ToListAsync();
    }

    public async Task<Entities.Entities.Location?> GetById(int id)
    {
        return (await _locationContext.Locations.FindAsync(id))?.ToEntity();
    }

    public async Task<int> Update(Entities.Entities.Location location)
    {
        return await _locationContext.Locations.Where(l => l.Id == location.Id).ExecuteUpdateAsync(
            u => u
            .SetProperty(l => l.IdClient, location.Id_Client)
            .SetProperty(l => l.IdVehicule, location.Id_Vehicule)
            .SetProperty(l => l.DateDebut, location.Date_Debut)
            .SetProperty(l => l.DateFin, location.Date_Fin)
            .SetProperty(l => l.NbKm, location.Nb_Km)
            );
    }
}
