using Location.Entities.Base;
namespace Location.Business.Contracts.Services.Base;

public interface IReadService<TEntity, TId> where TEntity : IEntity<TId>
{
	Task<TEntity> GetById(TId id);
	Task<IEnumerable<TEntity>> GetAll();
}