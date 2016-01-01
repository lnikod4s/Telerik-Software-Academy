using System;
/*Problem 8. Square Root
--------------------------------------------------------------------------------------------
Create a console application that calculates and prints the square root of the number 12345.
Find in Internet “how to calculate square root in C#”.
*/ 

class SquareRoot
{
	static void Main()
	{
		decimal result = (decimal)Math.Sqrt(12345);
		Console.WriteLine(result);
	}
}