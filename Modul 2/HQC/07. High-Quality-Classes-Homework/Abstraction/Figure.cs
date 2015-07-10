namespace Abstraction
{
	internal abstract class Figure
	{
		internal double height;
		internal double radius;
		internal double width;
		internal Figure() { }
		internal Figure(double radius) { this.radius = radius; }

		internal Figure(double width, double height)
		{
			this.width = width;
			this.height = height;
		}
	}
}