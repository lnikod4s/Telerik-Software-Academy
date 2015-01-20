// Telerik Academy Exam 1 @ 6 Dec 2011 Morning
// Problem 2. Tribonacci

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class Tribonacci
{
	static void Main()
	{
		BigInteger a = BigInteger.Parse(Console.ReadLine());
		BigInteger b = BigInteger.Parse(Console.ReadLine());
		BigInteger c = BigInteger.Parse(Console.ReadLine());
		List<BigInteger> nums = new List<BigInteger> { a, b, c };
		int N = int.Parse(Console.ReadLine());

		for (int i = 3; i < N; i++)
		{
			nums.Add(nums[i - 1] + nums[i - 2] + nums[i - 3]);
		}
		Console.WriteLine(nums.Last());
	}
}
