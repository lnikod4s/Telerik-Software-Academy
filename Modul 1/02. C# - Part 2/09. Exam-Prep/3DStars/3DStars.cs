using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Telerik Academy Exam 2 @ 6 Feb 2012
/// Problem 4 3D Stars
/// </summary>
class Stars3D
{
	private static int width, heigth, depth, count;
	private static char[, ,] cuboid;
	private static Dictionary<char, int> starType = new Dictionary<char, int>();
	static void Main()
	{
		ReadInput();
		FindStars();
		PrintResult();
	}

	private static void PrintResult()
	{
		Console.WriteLine(count);

		var sorted = starType.OrderBy(x => x.Key);
		foreach (var star in sorted)
		{
			Console.WriteLine("{0} {1}", star.Key, star.Value);
		}
	}

	private static void FindStars()
	{
		for (int w = 1; w < width - 1; w++)
		{
			for (int h = 1; h < heigth - 1; h++)
			{
				for (int d = 1; d < depth - 1; d++)
				{
					FindSingleStar(w, h, d);
				}
			}
		}
	}

	private static void FindSingleStar(int currWidth, int currHeigth, int currDepth)
	{
		char currChar = cuboid[currWidth, currHeigth, currDepth];

		bool isStar = 
			currChar == cuboid[currWidth - 1, currHeigth, currDepth] &&
			currChar == cuboid[currWidth + 1, currHeigth, currDepth] &&
			currChar == cuboid[currWidth, currHeigth - 1, currDepth] &&
			currChar == cuboid[currWidth, currHeigth + 1, currDepth] &&
			currChar == cuboid[currWidth, currHeigth, currDepth - 1] &&
			currChar == cuboid[currWidth, currHeigth, currDepth + 1];

		if (isStar)
		{
			count++;

			if (starType.ContainsKey(currChar))
			{
				starType[currChar]++;
			}
			else
			{
				starType.Add(currChar, 1);
			}
		}
	}

	private static void ReadInput()
	{
		string[] dimensions = Console.ReadLine().Split();
		width = int.Parse(dimensions[0]);
		heigth = int.Parse(dimensions[1]);
		depth = int.Parse(dimensions[2]);

		cuboid = new char[width, heigth, depth];
		for (int h = 0; h < heigth; h++)
		{
			string[] line = Console.ReadLine().Split();
			for (int d = 0; d < depth; d++)
			{
				string content = line[d];
				for (int w = 0; w < width; w++)
				{
					cuboid[w, h, d] = content[w];
				}
			}
		}
	}
}