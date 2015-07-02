using System;

namespace ClassSizeInCSharp
{
	public class Figure
	{
		private readonly double height;
		private readonly double width;

		public Figure(double width, double height)
		{
			this.width = width;
			this.height = height;
		}

		public static Figure GetNewFigureAfterRotating(Figure figure, double rotatingAngle)
		{
			var newWidth = Math.Abs(Math.Cos(rotatingAngle)) * figure.width +
			               Math.Abs(Math.Sin(rotatingAngle)) * figure.height;
			var newHeight = Math.Abs(Math.Sin(rotatingAngle)) * figure.width +
			                Math.Abs(Math.Cos(rotatingAngle)) * figure.height;

			return new Figure(newWidth, newHeight);
		}

		private static void Main() { }
	}
}