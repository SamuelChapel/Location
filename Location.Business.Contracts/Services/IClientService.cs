using Location.Business.Contracts.Services.Base;
using Location.Entities.Entities;

namespace Location.Business.Contracts.Services;

public interface IClientService : IReadService<Client, int>, IWriteService<Client, int>
{
	Task<IEnumerable<Client>> FindClients(string searchString);
}
