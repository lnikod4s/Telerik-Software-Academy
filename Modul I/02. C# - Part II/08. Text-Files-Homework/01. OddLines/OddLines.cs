using System;
using System.IO;
/*Problem 1. Odd lines
-------------------------------------------------------------------------------
Write a program that reads a text file and prints on the console its odd lines.
*/
class OddLines
{
	static void Main()
	{
		const string PATH = "../../OddLines.txt";

		Console.WriteLine("> Prints odd lines of text file...\n");

		using (StreamReader reader = new StreamReader(PATH))
		{
			int lineCount = 1;

			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();

				if (lineCount++ % 2 != 0) Console.WriteLine(line);
			}
		}
	}
}