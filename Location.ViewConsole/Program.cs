using Location.ViewConsole;
using Location.ViewConsole.Extensions;
using Location.ViewConsole.Properties;
using Unity;
using static System.Console;
using static Location.ViewConsole.Helpers.ConsoleHelper;

IUnityContainer unitycontainer = new UnityContainer().AddServices();

var locationConsole = unitycontainer.Resolve<LocationConsole>();
var clientConsole = unitycontainer.Resolve<ClientConsole>();

int choice;

do
{
	Clear();

	choice = DisplayMenu(Resources.MainMenuTitle,
		Resources.AddClient,
		Resources.UpdateClient,
		Resources.DeleteClient,
		Resources.SearchClient,
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
			await clientConsole.AddClient();
			break;
		case 2:
			await clientConsole.UpdateClient();
			break;
		case 3:
			await clientConsole.DeleteClient();
			break;
		case 4:
			await clientConsole.SearchClient();
			break;
		case 5:
			await clientConsole.DisplayAllClients();
			break;
		case 6:
			await locationConsole.AddLocation();
			break;
		case 7:
			await locationConsole.UpdateLocation();
			break;
		case 8:
			await locationConsole.DeleteLocation();
			break;
		case 9:
			await locationConsole.GetLocationById();
			break;
		case 10:
			await locationConsole.DisplayAllLocations();
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
