using Location.Entities;

namespace Location.Business.Contracts;

public interface IClientService
{
	Task<Client> GetById(int id);

	Task<IEnumerable<Client>> GetAll();

	Task<int> Create(Client client);

	Task<int> Update(Client client);

	Task<int> Delete(int id);
}
