using System;
/*Problem 10. Point Inside a Circle & Outside of a Rectangle
---------------------------------------------------------------------------------------------------------------
Write an expression that checks for given point (x, y) if it is within the circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2).
Examples:

x		y		inside K & outside of R
1		2		yes
2.5		2		no
0		1		no
2.5		1		no
2		0		no
4		0		no
2.5		1.5		no
2		1.5		yes
1		2.5		yes
-100	-100	no
*/

class InsideACircleOutsideOfARectangle
{
	static void Main()
	{
		Console.WriteLine("Please enter the x coordinate: ");
		double x = double.Parse(Console.ReadLine());
		Console.WriteLine("Please enter the y coordinate: ");
		double y = double.Parse(Console.ReadLine());
		const double radius = 1.5;

		bool isInCircle = Math.Pow(x - 1, 2) + Math.Pow(y - 1, 2) <= Math.Pow(radius,2);
		bool isInRectangle = (x >= -1 && x <= 6) && (y >= 1 && y <= 2);
		Console.Write("Inside the circle and outside of the rectangle: ");
		Console.WriteLine(isInCircle && !isInRectangle);
	}
}