using System;
using System.Collections.Generic;
using System.Linq;

class GreedyDwarf
{
	/// <summary>
	/// C# Part 2 - 2012/2013 @ 4 Feb 2013 - Morning
	/// 2. Greedy Dwarf
	/// </summary>
	static int maxCoinsCount = int.MinValue;
	static void Main()
	{
		// Read input
		int[] valley =
			Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
		int patternsCount = int.Parse(Console.ReadLine());

		var patterns = new List<int[]>();
		for (short i = 0; i < patternsCount; i++)
		{
			patterns.Add(Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
		}

		// Apply collecting algorithm
		for (int i = 0; i < patternsCount; i++)
		{
			bool[] used = new bool[valley.Length];
			used[0] = true;

			int patternIndex = 0, valleyIndex = 0, currCoinsCount = valley[0];
			while (true)
			{
				valleyIndex += patterns[i][patternIndex];
				patternIndex = (patternIndex + 1) % patterns[i].Length;

				if (valleyIndex < 0 || valleyIndex >= valley.Length)
				{
					break;
				}

				if (used[valleyIndex])
				{
					break;
				}

				used[valleyIndex] = true;
				currCoinsCount += valley[valleyIndex];
			}

			if (currCoinsCount > maxCoinsCount)
			{
				maxCoinsCount = currCoinsCount;
			}
		}

		// Printing the result
		Console.WriteLine(maxCoinsCount);
	}
}