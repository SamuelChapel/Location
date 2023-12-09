using Location.Entities.Base;

namespace Location.Entities;

public class Client : IEntityBase<int>
{
	public int Id { get; init; }
	public string Nom { get; set; } = null!;
	public string Prenom { get; set; } = null!;
	public DateTime Date_Naissance { get; set; } = DateTime.MinValue;
	public string? Adresse { get; set; } = null!;
	public string? Code_Postal { get; set; } = null!;
	public string? Ville { get; set; } = null!;

	public override string ToString()
	{
		return $"{Id,3}\t{Prenom,-15} {Nom,-15} {Date_Naissance.ToShortDateString(),-15} {Adresse,-30} {Code_Postal,-10} {Ville,-15}";
	}
}
