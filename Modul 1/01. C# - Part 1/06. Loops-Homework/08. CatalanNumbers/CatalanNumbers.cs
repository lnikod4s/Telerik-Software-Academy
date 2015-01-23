using System;
/*Problem 8. Catalan Numbers
----------------------------------------------------------------------------------------------
In combinatorics, the Catalan numbers are calculated by the following formula: catalan-formula
Write a program to calculate the nth Catalan number by given n (1 < n < 100).
Examples:

n	Catalan(n)
0	1
5	42
10	16796
15	9694845
*/

class CatalanNumbers
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());

		long calc = Factorial(2 * n) / (Factorial(n + 1) * Factorial(n));
		Console.WriteLine(calc);
	}

	static long Factorial(int i)
	{
		if (i <= 1)
			return 1;
		return i * Factorial(i - 1);
	}
}