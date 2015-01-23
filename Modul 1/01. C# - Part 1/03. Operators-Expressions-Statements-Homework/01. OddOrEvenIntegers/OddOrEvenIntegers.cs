using System;
/*Problem 1. Odd or Even Integers
----------------------------------------------------------------
Write an expression that checks if given integer is odd or even.
Examples:

n	Odd?
3	true
2	false
-2	false
-1	true
0	false
*/

class OddOrEvenIntegers
{
	static void Main()
	{
		Console.WriteLine("Please enter a positive or a negative number: ");
		int number = int.Parse(Console.ReadLine());
		bool isEven = number % 2 == 0;
		Console.WriteLine("Odd?");
		Console.WriteLine(isEven);
	}
}