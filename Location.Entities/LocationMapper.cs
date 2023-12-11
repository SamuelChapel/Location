using LocationEntity = Location.Entities.Entities.Location;
using LocationModel = Location.Entities.Models.Location;

namespace Location.Entities;

public static class LocationMapper
{
    public static LocationModel ToModel(this LocationEntity location)
    {
        return new LocationModel()
        {
            Id = location.Id,
            IdClient = location.Id_Client,
            IdVehicule = location.Id_Vehicule,
            NbKm = location.Nb_Km,
            DateDebut = location.Date_Debut,
            DateFin = location.Date_Fin
        };
    }

    public static LocationEntity ToEntity(this LocationModel location)
    {
        return new LocationEntity()
        {
            Id = location.Id,
            Id_Client = location.IdClient,
            Id_Vehicule = location.IdVehicule,
            Nb_Km = location.NbKm,
            Date_Debut = location.DateDebut,
            Date_Fin = location.DateFin
        };
    }
}
