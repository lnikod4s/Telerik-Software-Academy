using System;
/*Problem 1. Say Hello
-------------------------------------------------------------------------
Write a method that asks the user for his name and prints “Hello, <name>”
Write a program to test this method.
Example:

input	output
Peter	Hello, Peter!
*/
class SayHello
{
	public static void Main()
	{
		Console.Write("Enter your first name: ");
		string input = Console.ReadLine();
		WriteInput(input);
	}

	public static string WriteInput(string input)
	{
		return string.Format("Hello, {0}!", input);
	}
}