using System;
using System.Text.RegularExpressions;
/*Problem 15. Replace tags
------------------------------------------------------------------------------------------------------------------------
Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].
Example:

Input: <p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>

Output: <p>Please visit [URL=http://academy.telerik. com]our site[/URL] to choose a training course. Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>
*/
class ReplaceTags
{
	static void Main()
	{
		const string HTML = @"<p>Please visit <a href=""http://academy.telerik.com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";

		Console.WriteLine(Regex.Replace(HTML, @"<a href=""(.*?)"">(.*?)</a>", @"[URL=$1]$2[/URL]"));
	}
}