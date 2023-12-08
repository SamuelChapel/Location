using Location.Business.Contracts.Clients;

namespace Location.Business.Contracts;

public interface IClientService
{
    Task<ClientDto> FindClientById(int id);

    Task<IEnumerable<ClientDto>> GetAllClients();

    Task<int> Create(CreateClientDto client);

    Task<int> Update(UpdateClientDto client);

    Task<int> Delete(int id);
}
