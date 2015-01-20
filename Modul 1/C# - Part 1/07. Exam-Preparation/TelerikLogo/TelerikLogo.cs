// Telerik Academy Exam 1 @ 28 Dec 2012
// Problem 4. Telerik Logo

using System;

class ExamPrep
{
	static void Main()
	{
		int X = int.Parse(Console.ReadLine());
		int Z = (X / 2) + 1;

		int width = (2 * X + 2 * Z) - 3;

		int[,] matrix = new int[width, width];

		int currentRow = X / 2;
		int currentCol = 0;

		while (true)
		{
			matrix[currentRow, currentCol] = 1;

			currentRow--;
			currentCol++;

			if (currentRow < 0)
			{
				currentRow++;
				currentCol--;
				break;
			}
		}

		while (true)
		{
			matrix[currentRow, currentCol] = 1;

			currentRow++;
			currentCol++;

			if (currentRow == 2 * X - 1)
			{
				currentRow--;
				currentCol--;
				break;
			}
		}

		while (true)
		{
			matrix[currentRow, currentCol] = 1;

			currentRow++;
			currentCol--;

			if (currentRow == width)
			{
				currentRow--;
				currentCol++;
				break;
			}
		}

		while (true)
		{
			matrix[currentRow, currentCol] = 1;

			currentRow--;
			currentCol--;

			if (currentCol == X / 2 - 1)
			{
				currentRow++;
				currentCol++;
				break;
			}
		}

		while (true)
		{
			matrix[currentRow, currentCol] = 1;

			currentRow--;
			currentCol++;

			if (currentRow < 0)
			{
				currentRow++;
				currentCol--;
				break;
			}
		}

		while (true)
		{
			matrix[currentRow, currentCol] = 1;

			currentRow++;
			currentCol++;

			if (currentCol == width)
			{
				break;
			}
		}

		for (int row = 0; row < width; row++)
		{
			for (int col = 0; col < width; col++)
			{
				if (matrix[row, col] == 0)
				{
					Console.Write('.');
				}
				else if (matrix[row, col] == 1)
				{
					Console.Write('*');
				}
			}
			Console.WriteLine();
		}
	}
}