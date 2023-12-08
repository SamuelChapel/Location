using Location.Controllers;
using Location.ViewConsole.Extensions;
using Unity;
using static Location.ViewConsole.Helpers.ConsoleHelper;
using static System.Console;

IUnityContainer unitycontainer = new UnityContainer().AddServices();
ClientController clientController = unitycontainer.Resolve<ClientController>();

int choice;

do
{
    choice = DisplayMenu("Gestion des locations des clients",
        "Ajouter un client",
        "Mettre à jour un client",
        "Afficher un client par son Id",
        "Afficher tous les client");

    switch (choice)
    {
        case 1:
            await AddClient();
            break;
        case 2:
            await UpdateClient();
            break;
        case 3:
            await GetClientById();
            break;
        case 4:
            await DisplayClients();
            break;
        default:
            WriteLine("Choix non valide !");
            break;
    }
} while (choice != 0);

Task DisplayClients()
{
    throw new NotImplementedException();
}

Task GetClientById()
{
    throw new NotImplementedException();
}

Task UpdateClient()
{
    throw new NotImplementedException();
}

async Task AddClient()
{
    var firstName = GetStringFromConsole("Entrez son prénom");
    var lastName = GetStringFromConsole("Entrez son nom");
    var birthDate = GetDateFromConsole("Entrez son date de naissance");
    var address = GetStringFromConsole("Entrez son adresse");
    var postalCode = GetStringFromConsole("Entrez son code postal");
    var ville = GetStringFromConsole("Entrez sa ville");

    var result = await clientController.CreateClient(firstName, lastName, birthDate, address, postalCode, ville);

    WriteLine(result);

    ReadKey();
}