using System;
using System.Collections.Generic;
/*Problem 14. Word dictionary
-------------------------------------------------------------------------------------------
A dictionary is stored as a sequence of text lines containing words and their explanations.
Write a program that enters a word and translates it by using the dictionary.
Sample dictionary:

input		output
.NET		platform for applications from Microsoft
CLR			managed execution environment for .NET
namespace	hierarchical organization of classes
*/
class WordDictionary
{
	static void Main()
	{
		Dictionary<string, string> dict = new Dictionary<string, string>
		{
			{".NET", "platform for applications from Microsoft"},
			{"CLR", "managed execution environment for .NET"},
			{"NAMESPACE", "hierarchical organization of classes"}
		};

		Console.WriteLine("Dictionary words: {0}\n", string.Join(", ", dict.Keys));

		Console.Write("Enter a word to see its explanation: ");
		string word = Console.ReadLine().ToUpper();

		Console.WriteLine(dict.ContainsKey(word) ? string.Format("\n{0} -> {1}\n", word, dict[word])
						  : string.Format("\nDictionary does not contain word \"{0}\".\n", word));
	}
}