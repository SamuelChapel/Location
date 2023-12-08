namespace Location.Entities;

public class Client(
    int id,
    string firstName,
    string lastName,
    DateTime birthDate,
    string address,
    string postalCode,
    string city) : IEntityBase<int>
{
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public DateTime BirthDate { get; set; } = birthDate;
    public string Address { get; set; } = address;
    public string PostalCode { get; set; } = postalCode;
    public string City { get; set; } = city;
    public int Id { get; init; } = id;
}
