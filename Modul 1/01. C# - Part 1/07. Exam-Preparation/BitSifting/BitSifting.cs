// C# Basics Exam 11 April 2014 Morning
// Problem 5. Bit Sifting

using System;

class BitSifting
{
	static void Main()
	{
		ulong bits = ulong.Parse(Console.ReadLine());
		int N = int.Parse(Console.ReadLine());

		for (int i = 0; i < N; ++i)
		{
			ulong sieve = ulong.Parse(Console.ReadLine());
			bits &= ~sieve;
		}

		// Now count the bits
		ulong bitsCount = 0;
		while (bits > 0)
		{
			bitsCount += (bits & 1);
			bits >>= 1;
		}
		Console.WriteLine(bitsCount);
	}
}
