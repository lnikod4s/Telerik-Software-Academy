using System;

namespace ClassSizeInCSharp
{
	public class Point
	{
		public Point(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}

		public double X { get; private set; }
		public double Y { get; private set; }

		public static Point RotatePoint(Point point, double rotatingAngle)
		{
			var newX = Math.Abs(Math.Cos(rotatingAngle)) * point.X +
						   Math.Abs(Math.Sin(rotatingAngle)) * point.Y;
			var newY = Math.Abs(Math.Sin(rotatingAngle)) * point.X +
							Math.Abs(Math.Cos(rotatingAngle)) * point.Y;

			return new Point(newX, newY);
		}
	}
}