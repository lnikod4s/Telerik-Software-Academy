// Telerik Academy Exam 1 @ 27 Dec 2012
// Problem 5. Formula Bit 1

using System;

class ExamPrep
{
	static readonly char[,] matrix = new char[8, 8];
	static void Main()
	{
		InitializeMatrix();

		int currRow = 0;
		int currCol = 7;
		string direction = "down";
		string lastDirection = "down";
		int trackLength = 0;
		int turnCount = 0;
		bool isValid = false;

		while (true)
		{
			if (matrix[currRow, currCol] == '1') break;

			trackLength++;

			if (currRow == 7 &&
				currCol == 0)
			{
				isValid = true;
				break;
			}

			if (direction == "down" && (currRow + 1 > 7 || matrix[currRow + 1, currCol] == '1'))
			{
				direction = "left";
				lastDirection = "down";
				turnCount++;

				if (currCol - 1 < 0 || matrix[currRow, currCol - 1] == '1') break;
			}
			else if (direction == "up" && (currRow - 1 < 0 || matrix[currRow - 1, currCol] == '1'))
			{
				direction = "left";
				lastDirection = "up";
				turnCount++;

				if (currCol - 1 < 0 || matrix[currRow, currCol - 1] == '1') break;
			}
			else if (direction == "left" && lastDirection == "down" && (currCol - 1 < 0 || matrix[currRow, currCol - 1] == '1'))
			{
				direction = "up";
				turnCount++;

				if (currRow - 1 < 0 || matrix[currRow - 1, currCol] == '1') break;
			}
			else if (direction == "left" && lastDirection == "up" && (currCol - 1 < 0 || matrix[currRow, currCol - 1] == '1'))
			{
				direction = "down";
				turnCount++;

				if (currRow + 1 > 7 || matrix[currRow + 1, currCol] == '1') break;
			}

			if (direction == "down") currRow++;
			else if (direction == "left") currCol--;
			else if (direction == "up") currRow--;
		}

		if (isValid)
		{
			Console.WriteLine("{0} {1}", trackLength, turnCount);
		}
		else
		{
			Console.WriteLine("No {0}", trackLength);
		}
	}

	private static void InitializeMatrix()
	{
		for (int row = 0; row < 8; row++)
		{
			int input = int.Parse(Console.ReadLine());
			char[] currNum = Convert.ToString(input, 2).PadLeft(8, '0').ToCharArray();
			for (int col = 0; col < 8; col++)
			{
				matrix[row, col] = currNum[col];
			}
		}
	}
}