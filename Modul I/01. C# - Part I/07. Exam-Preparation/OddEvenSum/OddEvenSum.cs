// SoftUni C# Basics Exam 10 April 2014 Evening
// Problem 2. Odd Even Sum

using System;

class OddEvenSum
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		
		int[] nums = new int[2 * n];
		int oddSum = 0, evenSum = 0;
		for (int i = 0; i < 2 * n; i++)
		{
			nums[i] = int.Parse(Console.ReadLine());
			if (i % 2 == 0)
			{
				oddSum += nums[i];
			}
			else
			{
				evenSum += nums[i];
			}
		}

		if (oddSum == evenSum)
		{
			Console.WriteLine("Yes, sum=" + oddSum);
		}
		else
		{
			Console.WriteLine("No, diff=" + Math.Abs(oddSum - evenSum));
		}
	}
}
