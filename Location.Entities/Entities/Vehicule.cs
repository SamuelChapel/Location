using Location.Entities.Base;

namespace Location.Entities.Entities;

public class Vehicule : IEntity<int>
{
    public int Id { get; set; }
    public string Immatriculation { get; set; } = null!;
    public string Modele { get; set; } = null!;
    public string Couleur { get; set; } = null!;
    public int? Id_Marque { get; set; }
    public int? Id_Categorie { get; set; }
}
