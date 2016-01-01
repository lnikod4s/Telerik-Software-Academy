// C# Basics Exam 11 April 2014 Morning
// Problem 2. Sum Of Elements

using System;
using System.Linq;

class SumOfElements
{
	static void Main()
	{
		string input = Console.ReadLine();
		int[] nums = input.Split(' ').Select(int.Parse).ToArray();

		int max = 0;
		int sum = 0;
		foreach (int t in nums)
		{
			sum += t;
			if (max < t) max = t;
		}
		

		if (sum == 2 * max)
		{
			Console.WriteLine("Yes, sum=" + max);
		}
		else
		{
			int diff = Math.Abs(sum - 2 * max);
			Console.WriteLine("No, diff=" + diff);
		}
	}
}
