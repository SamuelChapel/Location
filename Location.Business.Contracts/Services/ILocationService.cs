using Location.Business.Contracts.Services.Base;

namespace Location.Business.Contracts.Services;

public interface ILocationService : IReadService<Entities.Location, int>, IWriteService<Entities.Location, int>
{
	Task<IEnumerable<Entities.Location>> GetByClientId(int id);
}
