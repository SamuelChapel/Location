using Location.Entities.Base;

namespace Location.Business.Contracts.Services.Base;

public interface IGenericWriteService<TEntity, TId> where TEntity : IEntityBase<TId>
{
	Task<int> Create(TEntity client);
	Task<int> Update(TEntity client);
	Task<int> Delete(TId id);
}
