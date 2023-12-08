namespace Location.Business.Contracts.Clients;

public record ClientDto(
    int Id,
    string FirstName,
    string LastName,
    DateTime BirthDate,
    string Address,
    string PostalCode,
    string City
    );
