using Location.Entities.Base;

namespace Location.Entities;

public class Marque : IEntity<int>
{
	public int Id { get; set; }
	public string Nom { get; set; } = null!;
}
