using System;
using System.Linq;
/*Problem 4. Sub-string in text
------------------------------------------------------------------------------------------------------------------------
Write a program that finds how many times a sub-string is contained in a given text (perform case insensitive search).
Example:

The target sub-string is in

The text is as follows: We are living in an yellow submarine. We don't have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

The result is: 9
*/
class Program
{
	static void Main()
	{
		Console.Write("Enter a target substring: ");
		string target = Console.ReadLine();

		Console.WriteLine("Enter a text where we are going to looking for our target substring:");
		string text = Console.ReadLine();

		int count = text.Select((c, i) => text.Substring(i)).Count(sub => sub.StartsWith(target));
		Console.WriteLine(count);
	}
}