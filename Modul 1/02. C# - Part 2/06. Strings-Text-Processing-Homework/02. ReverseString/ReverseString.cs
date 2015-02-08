using System;
using System.Linq;
/*Problem 2. Reverse string
--------------------------------------------------------------------------------------
Write a program that reads a string, reverses it and prints the result at the console.
Example:

input	output
sample	elpmas
*/
class ReverseString
{
	static void Main()
	{
		Console.Write("Enter a random sequence of characters: ");
		string input = Console.ReadLine();

		string output = new string(input.Reverse().ToArray());
		Console.WriteLine(output);
	}
}