// Telerik Academy Exam 1 @ 27 Dec 2012
// Problem 2. Tribonacci Triangle

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class ExamPrep
{
	static void Main()
	{
		BigInteger a = BigInteger.Parse(Console.ReadLine());
		BigInteger b = BigInteger.Parse(Console.ReadLine());
		BigInteger c = BigInteger.Parse(Console.ReadLine());
		List<BigInteger> nums = new List<BigInteger> { a, b, c };
		int n = int.Parse(Console.ReadLine());

		Console.WriteLine(nums[0]);
		Console.WriteLine(nums[1] + " " + nums[2]);

		for (int i = 3, index = 3; i <= n; i++)
		{
			for (int j = 0; j < i; j++, index++)
			{
				nums.Add(nums[index - 1] + nums[index - 2] + nums[index - 3]);
				Console.Write(nums.Last() + " ");
			}
			Console.WriteLine();
		}
	}
}