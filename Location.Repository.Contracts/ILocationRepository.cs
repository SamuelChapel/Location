using Location.Repository.Contracts.Base;

namespace Location.Repository.Contracts;

public interface ILocationRepository : IGenericReadRepository<Entities.Location, int>, IGenericWriteRepository<Entities.Location, int>
{
	Task<IEnumerable<Entities.Location>> GetByClientId(int clientId);
}
