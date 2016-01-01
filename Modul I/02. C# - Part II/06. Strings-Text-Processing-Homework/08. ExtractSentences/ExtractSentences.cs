using System;
using System.Text.RegularExpressions;

/*Problem 8. Extract sentences
------------------------------------------------------------------------------------------------------------------------
Write a program that extracts from a given text all sentences containing given word.
Example:

The word is: in

The text is: We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

The expected result is: We are living in a yellow submarine. We will move out of it in 5 days.

Consider that the sentences are separated by . and the words – by non-letter symbols.
*/
class ExtractSentences
{
	static void Main()
	{
		Console.WriteLine("Enter a text:");
		string text = Console.ReadLine();

		Console.Write("Enter a word that we are going to looking for in the text: ");
		string word = Console.ReadLine();

		string[] sentences = text.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

		Console.WriteLine("\nSentences containing word [{0}]:\n", word);

		for (int i = 0; i < sentences.Length; i++)
		{
			if (IsSentenceContainsWord(sentences, i, word))
			{
				Console.WriteLine(sentences[i].Trim() + ".");
			}
		}

		Console.WriteLine();
	}

	private static bool IsSentenceContainsWord(string[] sentences, int index, string word)
	{
		return Regex.Matches(sentences[index], string.Format(@"\b{0}\b", word), RegexOptions.IgnoreCase).Count != 0;
	}
}