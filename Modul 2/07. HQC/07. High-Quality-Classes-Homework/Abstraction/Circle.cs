using System;

namespace Abstraction
{
	internal class Circle : Figure
	{
		internal Circle() : base(0) { }
		internal Circle(double radius) : base(radius) { }

		internal double Radius
		{
			get { return this.radius; }
			set
			{
				if (value == null ||
				    value < 0)
				{
					throw new Exception("The radius must be a positive integer value.");
				}

				this.radius = value;
			}
		}

		internal double CalcPerimeter()
		{
			var perimeter = 2 * Math.PI * this.Radius;
			return perimeter;
		}

		internal double CalcSurface()
		{
			var surface = Math.PI * this.Radius * this.Radius;
			return surface;
		}
	}
}