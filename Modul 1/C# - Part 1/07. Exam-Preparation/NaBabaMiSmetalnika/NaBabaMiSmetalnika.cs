// Telerik Academy Exam 1 @ 5 December 2013 Evening
// Problem 5. Na Baba mi Smetalnika

using System;

public class ExamPrep
{
	public static void Main()
	{
		const int height = 8;
		int width = int.Parse(Console.ReadLine());

		string[,] matrix = new string[height, width];
		FillingMatrix(height, width, matrix);

		string input = null;
		while (input != "stop")
		{
			const int onesCount = 0;
			input = Console.ReadLine();
			if (input == "right") ExecuteCommandRight(width, matrix, onesCount);
			else if (input == "left") ExecuteCommandLeft(width, matrix, onesCount);
			else if (input == "reset") ExecuteCommandReset(height, width, matrix);
		}

		long sumOfAllLines = 0;
		sumOfAllLines = SumOfAllLines(matrix, sumOfAllLines);

		int zeroColumnCounter = 0;
		zeroColumnCounter = ZeroColumnCounter(width, height, matrix, zeroColumnCounter);

		long output = sumOfAllLines * zeroColumnCounter;

		Console.WriteLine(output);
	}

	private static void ExecuteCommandReset(int height, int width, string[,] matrix)
	{
		for (int row = 0; row < height; row++)
		{
			var onesCount = 0;

			for (int currCol = 0; currCol < width; currCol++)
			{
				if (matrix[row, currCol] == "1")
				{
					matrix[row, currCol] = "0";
					onesCount++;
				}
			}

			for (int currCol = 0; onesCount > 0; onesCount--, currCol++)
			{
				matrix[row, currCol] = "1";
			}
		}
	}

	private static void ExecuteCommandLeft(int width, string[,] matrix, int onesCount)
	{
		int row = int.Parse(Console.ReadLine());
		int col = int.Parse(Console.ReadLine());

		if (col < 0) col = 0;
		if (col >= width) col = width - 1;

		for (int currCol = col; currCol >= 0; currCol--)
		{
			if (matrix[row, currCol] == "1")
			{
				matrix[row, currCol] = "0";
				onesCount++;
			}
		}

		for (int currCol = 0; onesCount > 0; onesCount--, currCol++)
		{
			matrix[row, currCol] = "1";
		}
	}

	private static void ExecuteCommandRight(int width, string[,] matrix, int onesCount)
	{
		int row = int.Parse(Console.ReadLine());
		int col = int.Parse(Console.ReadLine());

		if (col < 0) col = 0; // check if position is outside the array (by default from -50 to 50)
		if (col >= width) col = width - 1;

		for (int currCol = col; currCol < width; currCol++)
		{
			if (matrix[row, currCol] == "1") // count ones after given position and clearing the cells
			{
				matrix[row, currCol] = "0";
				onesCount++;
			}
		}

		for (int currCol = width - 1; onesCount > 0; onesCount--, currCol--)
		{
			matrix[row, currCol] = "1"; // put ones from left to right until onesCount == 0
		}
	}

	private static void FillingMatrix(int height, int width, string[,] matrix)
	{
		for (int row = 0; row < height; row++)
		{
			int number = int.Parse(Console.ReadLine());
			int position = 0;

			for (int col = width - 1; col >= 0; col--)
			{
				int lastBit = number & (1 << position);
				lastBit >>= position;

				if (lastBit != 0) matrix[row, col] = "1";
				else matrix[row, col] = "0";

				position++;
			}
		}
	}

	private static long SumOfAllLines(string[,] matrix, long sumOfAllLines)
	{
		for (int row = 0; row < matrix.GetLength(0); row++) // convert binary num to decimal and add it to sumOfAllLines
		{
			string binNum = null;
			long decimalNum = 0;
			int pow = 0;

			for (int col = 0; col < matrix.GetLength(1); col++)
			{
				binNum += matrix[row, col];
			}

			for (int i = binNum.Length - 1; i >= 0; i--)
			{
				long digit = binNum[i] - '0';
				decimalNum += (long)(digit * (Math.Pow(2, pow)));
				pow++;
			}
			sumOfAllLines += decimalNum;
		}
		return sumOfAllLines;
	}

	private static int ZeroColumnCounter(int width, int height, string[,] matrix, int zeroColumnCounter)
	{
		for (int col = width - 1; col >= 0; col--) // count columns that contain only nulls
		{
			int zeroesCounter = 0;

			for (int row = 0; row < height; row++)
			{
				if (matrix[row, col] == "0") zeroesCounter++;
			}

			if (zeroesCounter == height) zeroColumnCounter++;
		}
		return zeroColumnCounter;
	}
}