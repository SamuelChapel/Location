namespace Location.Entities;

public class Location(int id,
                      int distance,
                      DateTime startDate,
                      DateTime endDate) : IEntityBase<int>
{
    public int Id { get; init; } = id;
    public int Distance { get; set; } = distance;
    public DateTime StartDate { get; set; } = startDate;
    public DateTime EndDate { get; set; } = endDate;
}
