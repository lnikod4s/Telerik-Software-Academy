// C# Fundamentals 2011/2012 Part 1 - Test Exam
// Problem 4. Odd Number

using System;
using System.Linq;
using System.Numerics;

class ExamPrep
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());

		BigInteger[] nums = new BigInteger[N];
		for (int i = 0; i < N; i++)
		{
			nums[i] = BigInteger.Parse(Console.ReadLine());
		}

		var g = nums.GroupBy(i => i);
		foreach (var item in g)
		{
			if (item.Count() % 2 != 0)
			{
				Console.WriteLine(item.Key);
			}
		}
	}
}