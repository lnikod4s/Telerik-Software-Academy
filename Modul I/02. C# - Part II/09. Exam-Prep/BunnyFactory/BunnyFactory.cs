using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

// C# Part 2 - 2013/2014 @ 22 Jan 2014 - Evening
// 2. Bunny Factory
class BunnyFactory
{
	private static int cycleIndex = 0;
	private static List<int> bunnies = new List<int>(); 
	static void Main()
	{
		bunnies = ReadInputData();
		
		ProcessingCurrentCycle();

		Console.WriteLine(string.Join(" ", bunnies));
	}

	private static List<int> ReadInputData()
	{
		string currLine = Console.ReadLine();
		while (currLine != "END")
		{
			bunnies.Add(int.Parse(currLine));
			currLine = Console.ReadLine();
		}

		return bunnies;
	}

	private static void ProcessingCurrentCycle()
	{
		int s = 0;
		if (cycleIndex < bunnies.Count)
		{
			for (int i = 0; i <= cycleIndex; i++)
			{
				s += bunnies[i];
			}
		}
		else
		{
			return;
		}
		

		if (cycleIndex + 1 + s > bunnies.Count)
		{
			return;
		}

		BigInteger sum = 0;
		BigInteger product = 1;
		for (int i = cycleIndex + 1; i <= cycleIndex + s; i++)
		{
			sum += bunnies[i];
			product *= bunnies[i];
		}

		var result = new StringBuilder();
		result.Append(sum);
		result.Append(product);
		for (int i = cycleIndex + s + 1; i < bunnies.Count; i++)
		{
			result.Append(bunnies[i]);
		}

		if (result.ToString().Contains("0") || result.ToString().Contains("1"))
		{
			result.Replace("1", string.Empty);
			result.Replace("0", string.Empty);
		}

		bunnies.Clear();
		string newResult = result.ToString();
		bunnies.AddRange(newResult.Select(t => t - '0'));

		// Next cycle begins
		cycleIndex++;
		ProcessingCurrentCycle();
	}
}