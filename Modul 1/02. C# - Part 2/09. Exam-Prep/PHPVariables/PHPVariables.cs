using System;
using System.Collections.Generic;
using System.Text;
// Telerik Academy Exam 2 @ 6 Feb 2012
// Problem 1 PHP Variables
class PHPVariables
{
	static void Main()
	{
		var input = ReadInput();
		var variables = ExtractVariablesFromCode(input);
		PrintOutput(variables);
	}

	private static void PrintOutput(List<string> variables)
	{
		Console.WriteLine(variables.Count);
		variables.Sort(StringComparer.Ordinal);
		foreach (var variable in variables)
		{
			Console.WriteLine(variable);
		}
	}

	private static bool isValidChar(char currChar)
	{
		if (char.IsLower(currChar)) return true;
		if (char.IsUpper(currChar)) return true;
		if (char.IsDigit(currChar)) return true;
		if (currChar == '_') return true;
		return false;
	}

	private static List<string> ExtractVariablesFromCode(string input)
	{
		var phpVariables = new List<string>();
		var variable = new StringBuilder();

		bool isInVariable = false;
		bool isInOneLineComment = false;
		bool isInMultiLineComment = false;
		bool isInSingleQuotedString = false;
		bool isInDoubleQuotedString = false;

		for (int i = 0; i < input.Length - 1; i++)
		{
			char currChar = input[i];
			char nextChar = input[i + 1];

			#region processing over statements
			if (isInOneLineComment)
			{
				if (currChar == '\n')
				{
					isInOneLineComment = false;
					continue;
				}
				continue;
			}

			if (isInMultiLineComment)
			{
				if (currChar == '*' && nextChar == '/')
				{
					isInMultiLineComment = false;
					continue;
				}
				continue;
			}

			if (isInVariable)
			{
				if (isValidChar(currChar))
				{
					variable.Append(currChar);
				}
				else
				{
					var varToString = variable.ToString();
					if (varToString.Length > 0 && !phpVariables.Contains(varToString))
					{
						phpVariables.Add(varToString);
					}
					isInVariable = false;
					variable.Clear();
				}
			}

			if (isInSingleQuotedString)
			{
				if (currChar == '\'')
				{
					isInSingleQuotedString = false;
					continue;
				}
			}

			if (isInDoubleQuotedString)
			{
				if (currChar == '"')
				{
					isInDoubleQuotedString = false;
					continue;
				}
			}
			#endregion

			#region define statements
			if (!isInDoubleQuotedString && !isInSingleQuotedString)
			{
				if (currChar == '#')
				{
					isInOneLineComment = true;
					continue;
				}
				else if (currChar == '/' && nextChar == '/')
				{
					i++;
					isInOneLineComment = true;
					continue;
				}
				else if (currChar == '/' && nextChar == '*')
				{
					i++;
					isInMultiLineComment = true;
					continue;
				}
			}
			else
			{
				if (currChar == '\\')
				{
					i++;
					continue;
				}
			}

			if (currChar == '"')
			{
				isInDoubleQuotedString = true;
				continue;
			}

			if (currChar == '\'')
			{
				isInSingleQuotedString = true;
				continue;
			}

			if (currChar == '$')
			{
				isInVariable = true;
				continue;
			}
			#endregion
		}

		return phpVariables;
	}

	private static string ReadInput()
	{
		var result = new StringBuilder();
		while (true)
		{
			var currLine = Console.ReadLine();
			result.AppendLine(currLine);
			if (currLine == "?>") break;
		}

		return result.ToString();
	}
}