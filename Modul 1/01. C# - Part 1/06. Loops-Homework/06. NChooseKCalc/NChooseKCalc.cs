using System;
/*Problem 6. Calculate N! / K!
----------------------------------------------------------------------------
Write a program that calculates n! / k! for given n and k (1 < k < n < 100).
Use only one loop.
Examples:

n	k	n! / k!
5	2	60
6	5	6
8	3	6720
*/

class NChooseKCalc
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		int k = int.Parse(Console.ReadLine());

		decimal calc = Factorial(n) / (decimal) Factorial(k);
		Console.WriteLine(calc);
	}

	static int Factorial(int i)
	{
		if (i <= 1)
			return 1;
		return i * Factorial(i - 1);
	}
}