using System;
using System.Linq;
using System.Numerics;
using System.Text;

// C# Part 2 - 2013/2014 @ 24 Jan 2014 - Evening
// 1. StrangeLand Numbers
class StrangeLandNumbers
{
	static void Main()
	{
		string[] alpha = { "f", "bIN", "oBJEC", "mNTRAVL", "lPVKNQ", "pNWE", "hT" };
		var input = Console.ReadLine();

		var currLetter = new StringBuilder();
		BigInteger result = 0;
		foreach (var c in input)
		{
			currLetter.Append(c);
			if (alpha.Contains(currLetter.ToString()))
			{
				int currDigit = Array.IndexOf(alpha, currLetter.ToString());
				result *= 7;
				result += currDigit;
				currLetter.Clear();
			}
		}

		Console.WriteLine(result);
	}
}