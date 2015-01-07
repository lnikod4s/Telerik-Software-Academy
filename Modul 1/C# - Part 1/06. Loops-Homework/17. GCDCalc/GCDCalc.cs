using System;
/*Problem 17.* Calculate GCD
------------------------------------------------------------------------------------------------
Write a program that calculates the greatest common divisor (GCD) of given two integers a and b.
Use the Euclidean algorithm (find it in Internet).
Examples:

a		b		GCD(a, b)
3		2		1
60		40		20
5		-15		5
*/

class GCDCalc
{
	static void Main()
	{
		Console.WriteLine("Enter two numbers:");
		Console.Write("   1: "); uint a = uint.Parse(Console.ReadLine());
		Console.Write("   2: "); uint b = uint.Parse(Console.ReadLine());

		while (a != b)
		{
			if (a > b)
				a = a - b;
			else
				b = b - a;
		}

		Console.WriteLine("\nGreatest common divisor: {0}\n", a);
	}
}