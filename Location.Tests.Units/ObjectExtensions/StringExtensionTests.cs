using Location.Repository.ObjectExtensions;

namespace DesignPatternV3.Tests.Units.ObjectExtensions;

public class StringExtensionTests
{
	[Theory]
	[InlineData(null)]
	[InlineData("")]
	public void ToCapitalize_WhenStringIsEmptyOrNull_ShouldReturnString(string str)
	{
		var result = str.ToCapitalize();

		Assert.Equal(result, str);
	}

	[Theory]
	[InlineData("TeStStRiNg", "Teststring")]
	[InlineData("tE St sTR iNg", "Te st str ing")]
	public void ToCapitalize_WhenStringIsValid_ShouldReturnStringCapitalized(string value, string exceptedResult)
	{
		var result = value.ToCapitalize();

		Assert.Equal(exceptedResult, result);
	}
}
