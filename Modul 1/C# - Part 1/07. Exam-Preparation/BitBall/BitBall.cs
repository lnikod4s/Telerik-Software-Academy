// Telerik Academy Exam 1 @ 28 Dec 2012
// Problem 5. Bit Ball

using System;

class ExamPrep
{
	static readonly char[,] topMatrix = new char[8, 8];
	static readonly char[,] bottomMatrix = new char[8, 8];
	static readonly char[,] matrix = new char[8, 8];

	static void Main()
	{
		InitializeTopMatrix();
		InitializeBottomMatrix();
		PlayersLeftAfterFouls();

		int resultTopTeam = 0;
		int resultBottomTeam = 0;
		for (int col = 0; col < 8; col++)
		{
			for (int row = 0; row < 8; row++)
			{
				if (matrix[row, col] != '0')
				{
					int currRow = row;

					switch (matrix[row, col])
					{
						case 'B':
							while (true)
							{
								if (currRow == 0)
								{
									resultBottomTeam++;
									break;
								}
								if (matrix[currRow - 1, col] != '0')
								{
									break;
								}
								currRow--;
							}
							break;
						case 'T':
							while (true)
							{
								if (currRow == 7)
								{
									resultTopTeam++;
									break;
								}
								if (matrix[currRow + 1, col] != '0')
								{
									break;
								}
								currRow++;
							}
							break;
					}
				}
			}
		}
		Console.WriteLine("{0}:{1}", resultTopTeam, resultBottomTeam);
	}

	private static void PlayersLeftAfterFouls()
	{
		for (int row = 0; row < 8; row++)
		{
			for (int col = 0; col < 8; col++)
			{
				if (topMatrix[row, col] == '0' &&
					bottomMatrix[row, col] == '0')
				{
					matrix[row, col] = '0';
				}
				else if (topMatrix[row, col] == 'T' &&
						 bottomMatrix[row, col] == 'B')
				{
					matrix[row, col] = '0';
				}
				else if (topMatrix[row, col] == 'T' &&
						 bottomMatrix[row, col] == '0')
				{
					matrix[row, col] = 'T';
				}
				else if (topMatrix[row, col] == '0' &&
						 bottomMatrix[row, col] == 'B')
				{
					matrix[row, col] = 'B';
				}
			}
		}
	}

	private static void InitializeBottomMatrix()
	{
		for (int row = 0; row < 8; row++)
		{
			int input = int.Parse(Console.ReadLine());
			char[] currNum = Convert.ToString(input, 2).PadLeft(8, '0').ToCharArray();
			for (int col = 0; col < 8; col++)
			{
				if (currNum[col] == '1') currNum[col] = 'B';
				bottomMatrix[row, col] = currNum[col];
			}
		}
	}

	private static void InitializeTopMatrix()
	{
		for (int row = 0; row < 8; row++)
		{
			int input = int.Parse(Console.ReadLine());
			char[] currNum = Convert.ToString(input, 2).PadLeft(8, '0').ToCharArray();
			for (int col = 0; col < 8; col++)
			{
				if (currNum[col] == '1') currNum[col] = 'T';
				topMatrix[row, col] = currNum[col];
			}
		}
	}
}