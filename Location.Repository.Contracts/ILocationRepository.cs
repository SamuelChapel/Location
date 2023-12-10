using Location.Entities;
using Location.Repository.Contracts.Base;

namespace Location.Repository.Contracts;

public interface ILocationRepository : IReadRepository<Entities.Location, int>, IWriteRepository<Entities.Location, int>
{
	/// <summary>
	/// Get all <see cref="Entities.Location"/> for a <see cref="Client"/>
	/// </summary>
	/// <param name="clientId">The <paramref name="clientId"/> of the <typeparamref name="Client"/> for getting the <typeparamref name="Location"/></param>
	/// <returns>The <see cref="IEnumerable{Entities.Location}"/> of the <see cref="Client"/></returns>
	Task<IEnumerable<Entities.Location>> GetByClientId(int clientId);
}
