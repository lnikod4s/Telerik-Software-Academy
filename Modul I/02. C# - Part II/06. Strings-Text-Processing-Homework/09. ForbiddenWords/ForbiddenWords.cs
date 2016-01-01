using System;
using System.Text.RegularExpressions;
/*Problem 9. Forbidden words
------------------------------------------------------------------------------------------------------------------------
We are given a string containing a list of forbidden words and a text containing some of these words.
Write a program that replaces the forbidden words with asterisks.
Example text: Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.

Forbidden words: PHP, CLR, Microsoft

The expected result: ********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.
*/
class ForbiddenWords
{
	static void Main()
	{
		Console.WriteLine("Enter a text: ");
		string text = Console.ReadLine();

		string[] blackList = { "PHP", "CLR", "Microsoft" };

		string regex = string.Format(@"\b({0})\b", string.Join("|", blackList));

		Console.WriteLine("Result: \n\n{0}\n", Regex.Replace(text, regex, word => new string('*', word.Length)));
	}
}