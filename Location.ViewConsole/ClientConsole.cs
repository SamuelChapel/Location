using Location.Controllers;
using Location.ViewConsole.Properties;
using static System.Console;
using static Location.ViewConsole.Helpers.ConsoleHelper;

namespace Location.ViewConsole;

public class ClientConsole(ClientController clientController, LocationController locationController)
{
	public async Task AddClient()
	{
		var firstName = GetStringFromConsole(Resources.EnterFirstName);
		var lastName = GetStringFromConsole(Resources.EnterLastName);
		var birthDate = GetDateFromConsole(Resources.EnterBirthDate);
		var address = GetStringFromConsole(Resources.EnterAddress);
		var postalCode = GetStringFromConsole(Resources.EnterPostalCode);
		var ville = GetStringFromConsole(Resources.EnterCity);

		var result = await clientController.CreateClient(firstName, lastName, birthDate, address, postalCode, ville);

		WriteLine(result);

		DisplayWaitKey();
	}

	public async Task UpdateClient()
	{
		var id = GetIntFromConsole(Resources.EnterClientId);

		var firstName = GetStringFromConsole(Resources.EnterFirstName);
		var lastName = GetStringFromConsole(Resources.EnterLastName);
		var birthDate = GetDateFromConsole(Resources.EnterBirthDate);
		var address = GetStringFromConsole(Resources.EnterAddress);
		var postalCode = GetStringFromConsole(Resources.EnterPostalCode);
		var city = GetStringFromConsole(Resources.EnterCity);

		var result = await clientController.UpdateClient(id, firstName, lastName, birthDate, address, postalCode, city);

		WriteLine(result);

		DisplayWaitKey();
	}

	public async Task DeleteClient()
	{
		var id = GetIntFromConsole(Resources.EnterClientId);

		var result = await clientController.GetById(id);
		WriteLine("\n" + result);

		if (result.Contains(Resources.ClientNonExistent))
		{
			DisplayWaitKey();
			return;
		}

		if (ConfirmChoice(Resources.ConfirmDeleteClient))
		{
			result = await clientController.DeleteClient(id);

			WriteLine("\n" + result);

			DisplayWaitKey();
		}
	}

	public async Task DisplayAllClients()
	{
		var clients = await clientController.GetAll();

		clients.ForEach(WriteLine);

		DisplayWaitKey();
	}

	public async Task GetClientById()
	{
		var id = GetIntFromConsole();

		var result = await clientController.GetById(id);

		WriteLine(result);

		DisplayWaitKey();

		if (!int.TryParse(result[..3], out int clientId))
			return;

		int choice = DisplayMenu(
			Resources.MenuClient,
			Resources.Yes,
			Resources.No);

		switch (choice)
		{
			case 1:

				await DisplayLocationsForClient(clientId);
				break;
			case 2:
				break;
			default:
				WriteLine(Resources.InvalidChoice);
				break;
		}
	}

	public async Task DisplayLocationsForClient(int clientId)
	{
		var result = await locationController.GetByClientId(clientId);

		result.ForEach(WriteLine);

		DisplayWaitKey();
	}
}
