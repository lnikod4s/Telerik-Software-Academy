using System;
using System.Text;

class CSharpCleanCode
{
	/// <summary>
	/// C# Fundamentals 2011/2012 Part 2 - Sample Exam
	/// Problem 1 C# Clean Code
	/// </summary>
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());

		string[] codeWithComments = new string[N];
		for (int i = 0; i < N; i++)
		{
			string currLine = Console.ReadLine() + Environment.NewLine;
			codeWithComments[i] = currLine;
		}

		var result = new StringBuilder();
		for (int i = 0; i < codeWithComments.Length; i++)
		{
			bool isSingleLineComment = false;
			bool isMultiLineComment = false;

			for (int j = 0; j < codeWithComments[i].Length; j++)
			{
				char currChar = codeWithComments[i][j];

				// Define states => isSingleLineComment and isMultiLineComment
				if (currChar == '/' && j + 1 < codeWithComments[i].Length && codeWithComments[i][j + 1] == '/')
				{
					isSingleLineComment = true;
				}

				if (currChar == '/' && j + 1 < codeWithComments[i].Length && codeWithComments[i][j + 1] == '/')
				{
					isMultiLineComment = true;
				}

				// What must be done when we reach a state
				if (isSingleLineComment)
				{
					if (currChar == '\r' && j + 1 < codeWithComments[i].Length && codeWithComments[i][j + 1] == '\n')
					{
						isSingleLineComment = false;
						i++;
					}
					else
					{
						continue;
					}
				}

				if (isMultiLineComment)
				{
					if (currChar == '\\' && j + 1 < codeWithComments[i].Length && codeWithComments[i][j + 1] == '*')
					{
						isMultiLineComment = false;
						i++;
					}
					else
					{
						continue;
					}
				}

				if (!isSingleLineComment && !isMultiLineComment)
				{
					result.Append(currChar);
				}
			}
		}
		
		Console.WriteLine(result);
	}
}