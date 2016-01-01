using System;
using System.Linq;

/*Problem 7. Point in a Circle
--------------------------------------------------------------------------------------
Write an expression that checks if given point (x, y) is inside a circle K({0, 0}, 2).
Examples:

x		y		inside
0		1		true
-2		0		true
-1		2		false
1.5		-1		true
-1.5	-1.5	false
100		-30		false
0		0		true
0.2		-0.8	true
0.9		-1.93	false
1		1.655	true
*/

class PointInACircle
{
	static void Main()
	{
		Console.WriteLine("Please enter a point (x,y) in format x,y: ");
		string input = Console.ReadLine();
		int[] entryPoints = input.Split(',').Select(int.Parse).ToArray();
		int x = entryPoints[0];
		int y = entryPoints[1];
		bool isInside = Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(2, 2);
		Console.Write("Inside: ");
		Console.WriteLine(isInside);
	}
}