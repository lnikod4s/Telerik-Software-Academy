using System;

class Slides3D
{
	public static string[, ,] cubе;
	public static readonly string[] directions = { "L", "R", "F", "B", "FL", "FR", "BL", "BR" };
	public static readonly int[] dirsW = { -1, 1, 0, 0, -1, 1, -1, 1 };
	public static readonly int[] dirsH = { 1, 1, 1, 1, 1, 1, 1, 1 };
	public static readonly int[] dirsD = { 0, 0, -1, 1, -1, -1, 1, 1 };

	static void Main()
	{
		// Read the cuboid size
		string cuboidSize = Console.ReadLine();
		string[] sizes = cuboidSize.Split();
		int width = int.Parse(sizes[0]);
		int height = int.Parse(sizes[1]);
		int depth = int.Parse(sizes[2]);
		cubе = new string[width, height, depth];

		// Read the cuboid data
		for (int h = 0; h < height; h++)
		{
			string line = Console.ReadLine();
			string[] layers = Array.ConvertAll(line.Split('|'), p => p.Trim());
			for (int d = 0; d < depth; d++)
			{
				string[] currentLayerElements = layers[d].Substring(1, layers[d].Length - 2).Split(new[] { ")(" }, StringSplitOptions.RemoveEmptyEntries);
				for (int w = 0; w < width; w++)
				{
					cubе[w, h, d] = currentLayerElements[w];
				}
			}
		}

		string[] ballStartCoordinates = Console.ReadLine().Split();
		int ballW = int.Parse(ballStartCoordinates[0]);
		int ballD = int.Parse(ballStartCoordinates[1]);
		int ballH = 0;

		while (true)
		{
			string[] currentCell = cubе[ballW, ballH, ballD].Split();
			switch (currentCell[0])
			{
				case "S":
					int dirIndex = Array.IndexOf(directions, currentCell[1]);
					if (IsInCube(ballW + dirsW[dirIndex],
								 ballH + dirsH[dirIndex],
								 ballD + dirsD[dirIndex]))
					{
						ballW += dirsW[dirIndex];
						ballH += dirsH[dirIndex];
						ballD += dirsD[dirIndex];
					}
					else
					{
						PrintResult(ballW, ballH, ballD);
						return;
					}
					break;
				case "T":
					ballW = int.Parse(currentCell[1]);
					ballD = int.Parse(currentCell[2]);
					break;
				case "E":
					if (ballH >= height - 1)
					{
						PrintResult(ballW, ballH, ballD);
						return;
					}
					ballH++;
					break;
				case "B":
					PrintResult(ballW, ballH, ballD);
					return;
			}
		}
	}

	public static bool IsInCube(int w, int h, int d)
	{
		if (w < 0 || w >= cubе.GetLength(0) ||
			h < 0 || h >= cubе.GetLength(1) ||
			d < 0 || d >= cubе.GetLength(2))
		{
			return false;
		}

		return true;
	}

	public static void PrintResult(int w, int h, int d)
	{
		Console.WriteLine(h == cubе.GetLength(1) - 1 && cubе[w, h, d] != "B" ? "Yes" : "No");
		Console.WriteLine("{0} {1} {2}", w, h, d);
	}
}