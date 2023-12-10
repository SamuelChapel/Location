using Location.Entities.Base;

namespace Location.Entities;

public class Vehicule : IEntity<int>
{
	public int Id { get; set; }
	public string Immatriculation { get; set; }
	public string Modele { get; set; }
	public string Couleur { get; set; }
	public int? Id_Marque { get; set; }
	public int? Id_Categorie { get; set; }
}
