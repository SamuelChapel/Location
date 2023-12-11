using ClientEntity = Location.Entities.Entities.Client;
using ClientModel = Location.Entities.Models.Client;

namespace Location.Entities;

public static class ClientMapper
{
    public static ClientModel ToModel(this ClientEntity client)
    {
        return new ClientModel()
        {
            Id = client.Id,
            Nom = client.Nom,
            Prenom = client.Prenom,
            Adresse = client.Adresse,
            CodePostal = client.Code_Postal,
            Ville = client.Ville,
            DateNaissance = client.Date_Naissance
        };
    }

    public static ClientEntity ToEntity(this ClientModel client)
    {
        return new ClientEntity()
        {
            Id = client.Id,
            Nom = client.Nom,
            Prenom = client.Prenom,
            Adresse = client.Adresse,
            Code_Postal = client.CodePostal,
            Ville = client.Ville,
            Date_Naissance = client.DateNaissance
        };
    }
}
