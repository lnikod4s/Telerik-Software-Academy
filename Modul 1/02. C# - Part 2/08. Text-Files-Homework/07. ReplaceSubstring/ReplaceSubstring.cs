using System.IO;
/*Problem 7. Replace sub-string
----------------------------------------------------------------------------------------------------------------
Write a program that replaces all occurrences of the sub-string start with the sub-string finish in a text file.
Ensure it will work with large files (e.g. 100 MB).
*/
class ReplaceSubstring
{
	static void Main()
	{
		const string PATH_TEXT = "../../text.txt";
		const string PATH_OUTPUT = "../../result.txt";

		ReplaceSubstrings(PATH_TEXT, PATH_OUTPUT);
	}

	static void ReplaceSubstrings(string pathText, string pathResult)
	{
		using (StreamWriter result = new StreamWriter(pathResult))
		{
			using (StreamReader reader = new StreamReader(pathText))
			{
				while (!reader.EndOfStream)
				{
					result.WriteLine(reader.ReadLine().Replace("start", "finish"));
				}
			}
		}
	}
}