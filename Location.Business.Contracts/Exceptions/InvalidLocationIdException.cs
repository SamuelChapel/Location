namespace Location.Business.Contracts.Exceptions;

public class InvalidLocationIdException(int id) : Exception
{
	public override string Message => $"La location avec l'id {id} n'existe pas";
}