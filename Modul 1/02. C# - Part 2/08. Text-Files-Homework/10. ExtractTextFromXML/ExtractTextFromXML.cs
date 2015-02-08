using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
/*Problem 10. Extract text from XML
------------------------------------------------------------------------------------------------------------------------
Write a program that extracts from given XML file all the text without the tags.
Example:

<?xml version="1.0"><student><name>Pesho</name><age>21</age><interests count="3"><interest>Games</interest><interest>C#</interest><interest>Java</interest></interests></student>
*/
class ExtractTextFromXML
{
	static readonly StringBuilder textWithoutTags = new StringBuilder();
	static void Main()
	{
		const string PATH_TEXT = "../../text.xml";

		ExtractTextWithoutTags(PATH_TEXT);

		Console.WriteLine(textWithoutTags);
	}

	static void ExtractTextWithoutTags(string pathTextFile)
	{
		using (StreamReader reader = new StreamReader(pathTextFile))
		{
			while (!reader.EndOfStream)
			{
				string line = Regex.Replace(reader.ReadLine(), @"<[^>]*>", String.Empty).Trim();
				if (line != "")
				{
					textWithoutTags.AppendLine(line);
				}
			}
		}
	}
}