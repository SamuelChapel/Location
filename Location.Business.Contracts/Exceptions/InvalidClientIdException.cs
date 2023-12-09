namespace Location.Business.Contracts.Exceptions;

public class InvalidClientIdException(int id) : Exception
{
	public override string Message => $"Le client avec l'id {id} n'existe pas";
}
