using System;
/*Problem 1. Sum of 3 Numbers
--------------------------------------------------------------------------------
Write a program that reads 3 real numbers from the console and prints their sum.
Examples:

a		b		c		sum
3		4		11		18
-2		0		3		1
5.5		4.5		20.1	30.1
*/

class SumOfThreeNumbers
{
	static void Main()
	{
		Console.WriteLine("Please enter the first number: ");
		int a = int.Parse(Console.ReadLine());
		Console.WriteLine("Please enter the second number: ");
		int b = int.Parse(Console.ReadLine());
		Console.WriteLine("Please enter the third number: ");
		int c = int.Parse(Console.ReadLine());
		int sum = a + b + c;
		Console.Write("Sum: ");
		Console.WriteLine(sum);
	}
}