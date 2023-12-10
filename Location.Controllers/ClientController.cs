using Location.Business.Contracts.Services;
using Location.Entities;

namespace Location.Controllers;

public class ClientController(IClientService clientService)
{
	private readonly IClientService _clientService = clientService;

	public async Task<string> GetById(int id)
	{
		try
		{
			var client = await _clientService.GetById(id);

			return client?.ToString() ?? $"Client avec l'id {id} non trouvé";
		}
		catch (Exception ex)
		{
			return ex.Message;
		}
	}

	public async Task<List<string>> GetAll()
	{
		try
		{
			var clients = await _clientService.GetAll();

			return clients.Select(c => c.ToString()).ToList();
		}
		catch (Exception ex)
		{
			return [ex.Message];
		}
	}

	public async Task<string> CreateClient(
		string firstName,
		string lastName,
		DateTime birthDate,
		string address,
		string postalCode,
		string city)
	{
		var client = new Client
		{
			Code_Postal = postalCode,
			Nom = lastName,
			Prenom = firstName,
			Ville = city,
			Date_Naissance = birthDate,
			Adresse = address,
		};

		try
		{
			var result = await _clientService.Create(client);

			return result > 0 ? $"Le client à bien été créé" : "Erreur : client non créé";
		}
		catch (Exception ex)
		{
			return ex.Message;
		}
	}

	public async Task<string> UpdateClient(
		int id,
		string firstName,
		string lastName,
		DateTime birthDate,
		string address,
		string postalCode,
		string city)
	{
		var client = new Client
		{
			Id = id,
			Code_Postal = postalCode,
			Nom = lastName,
			Prenom = firstName,
			Ville = city,
			Date_Naissance = birthDate,
			Adresse = address,
		};

		try
		{
			var result = await _clientService.Update(client);

			return result > 0 ? $"Le client à bien été mis à jour" : "Erreur : client non mis à jour";
		}
		catch (Exception ex)
		{
			return ex.Message;
		}
	}

	public async Task<string> DeleteClient(int id)
	{
		try
		{
			var result = await _clientService.Delete(id);

			return result == 1 ? $"Le client à bien été supprimé." :
				result > 1 ? $"Le client à bien été supprimé ainsi que ses {result - 1} locations." : "Erreur : client non supprimé";
		}
		catch (Exception ex)
		{
			return ex.Message;
		}
	}
}
