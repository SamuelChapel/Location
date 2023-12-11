namespace Location.Tests.Common.Builders;

public class LocationBuilder
{
    private int _id = 0;
    private int? _id_Client = null;
    private int? _id_Vehicule = null;
    private int _nb_Km = 0;
    private DateTime _date_Debut = DateTime.MinValue;
    private DateTime? _date_Fin = null;

    public static LocationBuilder ALocation => new();

    public LocationBuilder WithId(int id)
    {
        _id = id;
        return this;
    }

    public LocationBuilder WithIdClient(int id)
    {
        _id_Client = id;
        return this;
    }

    public LocationBuilder WithIdVehicle(int id)
    {
        _id_Vehicule = id;
        return this;
    }

    public LocationBuilder WithStartDate(DateTime date)
    {
        _date_Debut = date;
        return this;
    }

    public LocationBuilder WithEndDate(DateTime date)
    {
        _date_Fin = date;
        return this;
    }

    public LocationBuilder WithDistance(int distance)
    {
        _nb_Km = distance;
        return this;
    }

    public Entities.Entities.Location Build()
    {
        var location = new Entities.Entities.Location()
        {
            Id = _id,
            Date_Debut = _date_Debut,
            Date_Fin = _date_Fin,
            Id_Client = _id_Client,
            Id_Vehicule = _id_Vehicule,
            Nb_Km = _nb_Km
        };
        return location;
    }
}
