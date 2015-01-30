// C# Basics Exam 12 April 2014 Morning
// Problem 2. Pairs

using System;
using System.Collections.Generic;
using System.Linq;

class Pairs
{
	static void Main()
	{
		string input = Console.ReadLine();
		int[] nums = input.Split(' ').Select(int.Parse).ToArray();

		var values = new List<int>();
		var diffs = new List<int>();
		for (int i = 0; i < nums.Length; i += 2)
		{
			values.Add(nums[i] + nums[i + 1]);
		}

		for (int i = 1; i < values.Count; i++)
		{
			diffs.Add(Math.Abs(values[i] - values[i - 1]));
		}

		if (values.All(o => o == values[0]))
		{
			Console.WriteLine("Yes, value={0}", values[0]);
		}
		else
		{
			Console.WriteLine("No, maxdiff={0}", diffs.Max());
		}
	}
}
