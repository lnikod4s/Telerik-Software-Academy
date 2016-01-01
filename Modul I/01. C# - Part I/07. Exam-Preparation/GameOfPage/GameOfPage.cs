// Telerik Academy Exam 1 @ 6 December 2013 Evening
// Problem 5. Game of Page

using System;

class ExamPrep
{
	static void Main()
	{
		string[] inputLines = new string[16];
		for (int i = 0; i < 16; i++)
		{
			inputLines[i] = Console.ReadLine();
		}

		char[,] tray = new char[16, 16];
		for (int row = 0; row < 16; row++)
		{
			for (int col = 0; col < 16; col++)
			{
				tray[row, col] = inputLines[row][col];
			}
		}

		decimal price = 0;
		string question = null;
		while (question != "paypal")
		{
			question = Console.ReadLine();
			if (question == "what is")
			{
				int checkRow = int.Parse(Console.ReadLine());
				int checkColumn = int.Parse(Console.ReadLine());
				Console.WriteLine(tray[checkRow, checkColumn] == '0' ? "smile" : CheckLocation(checkRow, checkColumn, tray));
			}
			else if (question == "buy")
			{
				int checkRow = int.Parse(Console.ReadLine());
				int checkColumn = int.Parse(Console.ReadLine());
				if (CheckLocation(checkRow, checkColumn, tray) == "cookie")
				{
					price += 1.79m;
					for (int r = checkRow - 1; r <= checkRow + 1; r++)
					{
						for (int c = checkColumn - 1; c <= checkColumn + 1; c++)
						{
							tray[r, c] = '0';
						}
					}


				}
				else if (CheckLocation(checkRow, checkColumn, tray) == "broken cookie" || CheckLocation(checkRow, checkColumn, tray) == "cookie crumb")
				{
					Console.WriteLine("page");
				}

			}
		}
		Console.WriteLine("{0:F2}", price);
	}

	private static string CheckLocation(int row, int col, char[,] tray)
	{
		int upperRow = row - 1;
		if (row == 0) upperRow++;

		int lowerRow = row + 1;
		if (row == 15) lowerRow--;

		int leftCol = col - 1;
		if (col == 0) leftCol++;

		int rightCol = col + 1;
		if (col == 15) rightCol--;

		int sum = 0;
		for (int r = upperRow; r <= lowerRow; r++)
		{
			for (int c = leftCol; c <= rightCol; c++)
			{
				if (tray[r, c] == '1') sum++;
			}
		}

		if (sum == 9) return "cookie";
		if (sum == 1 && tray[row, col] == '1') return "cookie crumb";
		if (sum != 0) return "broken cookie";
		return "smile";
	}
}