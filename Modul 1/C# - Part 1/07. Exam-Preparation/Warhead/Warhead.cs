// Telerik Academy Exam 1 @ 6 December 2013 Morning
// Problem 5. Warhead

using System;
using System.Text;

class ExamPrep
{
	static void Main()
	{
		int[,] matrix = new int[16, 16];
		for (int row = 0; row < 16; row++)
		{
			string input = Console.ReadLine();
			char[] currentLine = input.ToCharArray();
			for (int col = 0; col < 16; col++)
			{
				matrix[row, col] = int.Parse(currentLine[col].ToString());
			}
		}

		StringBuilder output = new StringBuilder();

		ProcessingInputData(output, matrix);

		Console.WriteLine(output);
	}

	private static void ProcessingInputData(StringBuilder output, int[,] matrix)
	{
		bool isArmed = true;
		while (isArmed)
		{
			string input = Console.ReadLine();
			switch (input)
			{
				case "hover":
					{
						int line = int.Parse(Console.ReadLine());
						int cell = int.Parse(Console.ReadLine());
						output.AppendLine(ExecuteHoverCommand(line, cell, matrix));
					}
					break;

				case "operate":
					{
						int line = int.Parse(Console.ReadLine());
						int cell = int.Parse(Console.ReadLine());
						string result = ExecuteOperateCommand(line, cell, matrix);
						if (result != string.Empty)
						{
							isArmed = false;
							output.AppendLine(result);
						}
					}
					break;

				case "cut":
					{
						isArmed = false;
						string wireColor = Console.ReadLine();
						if (wireColor == "left") wireColor = "red";
						if (wireColor == "right") wireColor = "blue";
						output.AppendLine(CutWire(matrix, wireColor));
					}
					break;
			}
		}
	}

	private static string ExecuteHoverCommand(int line, int cell, int[,] matrix)
	{
		string result = "-";
		if (matrix[line, cell] == 1) result = "*";
		return result;
	}

	private static string ExecuteOperateCommand(int line, int cell, int[,] matrix)
	{
		string result = string.Empty;
		if (matrix[line, cell] == 1)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("missed");
			sb.AppendLine(CountCapacitors(matrix, 0, 15, 0, 15).ToString());
			sb.Append("BOOM");
			return sb.ToString();
		}
		if (CheckForCapacitor(matrix, line, cell))
		{
			matrix[line - 1, cell - 1] = 0;
			matrix[line - 1, cell] = 0;
			matrix[line - 1, cell + 1] = 0;
			matrix[line + 1, cell - 1] = 0;
			matrix[line + 1, cell] = 0;
			matrix[line + 1, cell + 1] = 0;
			matrix[line, cell - 1] = 0;
			matrix[line, cell + 1] = 0;
		}
		return result;
	}

	private static int CountCapacitors(int[,] matrix, int startLine,
		int endLine, int startCell, int endCell)
	{
		int count = 0;
		for (int line = startLine + 1; line < endLine; line++)
		{
			for (int cell = startCell + 1; cell < endCell; cell++)
			{
				if (CheckForCapacitor(matrix, line, cell)) count++;
			}
		}
		return count;
	}

	private static bool CheckForCapacitor(int[,] matrix, int line, int cell)
	{
		try
		{
			return matrix[line - 1, cell - 1] == 1 && matrix[line + 1, cell + 1] == 1 &&
				 matrix[line - 1, cell] == 1 && matrix[line + 1, cell] == 1 &&
				 matrix[line - 1, cell + 1] == 1 && matrix[line + 1, cell - 1] == 1 &&
				 matrix[line, cell - 1] == 1 && matrix[line, cell + 1] == 1;
		}
		catch
		{
			return false;
		}
	}

	private static string CutWire(int[,] matrix, string wireColor)
	{
		StringBuilder result = new StringBuilder();
		int redCapacitors = CountCapacitors(matrix, 0, 15, 0, 8);
		int blueCapacitors = CountCapacitors(matrix, 0, 15, 7, 15);
		switch (wireColor)
		{
			case "red":
				{
					if (redCapacitors != 0)
					{
						result.AppendLine(redCapacitors.ToString());
						result.Append("BOOM");
					}
					else
					{
						result.AppendLine(blueCapacitors.ToString());
						result.Append("disarmed");
					}
				}
				break;

			case "blue":
				{
					if (blueCapacitors != 0)
					{
						result.AppendLine(blueCapacitors.ToString());
						result.Append("BOOM");
					}
					else
					{
						result.AppendLine(redCapacitors.ToString());
						result.Append("disarmed");
					}
				}
				break;
		}
		return result.ToString();
	}
}