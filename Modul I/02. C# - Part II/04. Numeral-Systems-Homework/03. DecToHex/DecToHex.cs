using System;
/*Problem 3. Decimal to hexadecimal
-------------------------------------------------------------------------------
Write a program to convert decimal numbers to their hexadecimal representation.
*/
class DecToHex
{
	static void Main()
	{
		string number = Console.ReadLine();
		int decimalNumber = int.Parse(number);

		string hexadecimalRepresentation = null;
		while (decimalNumber != 0)
		{
			char character = ' ';
			var remainder = (byte)(decimalNumber % 16);
			if ((remainder >= 0) && (remainder <= 9))
			{
				character = (char)(remainder - '0');
			}
			else
			{
				switch (remainder)
				{
					case 10:
						character = 'A';
						break;
					case 11:
						character = 'B';
						break;
					case 12:
						character = 'C';
						break;
					case 13:
						character = 'D';
						break;
					case 14:
						character = 'E';
						break;
					case 15:
						character = 'F';
						break;
				}
			}
			// Save hexadecimal representation
			hexadecimalRepresentation = character + hexadecimalRepresentation;
			decimalNumber = decimalNumber / 16;
		}
		Console.WriteLine(hexadecimalRepresentation);
	}
}