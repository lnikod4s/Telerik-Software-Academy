using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Path3D
{
	private readonly List<Point3D> path = new List<Point3D>();

	public Path3D()
	{
	}

	public Path3D(params Point3D[] points)
	{
		this.Add(points);
	}

	public int Count
	{
		get { return this.path.Count; }
	}

	public Point3D this[int index]
	{
		get
		{
			if (index >= 0 && index < path.Count)
			{
				return this.path[index];
			}
			else
			{
				throw new ArgumentException("Invalid index.");
			}
			
		}
		set
		{
			if (index >= 0 && index < path.Count)
			{
				this.path[index] = value;
			}
			else
			{
				throw new ArgumentException("Invalid index.");
			}
		}
	}

	public Path3D Add(params Point3D[] points)
	{
		foreach (var point in points)
		{
			this.path.Add(point);
		}

		return this;
	}

	public Path3D Remove(Point3D point)
	{
		this.path.Remove(point);

		return this;
	}

	public Path3D Clear()
	{
		this.path.Clear();

		return this;
	}

	public override string ToString()
	{
		return string.Join(Environment.NewLine, this.path);
	}

	public static class PathStorage
	{
		public static void SavePaths(Path3D points, string filePath)
		{
			File.WriteAllText(filePath, points.ToString());
		}

		public static Path3D LoadPaths(string filePath)
		{
			Path3D path3D = new Path3D();

			string[] points = File.ReadAllText(filePath).Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < points.Length; i++)
			{
				double[] coordinates = points[i].Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
												.Select(double.Parse)
												.ToArray();
				path3D.Add(new Point3D(coordinates[0], coordinates[1], coordinates[2]));
			}

			return path3D;
		}
	}
}
