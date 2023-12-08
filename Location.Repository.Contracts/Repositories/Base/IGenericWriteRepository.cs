using Location.Entities;

namespace Location.Repository.Contracts.Repositories.Base;

public interface IGenericWriteRepository<TEntity, Tid> where TEntity : IEntityBase<Tid>
{
	/// <summary>
	/// Create a <typeparamref name="TEntity"/>
	/// </summary>
	/// <param name="t">The <typeparamref name="TEntity"/> to create</param>
	/// <returns>The <typeparamref name="Tid"/> that corresponds to the id of the <typeparamref name="TEntity"/> created</returns>
	Task<Tid> Create(TEntity entity);

	/// <summary>
	/// Modify a <typeparamref name="TEntity"/>
	/// </summary>
	/// <param name="t">The <typeparamref name="TEntity"/> to modify</param>
	/// <returns>The number of <typeparamref name="TEntity"/> modified</returns>
	Task<int> Update(TEntity entity);

	/// <summary>
	/// Delete a <typeparamref name="TEntity"/>
	/// </summary>
	/// <param name="t">The <typeparamref name="TEntity"/> id to delete</param>
	/// <returns>The number of <typeparamref name="TEntity"/> deleted</returns>
	Task<int> Delete(Tid id);
}
