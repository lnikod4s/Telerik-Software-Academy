namespace _01.Shapes
{
	class Rectangle : Shape
	{
		public Rectangle(double width, double height)
			: base(width, height) { }

		#region Overrides of Shape

		public override double CalculateSurface()
		{
			return this.Width * this.Height;
		}

		#endregion
	}
}
