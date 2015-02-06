using System;
using System.Linq;
/*Problem 6. binary to hexadecimal
----------------------------------------------------------------------------
Write a program to convert binary numbers to hexadecimal numbers (directly).
*/
class BinToHex
{
	static void Main()
	{
		string binaryRepresentation = Console.ReadLine();

		// Clear binary representation
		string clearBinaryRepresentation = null;
		for (int i = 0; i < binaryRepresentation.Length; i++)
		{
			if (binaryRepresentation[i] == '1')
			{
				for (int j = i; j < binaryRepresentation.Length; j++)
				{
					clearBinaryRepresentation = binaryRepresentation[j] + clearBinaryRepresentation;
				}

				break;
			}
		}

		// Reversing the binary representation
		string reversedBinaryRepresentation = clearBinaryRepresentation.Aggregate<char, string>(null, (current, t) => t + current);

		string hexadecimalRepresentation = null;
		int countOfBits = reversedBinaryRepresentation.Length;
		int bitPosition = 0;

		while (bitPosition < countOfBits)
		{
			// Convert from binary to decimal numeral system
			byte decimalRepresentation = 0;
			for (int i = 0; i < 4; i++)
			{
				if (bitPosition >= countOfBits)
				{
					break;
				}

				// Calculating of Power.
				int multiplier = 1;
				for (int j = 0; j < i; j++)
				{
					multiplier = multiplier * 2;
				}

				if (reversedBinaryRepresentation[bitPosition] == '1')
				{
					decimalRepresentation = (byte)(decimalRepresentation + multiplier);
				}

				bitPosition++;
			}

			// Convert from Decimal to Hexadecimal representation
			char symbol = ' ';
			if ((decimalRepresentation >= 0) && (decimalRepresentation <= 9))
			{
				symbol = (char)(decimalRepresentation + '0');
			}
			else
			{
				switch (decimalRepresentation)
				{
					case 10:
						symbol = 'A';
						break;
					case 11:
						symbol = 'B';
						break;
					case 12:
						symbol = 'C';
						break;
					case 13:
						symbol = 'D';
						break;
					case 14:
						symbol = 'E';
						break;
					case 15:
						symbol = 'F';
						break;
				}
			}

			hexadecimalRepresentation = symbol + hexadecimalRepresentation;
		}
		Console.WriteLine(hexadecimalRepresentation);
	}
}
