using Location.Entities.Base;

namespace Location.Entities;

public class Location : IEntityBase<int>
{
	public int Id { get; init; }
	public int? Id_Client { get; set; }
	public int? Id_Vehicule { get; set; }
	public int Nb_Km { get; set; }
	public DateTime Date_Debut { get; set; }
	public DateTime? Date_Fin { get; set; }

	public override string ToString()
	{
		return $"{Id,3}\t{Nb_Km,-10} {Date_Debut.ToShortDateString(),-15} {Date_Fin?.ToShortDateString(),-15}";
	}
}
