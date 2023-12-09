using Location.Entities.Base;
namespace Location.Business.Contracts.Services.Base;

public interface IGenericReadService<TEntity, TId> where TEntity : IEntityBase<TId>
{
	Task<TEntity> GetById(TId id);
	Task<IEnumerable<TEntity>> GetAll();
}