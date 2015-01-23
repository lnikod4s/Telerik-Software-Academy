using System;
/*Problem 15. Hexadecimal to Decimal Number
-------------------------------------------------------------------------------------------
Using loops write a program that converts a hexadecimal integer number to its decimal form.
The input is entered as string. The output should be a variable of type long.
Do not use the built-in .NET functionality.
Examples:

hexadecimal		decimal
FE				254
1AE3			6883
4ED528CBB4		338583669684
*/

class HexToDec
{
	static void Main()
	{
		string hex = Console.ReadLine();
		long dec = Convert(hex);
		Console.WriteLine(dec);
	}

	static readonly sbyte[] unhex_table =
	{ -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
	   ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
	   ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
	   , 0, 1, 2, 3, 4, 5, 6, 7, 8, 9,-1,-1,-1,-1,-1,-1
	   ,-1,10,11,12,13,14,15,-1,-1,-1,-1,-1,-1,-1,-1,-1
	   ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
	   ,-1,10,11,12,13,14,15,-1,-1,-1,-1,-1,-1,-1,-1,-1
	   ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
	};

	private static long Convert(string hexNumber)
	{
		int decValue = unhex_table[(byte)hexNumber[0]];
		for (int i = 1; i < hexNumber.Length; i++)
		{
			decValue *= 16;
			decValue += unhex_table[(byte)hexNumber[i]];
		}
		return decValue;
	}
}