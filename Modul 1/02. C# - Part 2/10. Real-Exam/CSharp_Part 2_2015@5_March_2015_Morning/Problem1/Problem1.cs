using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// C# Part 2 - 2015/2016 @ 5 March 2015 - Morning
/// </summary>
class Problem1
{
	static void Main()
	{
		string[] alpha = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s" };
		string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

		var currLetter = new StringBuilder();
		long temp = 0;
		long sumInDec = 0;
		for (int i = 0; i < input.Length; i++)
		{
			for (int j = 0; j < input[i].Length; j++)
			{
				currLetter.Append(input[i][j]);
				if (alpha.Contains(currLetter.ToString()))
				{
					int currDigit = Array.IndexOf(alpha, currLetter.ToString());
					temp *= 19;
					temp += currDigit;
					currLetter.Clear();
				}
			}

			sumInDec += temp;
			temp = 0;
		}

		long sumInDecCopy = sumInDec;
		List<string> alphaNum = new List<string>();
		do
		{
			alphaNum.Add(alpha[sumInDecCopy % 19]);
			sumInDecCopy /= 19;
		}
		while (sumInDecCopy != 0);

		alphaNum.Reverse(); // Reversing the number to get the real value
		string suminAlpha = string.Join(string.Empty, alphaNum);

		Console.WriteLine("{0} = {1}", suminAlpha, sumInDec);
	}
}