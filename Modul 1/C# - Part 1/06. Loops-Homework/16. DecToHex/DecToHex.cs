using System;
using System.Text;

/*Problem 16. Decimal to Hexadecimal Number
----------------------------------------------------------------------------------------------
Using loops write a program that converts an integer number to its hexadecimal representation.
The input is entered as long. The output should be a variable of type string.
Do not use the built-in .NET functionality.
Examples:

decimal			hexadecimal
254				FE
6883			1AE3
338583669684	4ED528CBB4
*/

class DecToHex
{
	static void Main()
	{
		long dec = long.Parse(Console.ReadLine());
		string hex = ToHexString(dec);
		Console.WriteLine(hex);
	}

	private static string ToHexString(long dec)
	{
		var sb = new StringBuilder();
		while (dec > 1)
		{
			var r = dec % 16;
			dec /= 16;
			sb.Insert(0, ((int)r).ToString("X"));
		}
		return sb.ToString();
	}
}