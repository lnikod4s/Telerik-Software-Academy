using System;
/*Problem 9. Trapezoids
-----------------------------------------------------------------------------------------
Write an expression that calculates trapezoid's area by given sides a and b and height h.
Examples:

a		b		h		area
5		7		12		72
2		1		33		49.5
8.5		4.3		2.7		17.28
100		200		300		45000
0.222	0.333	0.555	0.1540125
*/

class Trapezoids
{
	static void Main()
	{
		Console.WriteLine("Please enter the side a: ");
		decimal a = decimal.Parse(Console.ReadLine());
		Console.WriteLine("Please enter the side b: ");
		decimal b = decimal.Parse(Console.ReadLine());
		Console.WriteLine("Please enter the height h: ");
		decimal h = decimal.Parse(Console.ReadLine());
		decimal area = ((a + b) * h) / 2;
		Console.Write("Area: ");
		Console.WriteLine(area);
	}
}
