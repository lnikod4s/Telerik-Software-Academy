// Telerik Academy Exam 1 @ 29 Dec 2012
// Problem 5. Angry Bits

using System;

class ExamPrep
{
	static readonly char[,] matrix = new char[8, 16];
	static int result = 0;
	static void Main()
	{
		FillTheMatrix();

		for (int col = 7; col >= 0; col--)
		{
			for (int row = 0; row < 8; row++)
			{
				if (matrix[row, col] == '1')
				{
					int currRow = row;
					int currCol = col;
					int flightLenght = 0;

					while (currRow > 0)
					{
						currRow--;
						currCol++;
						flightLenght++;

						if (matrix[currRow, currCol] == '1')
						{
							SeekAndDestroyAllPigsAround(flightLenght, currRow, currCol);
							matrix[row, col] = '0';
							break;
						}
					}

					while (matrix[row, col] == '1' && currRow < 7 && currCol < 15)
					{
						currRow++;
						currCol++;
						flightLenght++;

						if (matrix[currRow, currCol] == '1')
						{
							SeekAndDestroyAllPigsAround(flightLenght, currRow, currCol);
							matrix[row, col] = '0';
							break;
						}
						if (currRow == 7 || currCol == 15)
						{
							matrix[row, col] = '0';
							break;
						}
					}
				}
			}
		}
		Console.WriteLine("{0} {1}", result, IsThereAnyLivingPigs() ? "No" : "Yes");
	}

	private static bool IsThereAnyLivingPigs()
	{
		for (int col = 8; col < 16; col++)
		{
			for (int row = 0; row < 8; row++)
			{
				if (matrix[row, col] == '1') return true;
			}
		}
		return false;
	}

	private static void SeekAndDestroyAllPigsAround(int flightLenght, int currRow, int currCol)
	{
		int killedPigs = 0;
		for (int row = currRow - 1; row <= currRow + 1; row++)
		{
			for (int col = currCol - 1; col <= currCol + 1; col++)
			{
				if (row >= 0 && row <= 7 && col >= 8 && col <= 15)
				{
					if (matrix[row, col] == '1')
					{
						matrix[row, col] = '0';
						killedPigs++;
					}
				}
			}
		}
		result += killedPigs * flightLenght;
	}

	private static void FillTheMatrix()
	{
		for (int row = 0; row < 8; row++)
		{
			int input = int.Parse(Console.ReadLine());
			char[] currNum = Convert.ToString(input, 2).PadLeft(16, '0').ToCharArray();
			for (int col = 0; col < 16; col++)
			{
				matrix[row, col] = currNum[col];
			}
		}
	}
}