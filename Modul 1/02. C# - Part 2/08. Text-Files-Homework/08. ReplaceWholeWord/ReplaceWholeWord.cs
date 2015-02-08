using System.IO;
using System.Text.RegularExpressions;
/*Problem 8. Replace whole word
--------------------------------------------------------------------------------------
Modify the solution of the previous problem to replace only whole words (not strings).
*/
class ReplaceWholeWord
{
	static void Main()
	{
		const string PATH_TEXT = "../../text.txt";
		const string PATH_OUTPUT = "../../result.txt";

		ReplaceAllWholeWords(PATH_TEXT, PATH_OUTPUT);
	}

	static void ReplaceAllWholeWords(string pathText, string pathResult)
	{
		using (StreamWriter result = new StreamWriter(pathResult))
		{
			using (StreamReader reader = new StreamReader(pathText))
			{
				while (!reader.EndOfStream)
				{
					result.WriteLine(Regex.Replace(reader.ReadLine(), @"\bstart\b", "finish"));
				}
			}
		}
	}
}