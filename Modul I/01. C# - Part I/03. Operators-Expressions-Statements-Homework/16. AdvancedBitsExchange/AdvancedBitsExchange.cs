using System;
/*Problem 16.** Bit Exchange (Advanced)
-----------------------------------------------------------------------------------------------------------------------
Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of a given 32-bit unsigned integer.
The first and the second sequence of bits may not overlap.
Examples:

p			q	k	binary representation of n	binary result						result
1140867093	3	24	3							01000100 00000000 01000000 00010101	01000010 00000000 01000000 00100101
4294901775	24	3	3							11111111 11111111 00000000 00001111	11111001 11111111 00000000 00111111
2369124121	2	22	10							10001101 00110101 11110111 00011001	01110001 10110101 11111000 11010001
987654321	2	8	11							-									-
123456789	26	0	7							-									-
33333333333	-1	0	33							-									-
*/

class AdvancedBitsExchange
{
	static void Main()
	{
		uint number = uint.Parse(Console.ReadLine());
		byte p = 1, q = 15; // steps = k
		const byte steps = 14; // steps = k

		byte[] numberToBinary = new byte[32];

		// Initialize array (number to binary), every cell contains 0 or 1
		for (int i = 0; i < numberToBinary.Length; i++)
		{
			numberToBinary[i] = (byte)(number % 2);
			number = number / 2;
		}

		Console.Write("Step 0   -> ");
		PrintBinaryNumber(numberToBinary);
		Console.WriteLine();

		for (int i = 0; i < steps; i++)
		{
			byte temp = numberToBinary[p];
			numberToBinary[p] = numberToBinary[q];
			numberToBinary[q] = temp;
			p++;
			q++;

			// Follow the steps
			Console.Write("Step {0,-3} -> ", i + 1);
			PrintBinaryNumber(numberToBinary);

			Console.WriteLine();
		}

		Console.WriteLine();
	}

	private static void PrintBinaryNumber(byte[] numberToBinary)
	{
		for (int j = numberToBinary.Length - 1; j >= 0; j--)
		{
			Console.Write(numberToBinary[j]);

			if ((j + 4) % 4 == 0)
				Console.Write(" ");
		}
	}
}