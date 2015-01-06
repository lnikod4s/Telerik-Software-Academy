using System;
/*Problem 3. Circle Perimeter and Area
------------------------------------------------------------------------------------------------------------------------
Write a program that reads the radius r of a circle and prints its perimeter and area formatted with 2 digits after the decimal point.
Examples:

r		perimeter		area
2		12.57			12.57
3.5		21.99			38.48
*/

class CirclePerimeterAndArea
{
	static void Main()
	{
		Console.WriteLine("Please enter a radius r: ");
		decimal r = decimal.Parse(Console.ReadLine());
		decimal perimeter = 2 * (decimal)Math.PI * r;
		decimal area = (decimal) (Math.PI * Math.Pow((double)r, 2));
		Console.WriteLine("Perimeter: {0:F2}", perimeter);
		Console.WriteLine("Area: {0:F2}", area);

	}
}