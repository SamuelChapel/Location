using Location.Entities.Base;

namespace Location.Business.Contracts.Services.Base;

public interface IWriteService<TEntity, TId> where TEntity : IEntity<TId>
{
	Task<int> Create(TEntity client);
	Task<int> Update(TEntity client);
	Task<int> Delete(TId id);
}
