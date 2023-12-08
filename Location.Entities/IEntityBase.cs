namespace Location.Entities;

public interface IEntityBase<TId>
{
    public TId Id { get; init; }
}