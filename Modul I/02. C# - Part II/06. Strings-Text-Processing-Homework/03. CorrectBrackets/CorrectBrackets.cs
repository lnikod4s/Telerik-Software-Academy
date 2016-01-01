using System;
using System.Collections.Generic;
using System.Linq;
/*Problem 3. Correct brackets
-------------------------------------------------------------------------------------
Write a program to check if in a given expression the brackets are put correctly.
Example of correct expression: ((a+b)/5-d). Example of incorrect expression: )(a+b)).
*/
class CorrectBrackets
{
	private static readonly char[] OpenParentheses = { '(', '[', '{' };
	private static readonly char[] CloseParentheses = { ')', ']', '}' };
	static void Main()
	{
		Console.Write("Enter an expression with brackets: ");
		string expression = Console.ReadLine();

		CheckExpression(expression);
		Console.WriteLine(CheckExpression(expression)
			? "The brackets in your expression are put correctly."
			: "The brackets in your expression are put incorrectly or are missing.");
	}

	private static bool CheckExpression(string input)
	{
		// Indices of the currently open parentheses:
		Stack<int> parentheses = new Stack<int>();

		foreach (char chr in input)
		{
			int index;

			// Check if the 'chr' is an open parenthesis, and get its index:
			if ((index = Array.IndexOf(OpenParentheses, chr)) != -1)
			{
				parentheses.Push(index);  // Add index to stach
			}
			// Check if the 'chr' is a close parenthesis, and get its index:
			else if ((index = Array.IndexOf(CloseParentheses, chr)) != -1)
			{
				// Return 'false' if the stack is empty or if the currently
				// open parenthesis is not paired with the 'chr':
				if (parentheses.Count == 0 || parentheses.Pop() != index) return false;
			}
		}
		// Return 'true' if there is no open parentheses, and 'false' - otherwise:
		return parentheses.Count == 0;
	}
}