using Location.ViewConsole.Properties;
using static System.Console;

namespace Location.ViewConsole.Helpers;

public static class ConsoleHelper
{
	public static string GetStringFromConsole(string label = "Entrez la valeur")
	{
		Write(label + " : ");
		var input = ReadLine();

		while (string.IsNullOrWhiteSpace(input))
		{
			WriteLine("Entrée incorrecte, veuilllez réessayer");
			input = ReadLine();
		}

		return input;
	}

	public static int GetIntFromConsole(string label = "Entrez la valeur")
	{
		Write(label + " : ");
		int inputNumber;

		while (!int.TryParse(ReadLine(), out inputNumber))
		{
			Write("Ce n'est pas un nombre, veuillez réessayer : ");
		}

		return inputNumber;
	}

	public static DateTime GetDateFromConsole(string label = "Entrez la valeur")
	{
		Write(label + " : ");
		DateTime inputDate;

		while (!DateTime.TryParse(ReadLine(), out inputDate))
		{
			Write("Ce n'est pas une date, veuillez réessayer : ");
		}

		return inputDate;
	}

	public static int DisplayMenu(string title, params string[] options)
	{
		WriteLine("----- " + title + " -----\n");
		for (int i = 0; i < options.Length; i++)
		{
			WriteLine($"  {i + 1,2} : {options[i]}");
		}

		WriteLine($" {Resources.QuitChoice,2}\n");

		int choice;
		do
		{
			var input = ReadLine();
			if (!int.TryParse(input, out choice))
				choice = -1;
		} while (choice == -1 || choice < 0 || choice > options.Length);

		return choice;
	}

	public static void DisplayWaitKey()
	{
		Write("\n" + Resources.WaitKeyMessage);
		ReadKey();
	}
}
