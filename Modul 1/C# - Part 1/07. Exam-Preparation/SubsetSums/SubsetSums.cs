// C# Fundamentals 2011/2012 Part 1 - Sample Exam
// Problem 5. Subset Sums

using System;
using System.Collections.Generic;

class ExamPrep
{
	static void Main()
	{
		long s = long.Parse(Console.ReadLine());
		int n = Int32.Parse(Console.ReadLine());

		long[] numbers = new long[n];
		for (int i = 0; i < n; i++) numbers[i] = long.Parse(Console.ReadLine());

		Dictionary<long, int> sums = new Dictionary<long, int> { { 0, 1 } };
		foreach (var currentElement in numbers)
		{
			Dictionary<long, int> copyOfSums = new Dictionary<long, int>(sums);
			foreach (KeyValuePair<long, int> pair in copyOfSums)
			{
				var currentSum = currentElement + pair.Key;
				if (!sums.ContainsKey(currentSum)) sums.Add(currentSum, pair.Value);
				else sums[currentSum] += pair.Value;
			}
		}
		sums[0]--; //remove the empty subset
		Console.WriteLine(sums.ContainsKey(s) ? sums[s] : 0);
	}
}