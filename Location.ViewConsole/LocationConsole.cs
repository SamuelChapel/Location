using Location.Controllers;
using Location.ViewConsole.Properties;
using static System.Console;
using static Location.ViewConsole.Helpers.ConsoleHelper;

namespace Location.ViewConsole;

public class LocationConsole(LocationController locationController)
{
	public async Task AddLocation()
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

	public async Task UpdateLocation()
	{
		var id = GetIntFromConsole(Resources.EnterLocationId);

		var clientId = GetIntFromConsole(Resources.EnterClientId);
		var vehicleId = GetIntFromConsole(Resources.EnterVehicleId);
		var distance = GetIntFromConsole(Resources.EnterDistance);
		var startDate = GetDateFromConsole(Resources.EnterStartDate);
		var endDate = GetDateFromConsole(Resources.EnterEndDate);

		var result = await locationController.Update(id, clientId, vehicleId, distance, startDate, endDate);

		WriteLine("\n" + result);

		DisplayWaitKey();
	}

	public async Task DeleteLocation()
	{
		var id = GetIntFromConsole(Resources.EnterLocationId);
		await GetLocationById();

		if (ConfirmChoice(Resources.ConfirmDeleteLocation))
		{
			var result = await locationController.Delete(id);

			WriteLine(result);

			DisplayWaitKey();
		}
	}

	public async Task GetLocationById()
	{
		var id = GetIntFromConsole(Resources.EnterLocationId);

		var result = await locationController.GetById(id);

		WriteLine(result);

		DisplayWaitKey();
	}

	public async Task DisplayAllLocations()
	{
		var locations = await locationController.GetAll();

		locations.ForEach(WriteLine);

		DisplayWaitKey();
	}
}
