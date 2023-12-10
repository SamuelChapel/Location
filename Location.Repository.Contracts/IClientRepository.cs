using Location.Entities;
using Location.Repository.Contracts.Base;

namespace Location.Repository.Contracts;

public interface IClientRepository : IReadRepository<Client, int>, IWriteRepository<Client, int>
{
	Task<IEnumerable<Client>> FindClients(string searchString);
}
