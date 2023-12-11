using Location.Entities.Entities;
using Location.Repository.Contracts.Base;

namespace Location.Repository.Contracts;

public interface ILocationRepository : IReadRepository<Entities.Entities.Location, int>, IWriteRepository<Entities.Entities.Location, int>
{
    /// <summary>
    /// Get all <see cref="Location.Entities.Entities.Location"/> for a <see cref="Client"/>
    /// </summary>
    /// <param name="clientId">The <paramref name="clientId"/> of the <typeparamref name="Client"/> for getting the <typeparamref name="Location"/></param>
    /// <returns>The <see cref="IEnumerable{Location.Entities.Entities.Location}"/> of the <see cref="Client"/></returns>
    Task<IEnumerable<Entities.Entities.Location>> GetByClientId(int clientId);
}
