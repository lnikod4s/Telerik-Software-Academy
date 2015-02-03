// C# Basics Exam 14 April 2014 Morning
// Problem 02. Biggest Triple

using System;
using System.Collections.Generic;
using System.Linq;

class BiggestTriple
{
	static void Main()
	{
		string input = Console.ReadLine();
		int[] nums = input.Split(' ').Select(int.Parse).ToArray();
		
		if (nums.Length == 1)
		{
			Console.WriteLine(nums[0]);
		}
		else if (nums.Length == 2)
		{
			Console.WriteLine(nums[0] + " " + nums[1]);
		}
		else if (nums.Length == 3)
		{
			Console.WriteLine(nums[0] + " " + nums[1] + " " + nums[2]);
		}
		else
		{
			var slices = new List<string>();
			var sums = new List<int>();
			for (int i = 0; i < nums.Length; i += 3)
			{
				if (nums.Length - 1 - i < 3)
				{
					if (nums.Length - 1 - i == 0)
					{
						slices.Add("" + nums[i]);
						sums.Add(nums[i]);
						break;
					}
					if (nums.Length - 1 - i == 1)
					{
						slices.Add("" + nums[i] + " " + nums[i + 1]);
						sums.Add(nums[i] + nums[i + 1]);
						break;
					}
				}
				slices.Add(nums[i] + " " + nums[i + 1] + " " + nums[i + 2]);
				sums.Add(nums[i] + nums[i + 1] + nums[i + 2]);
			}
			int indexOfBiggestElement = sums.IndexOf(sums.Max());
			Console.WriteLine(slices[indexOfBiggestElement]);
		}
	}
}
