using System;
using System.Linq;
using System.Text;

/// <summary>
/// C# Part 2 - 2013/2014 @ 14 Sept 2013 - Evening
/// 3. Trails 3D 37/100
/// </summary>
class Trails3D
{
	private const string LEFT_DIR = "left";
	private const string RIGHT_DIR = "right";
	private const string UP_DIR = "up";
	private const string DOWN_DIR = "down";

	private static bool[,] field;

	static void Main()
	{
		int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
		int X = dimensions[0];
		int Y = dimensions[1];
		int Z = dimensions[2];

		string redInputDirs = Console.ReadLine();
		string blueInputDirs = Console.ReadLine();

		string redDirs = FormatCommands(redInputDirs);
		string blueDirs = FormatCommands(blueInputDirs);

		field = new bool[Y + 1, 2 * X + 2 * Z];

		int redRow = Y / 2;
		int redCol = Z + X / 2;
		string redDir = "right";
		bool redHasCrashed = false;

		int blueRow = Y / 2;
		int blueCol = 2 * Z + X + X / 2;
		string blueDir = "left";
		bool blueHasCrashed = false;

		field[redRow, redCol] = true;
		field[blueRow, blueCol] = true;

		for (int i = 0; i < redDirs.Length; i++)
		{
			// Red player
			char currRedCommand = redDirs[i];
			if (currRedCommand == 'L' || currRedCommand == 'R')
			{
				redDir = ChangeDir(redDir, currRedCommand);
			}

			MovePlayer(ref redRow, ref redCol, redDir);

			if (redRow < 0)
			{
				redRow = 0;
				redHasCrashed = true;
			}

			if (redRow == field.GetLength(0))
			{
				redRow = field.GetLength(0) - 1;
				redHasCrashed = true;
			}

			if (field[redRow, redCol])
			{
				redHasCrashed = true;
			}

			// Blue player
			char currBlueCommand = redDirs[i];
			if (currBlueCommand == 'L' || currBlueCommand == 'R')
			{
				blueDir = ChangeDir(blueDir, currBlueCommand);
			}

			MovePlayer(ref blueRow, ref blueCol, blueDir);

			if (blueRow < 0)
			{
				blueRow = 0;
				blueHasCrashed = true;
			}

			if (blueRow == field.GetLength(0))
			{
				blueRow = field.GetLength(0) - 1;
				blueHasCrashed = true;
			}

			if (field[blueRow, blueCol])
			{
				blueHasCrashed = true;
			}

			if (redRow == blueRow && redCol == blueCol)
			{
				redHasCrashed = true;
				blueHasCrashed = true;
			}

			// Printing result
			if (redHasCrashed && !blueHasCrashed)
			{
				Console.WriteLine("BLUE");
				break;
			}

			if (blueHasCrashed && !redHasCrashed)
			{
				Console.WriteLine("RED");
				break;
			}

			if (redHasCrashed && blueHasCrashed)
			{
				Console.WriteLine("DRAW");
				break;
			}

			field[redRow, redCol] = true;
			field[blueRow, blueCol] = true;
		}

		int distanceRow = Math.Abs(redRow - (Y / 2));
		int distanceCol = Math.Abs(redCol - (Z + X / 2));

		if (distanceCol > field.GetLength(1) / 2)
		{
			distanceCol = field.GetLength(1) - distanceCol;
		}

		Console.WriteLine(distanceRow + distanceCol);
	}

	private static void MovePlayer(ref int row, ref int col, string dir)
	{
		switch (dir)
		{
			case UP_DIR:
				row--;
				break;
			case DOWN_DIR:
				row++;
				break;
			case LEFT_DIR:
				col--;
				break;
			case RIGHT_DIR:
				col++;
				break;
			default:
				throw new ArgumentException("Direction is not valid.");
		}

		if (col < 0)
		{
			col = field.GetLength(1) - 1;
		}
		else if (col == field.GetLength(1))
		{
			col = 0;
		}
	}

	private static string ChangeDir(string dir, char command)
	{
		switch (dir)
		{
			case UP_DIR:
				if (command == 'L')
				{
					return LEFT_DIR;
				}
				if (command == 'R')
				{
					return RIGHT_DIR;
				}
				break;
			case DOWN_DIR:
				if (command == 'L')
				{
					return RIGHT_DIR;
				}
				if (command == 'R')
				{
					return LEFT_DIR;
				}
				break;
			case LEFT_DIR:
				if (command == 'L')
				{
					return DOWN_DIR;
				}
				if (command == 'R')
				{
					return UP_DIR;
				}
				break;
			case RIGHT_DIR:
				if (command == 'L')
				{
					return UP_DIR;
				}
				if (command == 'R')
				{
					return DOWN_DIR;
				}
				break;
			default:
				throw new ArgumentException("Direction is not valid.");
		}

		throw new ArgumentException("Direction is not valid.");
	}

	private static string FormatCommands(string path)
	{
		var result = new StringBuilder();
		path = path.Replace("M", " M ");
		path = path.Replace("L", " L ");
		path = path.Replace("R", " R ");

		string[] commands = path.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
		string lastNum = null;

		for (int i = 0; i < commands.Length; i++)
		{
			if (commands[i] == "L" || commands[i] == "R")
			{
				result.Append(commands[i]);
			}
			else if (commands[i] == "M")
			{
				if (lastNum == null)
				{
					result.Append("M");
				}
				else
				{
					int number = int.Parse(lastNum);
					result.Append(new string('M', number));
					lastNum = null;
				}
			}
			else
			{
				lastNum = commands[i];
			}
		}

		result.Replace("LM", "L");
		result.Replace("RM", "R");

		return result.ToString();
	}
}