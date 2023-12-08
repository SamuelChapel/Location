using Location.Business.Contracts;
using Location.Business.Contracts.Clients;

namespace Location.Controllers;

public class ClientController(IClientService clientService)
{
    private readonly IClientService _clientService = clientService;

    public async Task<string> CreateClient(
        string firstName,
        string lastName,
        DateTime birthDate,
        string address,
        string postalCode,
        string city)
    {
        var createClientDto = new CreateClientDto(
            firstName,
            lastName,
            birthDate,
            address,
            postalCode,
            city);

        try
        {
            var result = await _clientService.Create(createClientDto);

            return result.ToString();
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
            var clients = await _clientService.GetAllClients();

            return clients.Select(c => c.ToString()).ToList();
        }
        catch (Exception ex)
        {
            return [ex.Message];
        }
    }
}
