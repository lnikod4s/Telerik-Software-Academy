using System;
/*Problem 7.* Largest area in matrix
--------------------------------------------------------------------------------------------------------------------
Write a program that finds the largest area of equal neighbour elements in a rectangular matrix and prints its size.
Example:

matrix						result
1	3	2	2	2	4		
3	3	3	2	4	4
4	3	1	2	3	3		13
4	3	1	3	3	1
4	3	3	3	1	1
*/
class LargestAreaInMatrix
{
	static int[,] matrix;
	static int bestLength = 0, bestNumber = 0;
	static int currentLength = 0, currentNumber = 0;
	static void Main()
	{
		matrix = new[,]
		{
			{ 1, 3, 2, 2, 2, 4 },
			{ 3, 3, 3, 2, 4, 4 },
			{ 4, 3, 1, 2, 3, 3 },
			{ 4, 3, 1, 3, 3, 1 },
			{ 4, 3, 3, 3, 1, 1 }
		};

		PrintMatrix(matrix);
		FindBestAreaLength(matrix);
	}

	static void FindBestAreaLength(int[,] testMatrix)
	{
		bestLength = bestNumber = 0;

		for (int row = 0; row < testMatrix.GetLongLength(0); row++)
		{
			for (int col = 0; col < testMatrix.GetLongLength(1); col++)
			{
				currentNumber = testMatrix[row, col];
				currentLength = 0;

				GetAreaLength(row, col);

				if (currentLength > bestLength)
				{
					bestLength = currentLength;
					bestNumber = currentNumber;
				}
			}
		}

		Console.WriteLine("Best Area of number {0} -> {1} times\n", bestNumber, bestLength);
	}

	static void GetAreaLength(int row, int col)
	{
		if (row < 0 || row >= matrix.GetLongLength(0) ||
			col < 0 || col >= matrix.GetLongLength(1) || 
			matrix[row, col] == 0) return;

		if (matrix[row, col] == currentNumber)
		{
			matrix[row, col] = 0;
			currentLength++;

			GetAreaLength(row - 1, col);
			GetAreaLength(row + 1, col);
			GetAreaLength(row, col - 1);
			GetAreaLength(row, col + 1);
		}
	}

	static void PrintMatrix(int[,] testMatrix)
	{
		Console.WriteLine("Matrix ({0}x{1}):\n", testMatrix.GetLongLength(0), testMatrix.GetLongLength(1));
		for (int row = 0; row < testMatrix.GetLongLength(0); row++)
		{
			for (int col = 0; col < testMatrix.GetLongLength(1); col++)
			{
				Console.Write("{0,3}", testMatrix[row, col]);
			}
			Console.WriteLine();
		}
		Console.WriteLine();
	}
}