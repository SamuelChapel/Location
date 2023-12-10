using Location.Business.Contracts.Exceptions;
using Location.Business.Contracts.Services;
using Location.Entities;
using Location.Repository.Contracts;

namespace Location.Business;

public class ClientService(IClientRepository clientRepository) : IClientService
{
	private readonly IClientRepository _clientRepository = clientRepository;

	public async Task<Client> GetById(int id)
	{
		return await _clientRepository.GetById(id) ?? throw new InvalidClientIdException(id);
	}

	public async Task<IEnumerable<Client>> GetAll()
	{
		return await _clientRepository.GetAll();
	}

	public Task<IEnumerable<Client>> FindClients(string searchString)
	{
		return _clientRepository.FindClients(searchString);
	}

	public async Task<int> Create(Client client)
	{
		return await _clientRepository.Create(client);
	}

	public async Task<int> Update(Client client)
	{
		_ = GetById(client.Id);

		return await _clientRepository.Update(client);
	}

	public async Task<int> Delete(int id)
	{
		return await _clientRepository.Delete(id);
	}
}
