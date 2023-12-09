using Location.Business.Contracts.Services.Base;

namespace Location.Business.Contracts.Services;

public interface ILocationService : IGenericReadService<Entities.Location, int>, IGenericWriteService<Entities.Location, int>
{
	Task<IEnumerable<Entities.Location>> GetByClientId(int id);
}
