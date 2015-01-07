using System;
/*Problem 4. Multiplication Sign

Write a program that shows the sign (+, - or 0) of the product of three real numbers, without calculating it.
Use a sequence of if operators.
Examples:

a		b		c		result
5		2		2		+
-2		-2		1		+
-2		4		3		-
0		-2.5	4		0
-1		-0.5	-5.1	-
*/

class MultiplicationSign
{
	static void Main()
	{
		decimal a = decimal.Parse(Console.ReadLine());
		decimal b = decimal.Parse(Console.ReadLine());
		decimal c = decimal.Parse(Console.ReadLine());

		if (a > 0 && b > 0 && c > 0)
		{
			Console.WriteLine("+");
		}
		else if (a < 0 && b < 0 && c < 0)
		{
			Console.WriteLine("-");
		}
		else if (a == 0 || b == 0 || c == 0)
		{
			Console.WriteLine("0");
		}
		else if (a > 0 && b > 0 && c < 0)
		{
			Console.WriteLine("-");
		}
		else if (a > 0 && b < 0 && c < 0)
		{
			Console.WriteLine("+");
		}
		else if (a > 0 && b < 0 && c > 0)
		{
			Console.WriteLine("-");
		}
		else if (a < 0 && b < 0 && c > 0)
		{
			Console.WriteLine("+");
		}
		else if (a < 0 && b > 0 && c < 0)
		{
			Console.WriteLine("+");
		}
	}
}