using System;
/*Problem 4. Number Comparer
--------------------------------------------------------------------------------------
Write a program that gets two numbers from the console and prints the greater of them.
Try to implement this without if statements.
Examples:

a		b		greater
5		6		6
10		5		10
0		0		0
-5		-2		-2
1.5		1.6		1.6
a		a		a
*/

class NumberComparer
{
	static void Main()
	{
		Console.WriteLine("Please enter a number a: ");
		double a = double.Parse(Console.ReadLine());
		Console.WriteLine("Please enter a number b: ");
		double b = double.Parse(Console.ReadLine());
		Console.Write("Greater: ");
		Console.WriteLine(a > b ? a : b);
	}
}