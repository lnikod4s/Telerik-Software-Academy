using System;
/*Problem 13. Binary to Decimal Number
--------------------------------------------------------------------------------------
Using loops write a program that converts a binary integer number to its decimal form.
The input is entered as string. The output should be a variable of type long.
Do not use the built-in .NET functionality.
Examples:

binary							decimal
0								0
11								3
1010101010101011				43691
1110000110000101100101000000	236476736
*/

class BinToDec
{
	static void Main()
	{
		string bin = Console.ReadLine();
		
		var dec = 0;
		for (int i = 0; i < bin.Length; i++)
		{
			// we start with the least significant digit, and work our way to the left
			if (bin[bin.Length - i - 1] == '0') continue;
			dec += (int)Math.Pow(2, i);
		}
		Console.WriteLine(dec);
	}
}