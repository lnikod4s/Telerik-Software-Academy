// C# Basics Exam 12 April 2014 Evening
// Problem 2. Odd Even Elements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class OddEvenElements
{
	static void Main()
	{
		Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
		string input = Console.ReadLine();
		if (input.Length == 0)
		{
			Console.WriteLine("OddSum=No, OddMin=No, OddMax=No, EvenSum=No, EvenMin=No, EvenMax=No");
			return;
		}
		double[] nums = input.Split(' ').Select(double.Parse).ToArray();

		var oddNums = new List<double>();
		var evenNums = new List<double>();
		for (int i = 0; i < nums.Length; i++)
		{
			if (i % 2 == 0)
			{
				oddNums.Add(nums[i]);
			}
			else
			{
				evenNums.Add(nums[i]);
			}
		}
		if (oddNums.Count == 0 || evenNums.Count == 0)
		{
			if (oddNums.Count == 0)
			{
				Console.WriteLine("OddSum=No, OddMin=No, OddMax=No, EvenSum={0:0.##}, EvenMin={1:0.##}, EvenMax={2:0.##}", evenNums.Sum(), evenNums.Min(), evenNums.Max());
			}
			else if (evenNums.Count == 0)
			{
				Console.WriteLine("OddSum={0:0.##}, OddMin={1:0.##}, OddMax={2:0.##}, EvenSum=No, EvenMin=No, EvenMax=No", oddNums.Sum(), oddNums.Min(), oddNums.Max());
			}
		}
		else
		{
			Console.WriteLine("OddSum={0:0.##}, OddMin={1:0.##}, OddMax={2:0.##}, EvenSum={3:0.##}, EvenMin={4:0.##}, EvenMax={5:0.##}", oddNums.Sum(), oddNums.Min(), oddNums.Max(), evenNums.Sum(), evenNums.Min(), evenNums.Max());
		}
	}
}