using Location.Entities.Entities;

namespace Location.Entities.Dto;

public record struct LocationFullDto(
	int Id,
	int Nb_Km,
	DateTime Date_Debut,
	DateTime? Date_Fin,
	Client? Client,
	Vehicule? Vehicule
	)
{
	public override readonly string ToString()
	{
		return $"{Id,3}\t{Nb_Km,-10} {Date_Debut.ToShortDateString(),-15} {Date_Fin?.ToShortDateString(),-15}\n" +
			Client?.ToString() +
			Vehicule?.ToString();
	}
}