using System;
using System.Linq;
using System.Numerics;
using System.Text;
// C# Part 2 - 2013/2014 @ 14 Sept 2013 - Evening
// 1. Zerg!!!
class Zerg
{
	static void Main()
	{
		string[] alpha = { "Rawr", "Rrrr", "Hsst", "Ssst", "Grrr", "Rarr", "Mrrr", "Psst", "Uaah", "Uaha", "Zzzz", "Bauu", "Djav", "Myau", "Gruh" };

		var input = Console.ReadLine();

		var currLetter = new StringBuilder();
		BigInteger result = 0;
		foreach (var c in input)
		{
			currLetter.Append(c);
			if (alpha.Contains(currLetter.ToString()))
			{
				int currDigit = Array.IndexOf(alpha, currLetter.ToString());
				result *= 15;
				result += currDigit;
				currLetter.Clear();
			}
		}

		Console.WriteLine(result);
	}
}