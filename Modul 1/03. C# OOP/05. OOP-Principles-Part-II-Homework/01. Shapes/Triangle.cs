namespace _01.Shapes
{
	class Triangle : Shape
	{
		public Triangle(double width, double height)
			: base(width, height) { }

		#region Overrides of Shape

		public override double CalculateSurface()
		{
			return (this.Height * this.Width) / 2;
		}

		#endregion
	}
}
