using System;

namespace Abstraction
{
	internal class Rectangle : Figure
	{
		internal Rectangle()
			: base(0, 0) { }

		internal Rectangle(double width, double height)
			: base(width, height) { }

		internal double Width
		{
			get { return this.width; }
			set
			{
				if (value == null ||
				    value < 0)
				{
					throw new Exception("The width must be a positive integer value.");
				}

				this.width = value;
			}
		}

		internal double Height
		{
			get { return this.height; }
			set
			{
				if (value == null ||
				    value < 0)
				{
					throw new Exception("The height must be a positive integer value.");
				}

				this.height = value;
			}
		}

		internal double CalcPerimeter()
		{
			var perimeter = 2 * (this.Width + this.Height);
			return perimeter;
		}

		internal double CalcSurface()
		{
			var surface = this.Width * this.Height;
			return surface;
		}
	}
}