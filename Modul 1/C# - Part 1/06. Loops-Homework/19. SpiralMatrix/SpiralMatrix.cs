using System;
/*Problem 19.** Spiral Matrix
--------------------------------------------------------------------------------------------------------------------
Write a program that reads from the console a positive integer number n (1 = n = 20) and prints a matrix holding the numbers from 1 to n*n in the form of square spiral like in the examples below.
Examples:

n = 2   matrix      n = 3   matrix      n = 4   matrix
		1 2                 1 2 3               1  2  3  4
		4 3                 8 9 4               12 13 14 5
							7 6 5               11 16 15 6
												10 9  8  7
*/

class SpiralMatrix
{
	static void Main()
	{
		Console.Write("Enter a number: ");
		byte n = byte.Parse(Console.ReadLine());

		int[,] matrix = new int[n, n];
		sbyte row = 0, col = -1;
		string direction = "right";

		Console.WriteLine();
		for (int i = 1; i <= n * n; i++)
		{
			if (direction == "right")
			{
				if (matrix[row, ++col] == 0) matrix[row, col] = i;
				if (col + 1 >= n || matrix[row, col + 1] != 0) direction = "down";
			}
			else if (direction == "down")
			{
				if (matrix[++row, col] == 0) matrix[row, col] = i;
				if (row + 1 >= n || matrix[row + 1, col] != 0) direction = "left";
			}
			else if (direction == "left")
			{
				if (matrix[row, --col] == 0) matrix[row, col] = i;
				if (col - 1 < 0 || matrix[row, col - 1] != 0) direction = "up";
			}
			else if (direction == "up")
			{
				if (matrix[--row, col] == 0) matrix[row, col] = i;
				if (row - 1 < 0 || matrix[row - 1, col] != 0) direction = "right";
			}
		}
		PrintMatrix(matrix);
	}

	private static void PrintMatrix(int[,] matrix)
	{
		for (int row = 0; row < matrix.GetLongLength(0); row++)
		{
			for (int col = 0; col < matrix.GetLongLength(1); col++)
			{
				Console.Write("{0,4}", matrix[row, col]);
			}
			Console.WriteLine();
			Console.WriteLine();
		}
		Console.WriteLine();
	}
}