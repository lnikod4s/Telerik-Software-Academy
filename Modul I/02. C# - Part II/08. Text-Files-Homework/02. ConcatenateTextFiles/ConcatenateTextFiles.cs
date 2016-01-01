using System;
using System.IO;
/*Problem 2. Concatenate text files
------------------------------------------------------------------------
Write a program that concatenates two text files into another text file.
*/
class ConcatenateTextFiles
{
	static void Main()
	{
		const string PATH_TEXT1 = "../../text1.txt";
		const string PATH_TEXT2 = "../../text2.txt";
		const string PATH_OUTPUT = "../../result.txt";

		ReadFileContent(PATH_TEXT1, PATH_OUTPUT);
		ReadFileContent(PATH_TEXT2, PATH_OUTPUT);

		PrintResultContent(PATH_OUTPUT);
	}

	static void ReadFileContent(string pathText, string pathResult)
	{
		using (StreamWriter result = new StreamWriter(pathResult, true))
		{
			using (StreamReader reader = new StreamReader(pathText))
			{
				while (!reader.EndOfStream) result.WriteLine(reader.ReadLine());
			}
		}
	}

	static void PrintResultContent(string path)
	{
		Console.WriteLine("> Result:\n");

		using (StreamReader reader = new StreamReader(path))
		{
			while (!reader.EndOfStream) Console.WriteLine(reader.ReadLine());
		}

		Console.WriteLine("\n> End of file...\n");
	}
}