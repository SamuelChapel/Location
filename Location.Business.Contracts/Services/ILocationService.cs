using Location.Business.Contracts.Services.Base;

namespace Location.Business.Contracts.Services;

public interface ILocationService : IReadService<Entities.Entities.Location, int>, IWriteService<Entities.Entities.Location, int>
{
	Task<IEnumerable<Entities.Entities.Location>> GetByClientId(int id);
}
