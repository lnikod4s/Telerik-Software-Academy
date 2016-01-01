using System;
using System.Numerics;
/*Problem 10. Fibonacci Numbers
------------------------------------------------------------------------------------------------------------------------
Write a program that reads a number n and prints on the console the first n members of the Fibonacci sequence (at a single line, separated by comma and space - ,) : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….
Note: You may need to learn how to use loops.

Examples:

n	comments
1	0
3	0 1 1
10	0 1 1 2 3 5 8 13 21 34
*/

class FibonacciNumbers
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		BigInteger first = 0;
		BigInteger second = 1;
		BigInteger third = 0;

		for (int i = 0; i < n; i++)
		{
			Console.Write(third + (i == n - 1 ? "\n" : ", "));
			first = second;
			second = third;
			third = first + second;
		}
	}
}