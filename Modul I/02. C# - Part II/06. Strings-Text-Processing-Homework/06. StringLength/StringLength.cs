using System;
/*Problem 6. String length
------------------------------------------------------------------------------------------------------------------------
Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the characters should be filled with *.
Print the result string into the console.
*/
class StringLength
{
	static void Main()
	{
		Console.Write("Enter a sequence of characters with max lenght 20: ");
		string text = Console.ReadLine();

		if (text.Length <= 20)
		{
			text = text.PadRight(20, '*');
			Console.WriteLine(text);
		}
		else
		{
			Console.WriteLine("The lenght of your string must be max 20.");
		}
	}
}