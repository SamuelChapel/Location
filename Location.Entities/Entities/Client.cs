﻿using Location.Entities.Base;
using ClientModel = Location.Entities.Models.Client;

namespace Location.Entities.Entities;

public class Client : IEntity<int>
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public string Prenom { get; set; } = null!;
    public DateTime Date_Naissance { get; set; } = DateTime.MinValue;
    public string? Adresse { get; set; } = null!;
    public string? Code_Postal { get; set; } = null!;
    public string? Ville { get; set; } = null!;

    public override string ToString()
    {
        return $"{Id,3}\t{Prenom,-15} {Nom,-15} {Date_Naissance.ToShortDateString(),-15} {Adresse,-30} {Code_Postal,-10} {Ville,-15}";
    }

    public static ClientModel ToModel(Client client)
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
}
