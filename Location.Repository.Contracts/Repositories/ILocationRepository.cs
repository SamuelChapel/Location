using Location.Repository.Contracts.Repositories.Base;

namespace Location.Repository.Contracts.Repositories;

public interface ILocationRepository : IGenericReadRepository<Entities.Location, int>
{
}
