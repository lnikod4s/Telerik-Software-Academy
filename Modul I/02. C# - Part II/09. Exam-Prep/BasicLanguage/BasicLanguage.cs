using System;
using System.Collections.Generic;
using System.Text;

class BasicLanguage
{
	/// <summary>
	/// Telerik Academy Exam 2 @ 7 Feb 2012
	/// Problem 1 Basic Language
	/// </summary>
	private static readonly StringBuilder output = new StringBuilder();
	private static readonly List<string> commands = new List<string>();
	static void Main()
	{
		ReadInput();
		ConvertInputToCommands();
		RunCommands();
		PrintOutput();
	}

	private static void PrintOutput()
	{
		Console.Write(output);
	}

	private static void RunCommands()
	{
		output.Clear();

		for (int i = 0; i < commands.Count; i++)
		{
			int loopsCount = 1;
			string[] subCommands = commands[i].Split(new[] { ')' }, StringSplitOptions.RemoveEmptyEntries);

			foreach (var command in subCommands)
			{
				string currCommand = command.TrimStart();

				if (currCommand.StartsWith("EXIT"))
				{
					return;
				}
				else if (currCommand.StartsWith("PRINT"))
				{
					int paramsStart = currCommand.IndexOf("(") + 1;

					string content =
					currCommand.Substring(paramsStart);

					if (content.Contains("\n"))
					{
						for (int j = 0; j < content.Length; j++)
						{
							char symbol = content[j];

							if (symbol == '\r')
							{
								continue;
							}
							else if (symbol == '\n')
							{
								output.AppendLine();
							}
							else
							{
								output.Append(symbol);
							}
						}
					}
					else
					{
						for (int j = 0; j < loopsCount; j++)
						{
							output.Append(content);
						}
					}
				}
				else if (currCommand.StartsWith("FOR"))
				{
					int paramsStart = currCommand.IndexOf("(") + 1;

					string content =
					currCommand.Substring(paramsStart);

					if (content.Contains(","))
					{
						string[] loopParams =
							content.Split(',');

						int a = int.Parse(loopParams[0]);
						int b = int.Parse(loopParams[1]);

						loopsCount *= (b - a + 1);
					}
					else
					{
						int loopParam = int.Parse(content);

						loopsCount *= loopParam;
					}
				}
			}
		}
	}

	private static void ConvertInputToCommands()
	{
		string input = output.ToString();
		output.Clear();

		foreach (var symbol in input)
		{
			output.Append(symbol);
			if (symbol == ';')
			{
				commands.Add(output.ToString().Trim());
				output.Clear();
			}
		}
	}

	private static void ReadInput()
	{
		while (true)
		{
			string currLine = Console.ReadLine();

			output.AppendLine(currLine);

			if (currLine.Contains("EXIT"))
			{
				break;
			}
		}
	}
}