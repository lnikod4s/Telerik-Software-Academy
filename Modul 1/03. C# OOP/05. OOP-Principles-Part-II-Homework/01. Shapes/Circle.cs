using System;

namespace _01.Shapes
{
	class Circle : Shape
	{
		public Circle(double diameter)
			: base(diameter, diameter) { }

		#region Overrides of Shape

		public override double CalculateSurface()
		{
			return Math.PI * this.Width * this.Height / 4;
		}

		#endregion
	}
}
