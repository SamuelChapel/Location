namespace Location.Business.Contracts.Exceptions;

public class InvalidDateLocationException : Exception
{
	public override string Message => "Dates de location invalide";
}
