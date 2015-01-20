// Telerik Academy Exam 1 @ 29 Dec 2012
// Problem 2. Quadronacci Numbers


using System;
using System.Collections.Generic;

class ExamPrep
{
	static void Main()
	{
		List<long> nums = new List<long>();
		for (int i = 0; i < 4; i++)
		{
			nums.Add(long.Parse(Console.ReadLine()));
		}

		int R = int.Parse(Console.ReadLine());
		int C = int.Parse(Console.ReadLine());

		for (int i = 0; i < R * C; i++)
		{
			if (i >= 4) nums.Add(nums[i - 4] + nums[i - 3] + nums[i - 2] + nums[i - 1]);

			Console.Write((i + 1) % C == 0 ? nums[i] + "\n" : nums[i] + " ");
		}
	}
}