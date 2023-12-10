using Location.Entities.Base;

namespace Location.Entities;

public class Categorie : IEntity<int>
{
	public int Id { get; set; }
	public string Libelle { get; set; }
	public int Prix_Km { get; set; }
}
