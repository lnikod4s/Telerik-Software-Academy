using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class Problem_3
{
	private static int count = 0;
	static void Main()
	{
		string number = Console.ReadLine();
		MagicTrick(number);
	}

	private static void MagicTrick(string number)
	{
		var sums = new List<int>();
		number = number.Remove(number.Length - 1);
		while (number != "")
		{
			int sum = 0;
			for (int i = 0; i < number.Length; i += 2)
			{
				sum += number[i] - '0';
			}
			sums.Add(sum);
			number = number.Remove(number.Length - 1);
		}

		BigInteger product = sums.Aggregate<int, BigInteger>(1, (current, sum) => current * sum);
		number = "" + product;
		count++;

		if (number.Length == 1)
		{
			Console.WriteLine(count);
			Console.WriteLine(number);
			return;
		}

		if (count == 10)
		{
			Console.WriteLine(number);
			return;
		}

		if (count != 10)
		{
			MagicTrick(number);
		}
	}
}