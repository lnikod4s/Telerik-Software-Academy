using System;
using System.Collections.Generic;

namespace NamingIdentifiers
{
	public class Points
	{
		private string playerName;
		private int playerPoints;

		public string PlayerName
		{
			get { return this.playerName; }
			set { this.playerName = value; }
		}

		public Points() { }

		public Points(string playerName, int playerPoints)
		{
			this.playerName = playerName;
			this.playerPoints = playerPoints;
		}

		public int PlayerPoints
		{
			get { return this.playerPoints; }
			set { this.playerPoints = value; }
		}
	}

	class Minesweeper
	{
		static void Main()
		{
			const int MAX_CELLS_COUNT = 35;

			string command = string.Empty;
			char[,] gameField = GenerateGameField();
			char[,] bombsMatrix = FillBombsMatrix();
			int currScore = 0;
			bool isMined = false;
			var championsList = new List<Points>(6);
			int row = 0;
			int column = 0;
			bool isNewGameStarted = true;
			bool isLastCellReached = false;

			do
			{
				if (isNewGameStarted)
				{
					Console.WriteLine("Let's play Minesweeper, the famous Microsoft game.");
					Console.WriteLine("Try to walk around without stepping into mined cells.");
					Console.WriteLine(":::: COMMANDS ::::");
					Console.WriteLine("'top' --> shows the wall of fame");
					Console.WriteLine("'restart' --> begins new game");
					Console.WriteLine("'exit' --> close the current game");
					VisualizeGameField(gameField);
					isNewGameStarted = false;
				}

				Console.Write("Please enter column and column : ");

				command = Console.ReadLine().Trim();
				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&
						int.TryParse(command[2].ToString(), out column) &&
						row <= gameField.GetLength(0) &&
						column <= gameField.GetLength(1))
					{
						command = "turn";
					}
				}

				switch (command)
				{
					case "top":
						GetScoresTable(championsList);
						break;
					case "restart":
						gameField = GenerateGameField();
						bombsMatrix = FillBombsMatrix();
						VisualizeGameField(gameField);
						isMined = false;
						isNewGameStarted = false;
						break;
					case "exit":
						Console.WriteLine("Do you really want to exit?");
						break;
					case "turn":
						if (bombsMatrix[row, column] != '*')
						{
							if (bombsMatrix[row, column] == '-')
							{
								NextMove(gameField, bombsMatrix, row, column);
								currScore++;
							}

							if (MAX_CELLS_COUNT == currScore)
							{
								isLastCellReached = true;
							}
							else
							{
								VisualizeGameField(gameField);
							}
						}
						else
						{
							isMined = true;
						}
						break;
					default:
						Console.WriteLine("\nInvalid command!\n");
						break;
				}

				if (isMined)
				{
					VisualizeGameField(bombsMatrix);

					Console.WriteLine("Sorry, you stepped into a mined cell.");
					Console.WriteLine("Your current score is: {0}", currScore);
					Console.WriteLine("Put your name in the wall of fame: ");

					string name = Console.ReadLine();
					Points playerScore = new Points(name, currScore);
					if (championsList.Count < 5)
					{
						championsList.Add(playerScore);
					}
					else
					{
						for (int i = 0; i < championsList.Count; i++)
						{
							if (championsList[i].PlayerPoints < playerScore.PlayerPoints)
							{
								championsList.Insert(i, playerScore);
								championsList.RemoveAt(championsList.Count - 1);
								break;
							}
						}
					}

					championsList.Sort((r1, r2) => r2.PlayerName.CompareTo(r1.PlayerName));
					championsList.Sort((r1, r2) => r2.PlayerPoints.CompareTo(r1.PlayerPoints));
					GetScoresTable(championsList);

					gameField = GenerateGameField();
					bombsMatrix = FillBombsMatrix();
					currScore = 0;
					isMined = false;
					isNewGameStarted = true;
				}

				if (isLastCellReached)
				{
					Console.WriteLine("\nCongratulations! You have revealed 35 cells without stepping into mines.");
					VisualizeGameField(bombsMatrix);

					Console.WriteLine("Please enter your name: ");
					string name = Console.ReadLine();

					var playerScore = new Points(name, currScore);
					championsList.Add(playerScore);
					GetScoresTable(championsList);

					gameField = GenerateGameField();
					bombsMatrix = FillBombsMatrix();
					currScore = 0;
					isLastCellReached = false;
					isNewGameStarted = true;
				}
			}
			while (command != "exit");
		}

		private static void GetScoresTable(List<Points> playerScore)
		{
			Console.WriteLine("\nCurrent Score:");
			if (playerScore.Count > 0)
			{
				for (int i = 0; i < playerScore.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} cells",
						i + 1, playerScore[i].PlayerName, playerScore[i].PlayerPoints);
				}

				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("Score table is empty!\n");
			}
		}

		private static void NextMove(char[,] gameField,
			char[,] bombsMatrix, int row, int column)
		{
			char bombsCount = GetMinesCount(bombsMatrix, row, column);
			bombsMatrix[row, column] = bombsCount;
			gameField[row, column] = bombsCount;
		}

		private static void VisualizeGameField(char[,] board)
		{
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");

			for (int i = 0; i < board.GetLength(0); i++)
			{
				Console.Write("{0} | ", i);

				for (int j = 0; j < board.GetLength(1); j++)
				{
					Console.Write("{0} ", board[i, j]);
				}

				Console.Write("|");
				Console.WriteLine();
			}

			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] GenerateGameField()
		{
			const int BOARD_ROWS = 5;
			const int BOARD_COLUMNS = 10;

			char[,] board = new char[BOARD_ROWS, BOARD_COLUMNS];
			for (int i = 0; i < BOARD_ROWS; i++)
			{
				for (int j = 0; j < BOARD_COLUMNS; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] FillBombsMatrix()
		{
			const int ROWS = 5;
			const int COLUMNS = 10;

			char[,] gameField = new char[ROWS, COLUMNS];
			for (int i = 0; i < ROWS; i++)
			{
				for (int j = 0; j < COLUMNS; j++)
				{
					gameField[i, j] = '-';
				}
			}

			var randomList = new List<int>();
			while (randomList.Count < 15)
			{
				var random = new Random();
				int currentRandomNumber = random.Next(50);

				if (!randomList.Contains(currentRandomNumber))
				{
					randomList.Add(currentRandomNumber);
				}
			}

			foreach (int randomNumber in randomList)
			{
				int column = (randomNumber / COLUMNS);
				int row = (randomNumber % COLUMNS);

				if (row == 0 && randomNumber != 0)
				{
					column--;
					row = COLUMNS;
				}
				else
				{
					row++;
				}

				gameField[column, row - 1] = '*';
			}

			return gameField;
		}

		private static void DoCalculations(char[,] gameField)
		{
			int column = gameField.GetLength(0);
			int row = gameField.GetLength(1);
			for (int i = 0; i < column; i++)
			{
				for (int j = 0; j < row; j++)
				{
					if (gameField[i, j] != '*')
					{
						char minesCount = GetMinesCount(gameField, i, j);
						gameField[i, j] = minesCount;
					}
				}
			}
		}

		private static char GetMinesCount(char[,] gameField, int column, int row)
		{
			int minesCount = 0;
			int rows = gameField.GetLength(0);
			int columns = gameField.GetLength(1);

			if (column - 1 >= 0)
			{
				if (gameField[column - 1, row] == '*')
				{
					minesCount++;
				}
			}

			if (column + 1 < rows)
			{
				if (gameField[column + 1, row] == '*')
				{
					minesCount++;
				}
			}

			if (row - 1 >= 0)
			{
				if (gameField[column, row - 1] == '*')
				{
					minesCount++;
				}
			}

			if (row + 1 < columns)
			{
				if (gameField[column, row + 1] == '*')
				{
					minesCount++;
				}
			}

			if ((column - 1 >= 0) && (row - 1 >= 0))
			{
				if (gameField[column - 1, row - 1] == '*')
				{
					minesCount++;
				}
			}

			if ((column - 1 >= 0) && (row + 1 < columns))
			{
				if (gameField[column - 1, row + 1] == '*')
				{
					minesCount++;
				}
			}

			if ((column + 1 < rows) && (row - 1 >= 0))
			{
				if (gameField[column + 1, row - 1] == '*')
				{
					minesCount++;
				}
			}

			if ((column + 1 < rows) && (row + 1 < columns))
			{
				if (gameField[column + 1, row + 1] == '*')
				{
					minesCount++;
				}
			}

			return char.Parse(minesCount.ToString());
		}
	}
}