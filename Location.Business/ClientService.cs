using Location.Business.Contracts;
using Location.Entities;
using Location.Repository.Contracts.Repositories;

namespace Location.Business;

public class ClientService(IClientRepository clientRepository) : IClientService
{
	private readonly IClientRepository _clientRepository = clientRepository;

	public async Task<int> Create(Client client)
	{
		return await _clientRepository.Create(client);
	}

	public async Task<int> Delete(int id)
	{
		return await _clientRepository.Delete(id);
	}

	public async Task<Client> GetById(int id)
	{
		return await _clientRepository.GetById(id);
	}

	public async Task<IEnumerable<Client>> GetAll()
	{
		return await _clientRepository.GetAll();
	}

	public async Task<int> Update(Client client)
	{
		return await _clientRepository.Update(client);
	}
}
