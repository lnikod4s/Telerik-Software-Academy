using System;
using System.Text.RegularExpressions;
/*Problem 25. Extract text from HTML
------------------------------------------------------------------------------------------------------------------------
Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.
Example input:

<html>
  <head><title>News</title></head>
  <body><p><a href="http://academy.telerik.com">Telerik
	Academy</a>aims to provide free real-world practical
	training for young people who want to turn into
	skilful .NET software engineers.</p></body>
</html>
Output:

Title: News

Text: Telerik Academy aims to provide free real-world practical training for young people who want to turn into skilful .NET software engineers.
*/
class ExtractTextFromHTML
{
	static void Main()
	{
		const string htmlDoc = @"<html><head><title>News</title></head><body><p><a href=""http://academy.telerik.com"">Telerik Academy</a>aims to provide free real-world practical training for young people who want to turn into skillful .NET software engineers.</p></body></html>";

		foreach (Match item in Regex.Matches(htmlDoc, "(?<=^|>)[^><]+?(?=<|$)"))
		{
			Console.WriteLine(item);
		}

		Console.WriteLine();
	}
}