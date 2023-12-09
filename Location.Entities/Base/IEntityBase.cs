namespace Location.Entities.Base;

public interface IEntityBase<TId>
{
    public TId Id { get; init; }
}