using Location.Entities;
using Location.Entities.Entities;
using Location.Repository.Contracts;
using Location.Repository.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Location.Repository.Repositories;

public class ClientRepositoryEF(LocationContext locationContext) : IClientRepository
{
    private readonly LocationContext _locationContext = locationContext;

    public async Task<int> Create(Client client)
    {
        await _locationContext.Clients.AddAsync(client.ToModel());

        await _locationContext.SaveChangesAsync();

        return 1;
    }

    public async Task<int> Delete(int id)
    {
        return await _locationContext.Clients.Where(c => c.Id == id).ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<Client>> FindClients(string searchString)
    {
        return await _locationContext.Clients
            .Where(c =>
        EF.Functions.Like(c.Nom, $"%{searchString}%") ||
        EF.Functions.Like(c.Prenom, $"%{searchString}%") ||
        EF.Functions.Like(c.Adresse, $"%{searchString}%") ||
        EF.Functions.Like(c.CodePostal, $"%{searchString}%") ||
        EF.Functions.Like(c.Ville, $"%{searchString}%")
        )
            .Select(c => c.ToEntity()).ToListAsync();
    }

    public async Task<IEnumerable<Client>> GetAll()
    {
        return await _locationContext.Clients.Select(c => c.ToEntity()).ToListAsync();
    }

    public async Task<Client?> GetById(int id)
    {
        return (await _locationContext.Clients.FindAsync(id))?.ToEntity();
    }

    public async Task<int> Update(Client client)
    {
        return await _locationContext.Clients.Where(c => c.Id == client.Id).ExecuteUpdateAsync(
            u => u
            .SetProperty(c => c.Nom, client.Nom)
            .SetProperty(c => c.Prenom, client.Prenom)
            .SetProperty(c => c.Adresse, client.Adresse)
            .SetProperty(c => c.DateNaissance, client.Date_Naissance)
            .SetProperty(c => c.CodePostal, client.Code_Postal)
            .SetProperty(c => c.Ville, client.Ville)
            );
    }
}
