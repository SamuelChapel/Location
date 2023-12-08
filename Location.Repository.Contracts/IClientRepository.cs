using Location.Business.Contracts.Clients;
using Location.Entities;

namespace Location.Repository.Contracts;

public interface IClientRepository
{
    Task<Client> GetById(int id);

    Task<IEnumerable<Client>> GetAll();

    Task<int> Create(CreateClientDto client);

    Task<int> Update(UpdateClientDto client);

    Task<int> Delete(int id);
}
