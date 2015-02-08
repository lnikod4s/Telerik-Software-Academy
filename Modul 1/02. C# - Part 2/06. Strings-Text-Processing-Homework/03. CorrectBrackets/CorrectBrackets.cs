using System;
using System.Linq;
/*Problem 3. Correct brackets
-------------------------------------------------------------------------------------
Write a program to check if in a given expression the brackets are put correctly.
Example of correct expression: ((a+b)/5-d). Example of incorrect expression: )(a+b)).
*/
class CorrectBrackets
{
	const string OPENING_BRACKET = "(";
	const string CLOSING_BRACKET = ")";
	static void Main()
	{
		Console.Write("Enter an expression with brackets: ");
		string expression = Console.ReadLine();

		CheckExpression(expression);
		Console.WriteLine(CheckExpression(expression)
			? "The brackets in your expression are put correctly."
			: "The brackets in your expression are put incorrectly or are missing.");
	}

	private static bool CheckExpression(string expression)
	{
		bool isValid = false;
		if (expression.Contains(OPENING_BRACKET) && expression.Contains(CLOSING_BRACKET))
		{
			if (OPENING_BRACKET.Count() == CLOSING_BRACKET.Count()
			&& expression.LastIndexOf(OPENING_BRACKET, StringComparison.Ordinal) < expression.IndexOf(CLOSING_BRACKET, StringComparison.Ordinal))
			{
				isValid = true;
			}
		}

		return isValid;
	}
}