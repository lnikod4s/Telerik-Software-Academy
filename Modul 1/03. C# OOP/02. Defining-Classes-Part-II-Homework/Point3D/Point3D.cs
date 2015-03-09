using System;

public struct Point3D
{
	private static readonly Point3D zeroPoint = new Point3D(0, 0, 0);

	private double x;
	private double y;
	private double z;

	public Point3D(double x, double y, double z)
	{
		this.x = x;
		this.y = y;
		this.z = z;
	}

	public static Point3D ZeroPoint3D { get; private set; }

	public double X
	{
		get { return this.x; }
		private set { this.x = value; }
	}

	public double Y
	{
		get { return this.y; }
		private set { this.y = value; }
	}

	public double Z
	{
		get { return this.z; }
		private set { this.z = value; }
	}

	public override string ToString()
	{
		return string.Format("{0}, {1}, {2}", this.X, this.Y, this.Z);
	}

	public static class Distance
	{
		public static double CalcDistance(Point3D firstPoint, Point3D secondPoint)
		{
			return Math.Sqrt(Math.Pow(firstPoint.X - secondPoint.X, 2) +
							 Math.Pow(firstPoint.Y - secondPoint.Y, 2) +
							 Math.Pow(firstPoint.Z - secondPoint.Z, 2));
		}
	}
}
