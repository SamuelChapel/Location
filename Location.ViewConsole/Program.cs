using Location.Controllers;
using Location.ViewConsole.Extensions;
using Location.ViewConsole.Properties;
using Unity;
using static System.Console;
using static Location.ViewConsole.Helpers.ConsoleHelper;

IUnityContainer unitycontainer = new UnityContainer().AddServices();
var clientController = unitycontainer.Resolve<ClientController>();
var locationController = unitycontainer.Resolve<LocationController>();

int choice;

do
{
	Clear();

	choice = DisplayMenu(Resources.MainMenuTitle,
		Resources.AddClient,
		Resources.UpdateClient,
		Resources.DeleteClient,
		Resources.DisplayClientById,
		Resources.DisplayAllClients,
		Resources.AddLocation,
		Resources.UpdateLocation,
		Resources.DeleteLocation,
		Resources.DisplayLocationById,
		Resources.DisplayAllLocations);

	Clear();

	switch (choice)
	{
		case 1:
			await AddClient();
			break;
		case 2:
			await UpdateClient();
			break;
		case 3:
			await DeleteClient();
			break;
		case 4:
			await GetClientById();
			break;
		case 5:
			await DisplayAllClients();
			break;
		case 6:
			await AddLocation();
			break;
		case 7:
			await UpdateLocation();
			break;
		case 8:
			await DeleteLocation();
			break;
		case 9:
			await GetLocationById();
			break;
		case 10:
			await DisplayAllLocations();
			break;
		case 0:
			WriteLine(Resources.QuitMessage);
			DisplayWaitKey();
			break;
		default:
			WriteLine(Resources.InvalidChoice);
			break;
	}
} while (choice != 0);

#region Locations
async Task AddLocation()
{
	var clientId = GetIntFromConsole(Resources.EnterClientId);
	var vehicleId = GetIntFromConsole(Resources.EnterVehicleId);
	var distance = GetIntFromConsole(Resources.EnterDistance);
	var startDate = GetDateFromConsole(Resources.EnterStartDate);
	var endDate = GetDateFromConsole(Resources.EnterEndDate);

	var result = await locationController.Create(clientId, vehicleId, distance, startDate, endDate);

	WriteLine(result);

	DisplayWaitKey();
}

async Task UpdateLocation()
{
	var id = GetIntFromConsole();

	var clientId = GetIntFromConsole(Resources.EnterClientId);
	var vehicleId = GetIntFromConsole(Resources.EnterVehicleId);
	var distance = GetIntFromConsole(Resources.EnterDistance);
	var startDate = GetDateFromConsole(Resources.EnterStartDate);
	var endDate = GetDateFromConsole(Resources.EnterEndDate);

	var result = await locationController.Update(id, clientId, vehicleId, distance, startDate, endDate);

	WriteLine(result);

	DisplayWaitKey();
}

async Task DeleteLocation()
{
	var id = GetIntFromConsole();

	var result = await locationController.Delete(id);

	WriteLine(result);

	DisplayWaitKey();
}

async Task GetLocationById()
{
	var id = GetIntFromConsole();

	var result = await locationController.GetById(id);

	WriteLine(result);

	DisplayWaitKey();
}

async Task DisplayAllLocations()
{
	var locations = await locationController.GetAll();

	locations.ForEach(WriteLine);

	DisplayWaitKey();
}
#endregion

#region Clients
async Task AddClient()
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

async Task UpdateClient()
{
	var id = GetIntFromConsole();

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

async Task DeleteClient()
{
	var id = GetIntFromConsole();

	var result = await clientController.DeleteClient(id);

	WriteLine(result);

	DisplayWaitKey();
}

async Task DisplayAllClients()
{
	var clients = await clientController.GetAll();

	clients.ForEach(WriteLine);

	DisplayWaitKey();
}

async Task GetClientById()
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

async Task DisplayLocationsForClient(int clientId)
{
	var result = await locationController.GetByClientId(clientId);

	result.ForEach(WriteLine);

	DisplayWaitKey();
}
#endregion
