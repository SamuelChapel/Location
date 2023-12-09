namespace Location.Repository.ObjectExtensions;

public static class StringExtension
{
	public static string ToCapitalize(this string value)
		=> string.IsNullOrEmpty(value) ? value : char.ToUpper(value[0]) + value[1..].ToLower();
}
