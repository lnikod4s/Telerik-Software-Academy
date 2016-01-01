using System;
/*Problem 5. The Biggest of 3 Numbers
--------------------------------------------------------
Write a program that finds the biggest of three numbers.
Examples:

a		b		c		biggest
5		2		2		5
-2		-2		1		1
-2		4		3		4
0		-2.5	5		5
-0.1	-0.5	-1.1	-0.1
*/

class Program
{
	static void Main()
	{
		decimal a = decimal.Parse(Console.ReadLine());
		decimal b = decimal.Parse(Console.ReadLine());
		decimal c = decimal.Parse(Console.ReadLine());
		
		decimal maxNumber = a;
		if (maxNumber < b) maxNumber = b;
		else if (maxNumber < c) maxNumber = c;
		Console.WriteLine(maxNumber);
	}
}