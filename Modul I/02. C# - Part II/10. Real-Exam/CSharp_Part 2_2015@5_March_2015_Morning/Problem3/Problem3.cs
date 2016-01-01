using System;
using System.Linq;

/// <summary>
/// C# Part 2 - 2015/2016 @ 5 March 2015 - Morning
/// </summary>
class Problem3
{
	private static int[,] chessboard;
	private static bool[,] visited;
	private static int sum = 0;
	static void Main()
	{
		int[] dims = Console.ReadLine()
							.Split()
							.Select(int.Parse)
							.ToArray();
		int chessboardRow = dims[0];
		int chessboardCol = dims[1];

		chessboard = new int[chessboardRow, chessboardCol];
		visited = new bool[chessboardRow, chessboardCol];
		FillChessboard(chessboardRow, chessboardCol);

		int N = int.Parse(Console.ReadLine());
		string[] dirs = new string[N];
		int[] steps = new int[N];
		for (int i = 0; i < N; i++)
		{
			string[] currLine = Console.ReadLine().Split();
			dirs[i] = currLine[0];
			steps[i] = int.Parse(currLine[1]);
		}

		int currRow = chessboard.GetLength(0) - 1, currCol = 0;
		visited[currRow, currCol] = true;
		for (int i = 0; i < N; i++)
		{
			string currCommand = dirs[i];
			int currStep = steps[i];

			for (int j = 0; j < currStep; j++)
			{
				GetCurrCoordinates(currCommand, ref currRow, ref currCol);

				if (currRow < 0)
				{
					currRow++;
				}
				else if (currRow == chessboard.GetLength(0))
				{
					currRow--;
				}

				if (currCol < 0)
				{
					currCol++;
				}
				else if (currCol == chessboard.GetLength(1))
				{
					currCol--;
				}

				if (!visited[currRow, currCol])
				{
					sum += chessboard[currRow, currCol];
				}

				visited[currRow, currCol] = true;
			}
		}

		Console.WriteLine(sum);
	}

	private static void GetCurrCoordinates(string currDir, ref int currRow, ref int currCol)
	{
		switch (currDir)
		{
			case "RU":
				currRow--;
				currCol++;
				break;
			case "UR":
				currRow--;
				currCol++;
				break;
			case "UL":
				currRow--;
				currCol--;
				break;
			case "LU":
				currRow--;
				currCol--;
				break;
			case "DL":
				currRow++;
				currCol--;
				break;
			case "LD":
				currRow++;
				currCol--;
				break;
			case "DR":
				currRow++;
				currCol++;
				break;
			case "RD":
				currRow++;
				currCol++;
				break;
		}
	}

	private static void FillChessboard(int chessboardRow, int chessboardCol)
	{
		for (int row = chessboard.GetLength(0) - 1, index = 0; row >= 0; row--, index++)
		{
			for (int col = 0; col < chessboard.GetLength(1); col++)
			{
				chessboard[row, col] = (col + index) * 3;
			}
		}
	}
}