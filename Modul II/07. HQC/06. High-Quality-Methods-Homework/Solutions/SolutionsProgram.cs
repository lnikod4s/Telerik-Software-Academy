using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Solutions
{
	public class SolutionsProgram
	{
		private static long absDiff;
		private static int[,] chessboard;
		private static bool[,] visited;
		private static int sum;

		public static void Main()
		{
			ProblemOneSolution();
			ProblemTwoSolution();
			ProblemThreeSolution();
			ProblemFourSolution();
			ProblemFiveSolution();
		}

		private static void ProblemFiveSolution()
		{
			var N = int.Parse(Console.ReadLine());

			var result = new List<char>();
			for (var i = 0; i < N; i++)
			{
				var currLine = Console.ReadLine();
				currLine = currLine.Replace(" is before ", "<");
				currLine = currLine.Replace(" is after ", ">");
				for (var j = 0; j < currLine.Length; j++)
				{
					var firstDigit = currLine[0];
					var order = currLine[1];
					var secondDigit = currLine[2];

					if (order == '>')
					{
						if (!result.Contains(secondDigit))
						{
							result.Add(secondDigit);
						}

						if (!result.Contains(firstDigit))
						{
							result.Add(firstDigit);
						}
					}

					if (order == '<')
					{
						if (!result.Contains(firstDigit))
						{
							result.Add(firstDigit);
						}

						if (!result.Contains(secondDigit))
						{
							result.Add(secondDigit);
						}
					}
				}
			}

			Console.WriteLine(string.Join("", result));
		}

		private static void ProblemFourSolution()
		{
			var N = int.Parse(Console.ReadLine());
			var input = new string[N];
			for (var i = 0; i < N; i++)
			{
				input[i] = Console.ReadLine();
			}

			for (var i = 0; i < input.Length; i++)
			{
				for (var j = 0; j < input[i].Length; j++)
				{
				}
			}
		}

		private static void ProblemThreeSolution()
		{
			var dims = Console.ReadLine()
			                  .Split()
			                  .Select(int.Parse)
			                  .ToArray();
			var chessboardRow = dims[0];
			var chessboardCol = dims[1];

			chessboard = new int[chessboardRow, chessboardCol];
			visited = new bool[chessboardRow, chessboardCol];
			FillChessboard(chessboardRow, chessboardCol);

			var N = int.Parse(Console.ReadLine());
			var dirs = new string[N];
			var steps = new int[N];
			for (var i = 0; i < N; i++)
			{
				var currLine = Console.ReadLine().Split();
				dirs[i] = currLine[0];
				steps[i] = int.Parse(currLine[1]);
			}

			int currRow = chessboard.GetLength(0) - 1, currCol = 0;
			visited[currRow, currCol] = true;
			for (var i = 0; i < N; i++)
			{
				var currCommand = dirs[i];
				var currStep = steps[i];

				for (var j = 0; j < currStep; j++)
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
				for (var col = 0; col < chessboard.GetLength(1); col++)
				{
					chessboard[row, col] = (col + index) * 3;
				}
			}
		}

		private static void ProblemTwoSolution()
		{
			var numbers = Console.ReadLine()
			                     .Split()
			                     .Select(int.Parse)
			                     .ToArray();

			BigInteger sumOddDiffs = 0;
			for (var i = 1; i < numbers.Length; i++)
			{
				long currNum = numbers[i];
				long prevNum = numbers[i - 1];

				if (currNum > prevNum &&
				    prevNum < 0)
				{
					absDiff = currNum + Math.Abs(prevNum);
				}
				else if (currNum > prevNum &&
				         prevNum > 0)
				{
					absDiff = currNum - prevNum;
				}

				if (currNum < prevNum &&
				    currNum < 0)
				{
					absDiff = prevNum + Math.Abs(currNum);
				}
				else if (currNum < prevNum &&
				         currNum > 0)
				{
					absDiff = prevNum - currNum;
				}

				if (absDiff % 2 == 0)
				{
					i++;
					continue;
				}
				else
				{
					sumOddDiffs += absDiff;
					continue;
				}
			}

			Console.WriteLine(sumOddDiffs);
		}

		private static void ProblemOneSolution()
		{
			string[] alpha = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s"};
			var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

			var currLetter = new StringBuilder();
			long temp = 0;
			long sumInDec = 0;
			for (var i = 0; i < input.Length; i++)
			{
				for (var j = 0; j < input[i].Length; j++)
				{
					currLetter.Append(input[i][j]);
					if (alpha.Contains(currLetter.ToString()))
					{
						var currDigit = Array.IndexOf(alpha, currLetter.ToString());
						temp *= 19;
						temp += currDigit;
						currLetter.Clear();
					}
				}

				sumInDec += temp;
				temp = 0;
			}

			var sumInDecCopy = sumInDec;
			var alphaNum = new List<string>();
			do
			{
				alphaNum.Add(alpha[sumInDecCopy % 19]);
				sumInDecCopy /= 19;
			}
			while (sumInDecCopy != 0);

			alphaNum.Reverse(); // Reversing the number to get the real value
			var suminAlpha = string.Join(string.Empty, alphaNum);

			Console.WriteLine("{0} = {1}", suminAlpha, sumInDec);
		}
	}
}