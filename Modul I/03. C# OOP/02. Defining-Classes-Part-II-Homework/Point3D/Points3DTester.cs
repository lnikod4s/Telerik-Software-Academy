using System;
using System.Globalization;
using System.Threading;

class Points3DTester
{
	static void Main()
	{
		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		// first test point
		Point3D firstPoint3D = new Point3D(1.2, 2.4, 3.7);
		Console.WriteLine("Point({0})", firstPoint3D);

		// second test point
		Point3D secondPoint3D = Point3D.ZeroPoint3D;
		Console.WriteLine("Point({0})", secondPoint3D);

		// calculate the points distance
		Console.WriteLine("Distance between test points: {0:F2}", Point3D.Distance.CalcDistance(firstPoint3D, secondPoint3D));

		// sequence of points => path
		var path = new Path3D(new Point3D(1, 1, 1), new Point3D(2, 2, 2));
		path.Add(new Point3D(3, 3, 3));
		path.Remove(new Point3D(1, 1, 1));
		Console.WriteLine(Environment.NewLine + "Points in path (total: {0})"+ Environment.NewLine + "{1}", path.Count, path);
		path.Clear();

		// load new points from input.txt
		path = Path3D.PathStorage.LoadPaths("../../input.txt");
		Console.WriteLine(Environment.NewLine + "Points in path (total: {0})" + Environment.NewLine + "{1}", path.Count, path);

		// save points in output.txt
		// path.Clear();
		Path3D.PathStorage.SavePaths(path, "../../output.txt");
	}
}