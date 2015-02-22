using System;
// C# Part 2 - 2013/2014 @ 22 Jan 2014 - Evening
// 3. Patterns
class Patterns
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		long[,] matrix = new long[n, n];
		for (int i = 0; i < n; i++)
		{
			var line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			for (int j = 0; j < line.Length; j++)
			{
				matrix[i, j] = long.Parse(line[j]);
			}
		}

		Console.WriteLine(Solve(matrix));
	}

	private static string Solve(long[,] matrix)
	{
		long maxSum = int.MinValue;
		bool isSumFound = false;

		for (int row = 0; row < matrix.GetLength(0); row++)
		{
			for (int col = 0; col < matrix.GetLength(1); col++)
			{
				if (ContainsPattern(matrix, row, col))
				{
					long patternSum = CalculatePatternSum(matrix, row, col);
					if (maxSum < patternSum)
					{
						maxSum = patternSum;
					}
					isSumFound = true;
				}
			}
		}

		if (isSumFound)
		{
			return string.Format("YES {0}", maxSum);
		}
		else
		{
			long diagonalSum = 0;
			for (int index = 0; index < matrix.GetLength(0); index++)
			{
				diagonalSum += matrix[index, index];
			}

			return string.Format("NO {0}", diagonalSum);
		}
	}

	private static long CalculatePatternSum(long[,] matrix, int row, int col)
	{
		long sum = 0;
		sum += matrix[row, col];
		sum += matrix[row, col + 1];
		sum += matrix[row, col + 2];
		sum += matrix[row + 1, col + 2];
		sum += matrix[row + 2, col + 2];
		sum += matrix[row + 2, col + 3];
		sum += matrix[row + 2, col + 4];

		return sum;
	}

	private static bool ContainsPattern(long[,] matrix, int row, int col)
	{
		if (row + 2 >= matrix.GetLength(0) || col + 4 >= matrix.GetLength(1))
		{
			return false;
		}
		var result = matrix[row, col] + 1 == matrix[row, col + 1] &&
					 matrix[row, col + 1] + 1 == matrix[row, col + 2] &&
					 matrix[row, col + 2] + 1 == matrix[row + 1, col + 2] &&
					 matrix[row + 1, col + 2] + 1 == matrix[row + 2, col + 2] &&
					 matrix[row + 2, col + 2] + 1 == matrix[row + 2, col + 3] &&
					 matrix[row + 2, col + 3] + 1 == matrix[row + 2, col + 4];

		return result;
	}
}