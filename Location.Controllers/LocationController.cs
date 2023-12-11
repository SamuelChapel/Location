using Location.Business.Contracts.Services;

namespace Location.Controllers;

public class LocationController(ILocationService locationService)
{
    private readonly ILocationService _locationService = locationService;

    public async Task<string> GetById(int id)
    {
        try
        {
            var location = await _locationService.GetById(id);

            return location?.ToString() ?? $"La location avec l'id {id} non trouvé";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public async Task<List<string>> GetByClientId(int id)
    {
        try
        {
            var locations = await _locationService.GetByClientId(id);

            return locations.Select(location => location.ToString()).ToList();
        }
        catch (Exception ex)
        {
            return [ex.Message];
        }
    }

    public async Task<List<string>> GetAll()
    {
        try
        {
            var locations = await _locationService.GetAll();

            return locations.Select(location => location.ToString()).ToList();
        }
        catch (Exception ex)
        {
            return [ex.Message];
        }
    }

    public async Task<string> Create(
        int? id_Client,
        int? id_Vehicule,
        int distance,
        DateTime startDate,
        DateTime endDate
        )
    {
        var location = new Entities.Entities.Location()
        {
            Id_Client = id_Client,
            Id_Vehicule = id_Vehicule,
            Nb_Km = distance,
            Date_Debut = startDate,
            Date_Fin = endDate
        };

        try
        {
            var result = await _locationService.Create(location);

            return result > 0 ? $"La location à bien été créé" : "Erreur : location non créé";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public async Task<string> Update(
        int id,
        int? id_Client,
        int? id_Vehicule,
        int distance,
        DateTime startDate,
        DateTime endDate
        )
    {
        var location = new Entities.Entities.Location()
        {
            Id = id,
            Id_Client = id_Client,
            Id_Vehicule = id_Vehicule,
            Nb_Km = distance,
            Date_Debut = startDate,
            Date_Fin = endDate
        };

        try
        {
            var result = await _locationService.Update(location);

            return result > 0 ? $"La location à bien été mise à jour" : "Erreur : location non mise à jour";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public async Task<string> Delete(int id)
    {
        try
        {
            var result = await _locationService.Delete(id);

            return result > 0 ? $"La location à bien été supprimée" : "Erreur : location non supprimée";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
