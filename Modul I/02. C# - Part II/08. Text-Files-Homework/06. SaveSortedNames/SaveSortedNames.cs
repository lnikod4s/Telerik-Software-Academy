using System;
using System.Collections.Generic;
using System.IO;
/*Problem 6. Save sorted names
--------------------------------------------------------------------------------------------------------------------
Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.
Example:

input.txt	output.txt
Ivan		George
Peter		Ivan	
Maria		Maria
George		Peter
*/
class SaveSortedNames
{
	static readonly List<string> strings = new List<string>();
	static void Main()
	{
		const string PATH_TEXT = "../../names.txt";
		const string PATH_OUTPUT = "../../result.txt";

		SeparateStringsFromTextFile(PATH_TEXT);

		Console.WriteLine("Names: {0}", string.Join(", ", strings));

		strings.Sort();
		SaveSortedStringsToTextFile(PATH_OUTPUT);

		Console.WriteLine("\nSorted names: {0}\n", string.Join(", ", strings));
	}

	static void SeparateStringsFromTextFile(string pathText)
	{
		using (StreamReader reader = new StreamReader(pathText))
		{
			while (!reader.EndOfStream)
			{
				string[] tokens = reader.ReadLine().Split(new[] { ' ', ',', '\n' },
					StringSplitOptions.RemoveEmptyEntries);

				foreach (string t in tokens)
				{
					strings.Add(t);
				}
			}
		}
	}

	static void SaveSortedStringsToTextFile(string pathResult)
	{
		using (StreamWriter result = new StreamWriter(pathResult))
		{
			foreach (string t in strings)
			{
				result.WriteLine(t);
			}
		}
	}
}