using System;
/*Problem 6. Quadratic Equation
------------------------------------------------------------------------------------------------------------------------
Write a program that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it (prints its real roots).
Examples:

a	b	c	roots
2	5	-3	x1=-3; x2=0.5
-1	3	0	x1=3; x2=0
-0.5	4	-8	x1=x2=4
5	2	8	no real roots
*/

class QuadraticEquation
{
	static void Main()
	{
		decimal a = decimal.Parse(Console.ReadLine());
		decimal b = decimal.Parse(Console.ReadLine());
		decimal c = decimal.Parse(Console.ReadLine());
		decimal D = b * b - 4 * a * c;

		if (a == 0)
		{
			Console.WriteLine("x={0}", -c / b);
		}
		else
		{
			if (D < 0)
			{
				Console.WriteLine("no real roots");
			}
			else if (D == 0)
			{
				Console.WriteLine("x1=x2={0}", (-b) / (2 * a));
			}
			else
			{
				Console.Write("x1={0}; ", (-b - (decimal)Math.Sqrt((double)D)) / (2 * a));
				Console.WriteLine("x2={0}", (-b + (decimal)Math.Sqrt((double)D)) / (2 * a));
			}
		}
	}
}