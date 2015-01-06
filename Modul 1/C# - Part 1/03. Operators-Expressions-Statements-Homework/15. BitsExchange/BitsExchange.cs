using System;
/*Problem 15.* Bits Exchange
--------------------------------------------------------------------------------------------------------
Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.
Examples:

n				binary representation of n				binary result							result
1140867093		01000100 00000000 01000000 00010101		01000010 00000000 01000000 00100101		1107312677
255406592		00001111 00111001 00110010 00000000		00001000 00111001 00110010 00111000		137966136
4294901775		11111111 11111111 00000000 00001111		11111001 11111111 00000000 00111111		4194238527
5351			00000000 00000000 00010100 11100111		00000100 00000000 00010100 11000111		67114183
2369124121		10001101 00110101 11110111 00011001		10001011 00110101 11110111 00101001		2335569705
*/

class BitsExchange
{
	static void Main()
	{
		uint n = uint.Parse(Console.ReadLine());
		Console.WriteLine("BEFORE BITS EXCHANGE:");
		Console.WriteLine(new string('-', 60));
		Console.WriteLine("{0,-10} to binary -> {1}", n, Convert.ToString(n, 2).PadLeft(32, '0'));
		n = ExchangeBits(n);
		Console.WriteLine();
		Console.WriteLine("AFTER BITS EXCHANGE:");
		Console.WriteLine(new string('-', 60));
		Console.WriteLine("{0,-10} to binary -> {1}", n, Convert.ToString(n, 2).PadLeft(32, '0'));
		Console.WriteLine();
	}

	static uint ExchangeBits(uint number)
	{
		// 3, 4 and 5 bits
		byte first = (byte)((number >> 3) & 7); // ... & 111 (7 in dec) => gets 3 signs anytime

		// 24, 25, 26 bits
		byte second = (byte)((number >> 24) & 7); // ... & 111 (7 in dec) => gets 3 signs anytime

		// Example: 111 ^ 001 = 110
		// Intermediate point of comparison
		byte firstXORsecond = (byte)(first ^ second);

		number = (uint)(number ^ (firstXORsecond << 24));
		number = (uint)(number ^ (firstXORsecond << 3));

		return number;
	}
}