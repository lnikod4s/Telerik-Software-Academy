using System;
using System.Collections.Generic;
using System.Linq;

/*Problem 12.* Zero Subset
-------------------------------------------------------------------------------------------------------
We are given 5 integer numbers. Write a program that finds all subsets of these numbers whose sum is 0.
Assume that repeating the same subset several times is not a problem.
Examples:

numbers			result
3 -2 1 1 8		-2 + 1 + 1 = 0
3 1 -7 35 22	no zero subset
1 3 -4 -2 -1	1 + -1 = 0
				1 + 3 + -4 = 0
				3 + -2 + -1 = 0
1 1 1 -1		-1	1 + -1 = 0
				1 + 3 + -4 = 0
				3 + -2 + -1 = 0
0 0 0 0 0		0 + 0 + 0 + 0 + 0 = 0
Hint: you may check for zero each of the 32 subsets with 32 if statements.
*/

class ZeroSubset
{
	private static void Main()
	{
		int a = int.Parse(Console.ReadLine());
		int b = int.Parse(Console.ReadLine());
		int c = int.Parse(Console.ReadLine());
		int d = int.Parse(Console.ReadLine());
		int e = int.Parse(Console.ReadLine());

		if (a + b + c + d + e == 0)
		{
			Console.WriteLine("The sum of " + a + " " + b + " " + c + " " + d + " " + e + " " + "is 0");
		}
		//4
		else if (a + b + c + d == 0)
		{
			Console.WriteLine("The sum of " + a + " " + b + " " + c + " " + d + " is 0");
		}
		else if (a + b + c + e == 0)
		{
			Console.WriteLine("The sum of " + a + " " + b + " " + c + " " + e + " is 0");
		}
		else if (a + b + d + e == 0)
		{
			Console.WriteLine("The sum of " + a + " " + b + " " + d + " " + e + " is 0");
		}
		else if (a + c + d + e == 0)
		{
			Console.WriteLine("The sum of " + a + " " + c + " " + d + " " + e + " is 0");
		}
		else if (b + c + d + e == 0)
		{
			Console.WriteLine("The sum of " + b + " " + c + " " + d + " " + e + " is 0");
		}
		//3
		else if (a + b + c == 0)
		{
			Console.WriteLine("The sum of " + a + " " + b + " " + c + " is 0");
		}
		else if (a + b + d == 0)
		{
			Console.WriteLine("The sum of " + a + " " + b + " " + d + " is 0");
		}
		else if (a + b + e == 0)
		{
			Console.WriteLine("The sum of " + a + " " + b + " " + e + " is 0");
		}
		else if (a + c + d == 0)
		{
			Console.WriteLine("The sum of " + a + " " + c + " " + d + " is 0");
		}
		else if (a + c + e == 0)
		{
			Console.WriteLine("The sum of " + a + " " + c + " " + e + " is 0");
		}
		else if (a + d + e == 0)
		{
			Console.WriteLine("The sum of " + a + " " + d + " " + e + " is 0");
		}
		else if (b + c + d == 0)
		{
			Console.WriteLine("The sum of " + b + " " + c + " " + d + " is 0");
		}
		else if (b + c + e == 0)
		{
			Console.WriteLine("The sum of " + b + " " + c + " " + e + " is 0");
		}
		else if (b + d + e == 0)
		{
			Console.WriteLine("The sum of " + b + " " + d + " " + e + " is 0");
		}
		else if (c + d + e == 0)
		{
			Console.WriteLine("The sum of " + c + " " + d + " " + e + " is 0");
		}
		//2
		else if (a + b == 0)
		{
			Console.WriteLine("The sum of " + a + " " + b + " is 0");
		}
		else if (a + c == 0)
		{
			Console.WriteLine("The sum of " + a + " " + c + " is 0");
		}
		else if (a + d == 0)
		{
			Console.WriteLine("The sum of " + a + " " + d + " is 0");
		}
		else if (a + e == 0)
		{
			Console.WriteLine("The sum of " + a + " " + e + " is 0");
		}
		else if (b + c == 0)
		{
			Console.WriteLine("The sum of " + b + " " + c + " is 0");
		}
		else if (b + d == 0)
		{
			Console.WriteLine("The sum of " + b + " " + d + " is 0");
		}
		else if (b + e == 0)
		{
			Console.WriteLine("The sum of " + b + " " + e + " is 0");
		}
		else if (c + d == 0)
		{
			Console.WriteLine("The sum of " + c + " " + d + " is 0");
		}
		else if (c + e == 0)
		{
			Console.WriteLine("The sum of " + c + " " + e + " is 0");
		}
		else if (d + e == 0)
		{
			Console.WriteLine("The sum of " + d + " " + e + " is 0");
		}
		else
		{
			Console.WriteLine("no zero subset");
		}
	}
}