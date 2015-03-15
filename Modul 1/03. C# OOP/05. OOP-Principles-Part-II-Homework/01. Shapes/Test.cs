using System;
/*Problem 1. Shapes
Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.
Define two new classes Triangle and Rectangle that implement the virtual method and return the surface of the figure (heightwidth for rectangle and heightwidth/2 for triangle).
Define class Circle and suitable constructor so that at initialization height must be kept equal to width and implement the CalculateSurface() method.
Write a program that tests the behaviour of the CalculateSurface() method for different shapes (Circle, Rectangle, Triangle) stored in an array.
*/
namespace _01.Shapes
{
	class Test
	{
		static void Main()
		{
			var shapes = new Shape[]
						 {
							 new Circle(3.4),
							 new Triangle(2.67, 3.45),
							 new Rectangle(4.5, 5.89) 
						 };

			foreach (var shape in shapes)
			{
				Console.WriteLine("Surface of {0}: {1:F2}", shape.GetType().Name, shape.CalculateSurface());
			}
		}
	}
}
