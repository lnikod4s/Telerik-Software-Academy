using System;
/*Problem 18.* Trailing Zeroes in N!
------------------------------------------------------------------------------------------------------
Write a program that calculates with how many zeroes the factorial of a given number n has at its end.
Your program should work well for very big numbers, e.g. n=100000.
Examples:

n		trailing zeroes of n!	explaination
10		2						3628800
20		4						2432902008176640000
100000	24999					think why
*/

class Program
{
	static void Main()
	{
		Console.Write("Enter a number: ");
		uint n = uint.Parse(Console.ReadLine());
		byte zerosN = 0;

		Console.Write("\nN = {0} -> {0}! -> ", n);
		for (int i = 5; i <= n; i *= 5)
		{
			zerosN += (byte)(n / i);
		}
		Console.WriteLine("{0} zeros\n", zerosN);
	}
}