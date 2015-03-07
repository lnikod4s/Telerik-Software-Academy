using System;
using System.Collections.Generic;

/// <summary>
/// C# Part 2 - 2015/2016 @ 5 March 2015 - Morning
/// </summary>
class Problem5
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());

		var result = new List<char>();
		for (int i = 0; i < N; i++)
		{
			string currLine = Console.ReadLine();
			currLine = currLine.Replace(" is before ", "<");
			currLine = currLine.Replace(" is after ", ">");
			for (int j = 0; j < currLine.Length; j++)
			{
				char firstDigit = currLine[0];
				char order = currLine[1];
				char secondDigit = currLine[2];

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
}