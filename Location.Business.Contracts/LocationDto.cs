namespace Location.Business.Contracts;

public record LocationDto(
    int Id,
    int Distance,
    DateTime StartDate,
    DateTime EndDate);
