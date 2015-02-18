using System;
using System.Collections.Generic;
using System.Linq;
// C# Part 2 - 2012/2013 @ 11 Feb 2013
// 2. Special Value
class SpecialValue
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());
		int[][] field = new int[N][];
		bool[][] used = new bool[N][];

		field = ReadInputData(field);
		used = FillUsedCells(field, used);

		SortedSet<long> specialValues = new SortedSet<long>();
		for (int col = 0; col < field[0].Length; col++)
		{
			long specialValue = GetSpecialValues(field, col, used);
			specialValues.Add(specialValue);
		}

		Console.WriteLine(specialValues.Last());
	}

	private static bool[][] FillUsedCells(int[][] field, bool[][] used)
	{
		for (int row = 0; row < field.GetLength(0); row++)
		{
			used[row] = new bool[field[row].Length];
		}

		return used;
	}

	private static long GetSpecialValues(int[][] field, int currCol, bool[][] used)
	{
		long result = 0;
		int currRow = 0;

		while (true)
		{
			result++;

			if (used[currRow][currCol])
			{
				return long.MinValue;
			}

			if (field[currRow][currCol] < 0)
			{
				result -= field[currRow][currCol];
				return result;
			}

			int nextCol = field[currRow][currCol];
			used[currRow][currCol] = true;
			currCol = nextCol;

			currRow++;
			currRow = currRow % field.GetLength(0);

		}
	}

	private static int[][] ReadInputData(int[][] field)
	{
		for (int i = 0; i < field.GetLength(0); i++)
		{
			string[] currLine = Console.ReadLine()
									   .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
			field[i] = new int[currLine.Length];
			for (int j = 0; j < currLine.Length; j++)
			{
				field[i][j] = int.Parse(currLine[j]);
			}
		}

		return field;
	}
}