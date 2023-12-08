using Location.Business.Contracts;
using Location.Business.Contracts.Clients;
using Location.Repository.Contracts;

namespace Location.Business;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task<int> Create(CreateClientDto client)
    {
        return await _clientRepository.Create(client);
    }

    public async Task<int> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ClientDto> FindClientById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ClientDto>> GetAllClients()
    {
        var clients = await _clientRepository.GetAll();

        return clients.Select(c => new ClientDto(c.Id, c.FirstName, c.LastName, c.BirthDate, c.Address, c.PostalCode, c.City));
    }

    public async Task<int> Update(UpdateClientDto client)
    {
        throw new NotImplementedException();
    }
}
