namespace Location.Entities;

public class Client : IEntityBase<int>
{
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public DateTime BirthDate { get; set; } = DateTime.MinValue;
	public string Address { get; set; } = null!;
	public string PostalCode { get; set; } = null!;
	public string City { get; set; } = null!;
	public int Id { get; init; }

	public override string ToString()
	{
		return $"{Id} {FirstName,15} {LastName,15} {BirthDate}\n{Address,30} {PostalCode,5} {City,15}";
	}
}
