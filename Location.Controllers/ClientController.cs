using Location.Business.Contracts;
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

			return client.ToString();
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
			PostalCode = postalCode,
			LastName = lastName,
			FirstName = firstName,
			City = city,
			BirthDate = birthDate,
			Address = address,
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

	public async Task<string> UpdateClient(string firstName,
		string lastName,
		DateTime birthDate,
		string address,
		string postalCode,
		string city)
	{
		var client = new Client
		{
			PostalCode = postalCode,
			LastName = lastName,
			FirstName = firstName,
			City = city,
			BirthDate = birthDate,
			Address = address,
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

			return result > 0 ? $"Le client à bien été supprimé" : "Erreur : client non supprimé";
		}
		catch (Exception ex)
		{
			return ex.Message;
		}
	}
}
