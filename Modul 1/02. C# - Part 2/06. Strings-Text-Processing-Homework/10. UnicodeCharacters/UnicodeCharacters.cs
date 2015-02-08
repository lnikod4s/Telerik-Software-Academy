using System;
using System.Linq;
/*Problem 10. Unicode characters
--------------------------------------------------------------------------------------
Write a program that converts a string to a sequence of C# Unicode character literals.
Use format strings.
Example:

input	output
Hi!		\u0048\u0069\u0021
*/
class UnicodeCharacters
{
	static void Main()
	{
		Console.Write("Enter a string: ");
		string word = Console.ReadLine();

		Console.WriteLine("\nResult -> {0}\n", ConvertToUnicode(word));
	}

	static string ConvertToUnicode(string word)
	{
		return word.Aggregate(string.Empty, (current, t) => current + string.Format(@"\n{0:X4}", (int) t));
	}
}