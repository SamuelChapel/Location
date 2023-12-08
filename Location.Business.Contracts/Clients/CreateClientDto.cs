namespace Location.Business.Contracts.Clients;

public record CreateClientDto(
    string FirstName,
    string LastName,
    DateTime BirthDate,
    string Address,
    string PostalCode,
    string City
    );
