using Location.Entities.Entities;

namespace Location.Tests.Common.Builders;

public class ClientBuilder
{
	private int _id = 0;
	private string _prenom = "fooFirstName";
	private string _nom = "fooLastName";
	private DateTime _date_Naissance = new();
	private string? _adresse = "fooAddress";
	private string? _code_Postal = "fooPostalCode";
	private string? _ville = "fooCity";

	public static ClientBuilder AClient => new();

	public ClientBuilder WithId(int id)
	{
		_id = id;
		return this;
	}

	public Client Build()
	{
		var client = new Client()
		{
			Id = _id,
			Prenom = _prenom,
			Code_Postal = _code_Postal,
			Adresse = _adresse,
			Date_Naissance = _date_Naissance,
			Nom = _nom,
			Ville = _ville
		};

		return client;
	}
}
