using Location.Entities;
using Location.Repository.Contracts.Repositories.Base;

namespace Location.Repository.Contracts.Repositories;

public interface IClientRepository : IGenericReadRepository<Client, int>, IGenericWriteRepository<Client, int>
{
}
