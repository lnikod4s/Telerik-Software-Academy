using System;
/*Problem 2. Maximal sum
------------------------------------------------------------------------------------------------------------------------
Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.
*/
class MaximalSum
{
	static void Main()
	{
		// Read the matrix dimensions
		Console.Write("Number of rows = ");
		int rows = int.Parse(Console.ReadLine());
		Console.Write("Number of columns = ");
		int cols = int.Parse(Console.ReadLine());

		// Allocate the matrix
		int[,] matrix = new int[rows, cols];

		// Enter the matrix elements
		FillTheMatrix(matrix, rows, cols);

		// Print the matrix on the console
		PrintMatrix(matrix, rows, cols);

		// Find the maximal sum platform of size 3 x 3
		int bestSum, bestRow, bestCol;
		FindMaxSumPlatform(out bestSum, matrix, out bestRow, out bestCol);

		// Print the result
		PrintResult(matrix, bestRow, bestCol, bestSum);
	}

	private static void PrintResult(int[,] matrix, int bestRow, int bestCol, int bestSum)
	{
		Console.WriteLine("\nThe best platform is:\n");
		Console.WriteLine("{0}\t{1}\t{2}",
			matrix[bestRow, bestCol],
			matrix[bestRow, bestCol + 1],
			matrix[bestRow, bestCol + 2]);
		Console.WriteLine("{0}\t{1}\t{2}",
			matrix[bestRow + 1, bestCol],
			matrix[bestRow + 1, bestCol + 1],
			matrix[bestRow + 1, bestCol + 2]);
		Console.WriteLine("{0}\t{1}\t{2}",
			matrix[bestRow + 2, bestCol],
			matrix[bestRow + 2, bestCol + 1],
			matrix[bestRow + 2, bestCol + 2]);
		Console.WriteLine("\nThe maximal sum is: {0}\n", bestSum);
	}

	private static void FindMaxSumPlatform(out int bestSum, int[,] matrix, out int bestRow, out int bestCol)
	{
		bestSum = int.MinValue;
		bestRow = 0;
		bestCol = 0;
		for (int row = 0; row < matrix.GetLength(0) - 2; row++)
		{
			for (int col = 0; col < matrix.GetLength(1) - 2; col++)
			{
				int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
				          matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
				          matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
				if (sum > bestSum)
				{
					bestSum = sum;
					bestRow = row;
					bestCol = col;
				}
			}
		}
	}

	private static void FillTheMatrix(int[,] matrix, int rows, int cols)
	{
		for (int row = 0; row < rows; row++)
		{
			for (int col = 0; col < cols; col++)
			{
				Console.Write("matrix[{0},{1}] = ", row, col);
				int element = int.Parse(Console.ReadLine());
				matrix[row, col] = element;
			}
		}
	}

	private static void PrintMatrix(int[,] matrix, int rows, int cols)
	{
		Console.WriteLine("\nThe matrix is as follows:\n");
		for (int row = 0; row < rows; row++)
		{
			for (int col = 0; col < cols; col++)
			{
				Console.Write("{0}\t", matrix[row, col]);
			}
			Console.WriteLine();
		}
	}
}