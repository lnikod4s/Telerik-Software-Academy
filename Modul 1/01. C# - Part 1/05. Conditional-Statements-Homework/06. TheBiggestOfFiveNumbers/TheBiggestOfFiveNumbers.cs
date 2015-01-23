using System;
using System.Linq;

/*Problem 6. The Biggest of Five Numbers
----------------------------------------------------------------------------------------
Write a program that finds the biggest of five numbers by using only five if statements.
Examples:

a		b		c		d		e		biggest
5		2		2		4		1		5
-2		-22		1		0		0		1
-2		4		3		2		0		4
0		-2.5	0		5		5		5
-3		-0.5	-1.1	-2		-0.1	-0.1
*/

class TheBiggestOfFiveNumbers
{
	static void Main()
	{
		decimal a = decimal.Parse(Console.ReadLine());
		decimal b = decimal.Parse(Console.ReadLine());
		decimal c = decimal.Parse(Console.ReadLine());
		decimal d = decimal.Parse(Console.ReadLine());
		decimal e = decimal.Parse(Console.ReadLine());

		decimal[] numbers = {a, b, c, d, e};
		Array.Sort(numbers);
		Console.WriteLine(numbers.Last());
	}
}