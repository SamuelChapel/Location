using Location.Entities;
using Location.Repository.Contracts.Base;

namespace Location.Repository.Contracts;

public interface IClientRepository : IGenericReadRepository<Client, int>, IGenericWriteRepository<Client, int>
{
}
