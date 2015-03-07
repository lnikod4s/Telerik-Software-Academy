using System;
using System.Linq;
using System.Numerics;

/// <summary>
/// C# Part 2 - 2015/2016 @ 5 March 2015 - Morning
/// </summary>
class Problem2
{
	private static long absDiff;
	static void Main()
	{
		int[] numbers = Console.ReadLine()
							   .Split()
							   .Select(int.Parse)
							   .ToArray();

		BigInteger sumOddDiffs = 0;
		for (int i = 1; i < numbers.Length; i++)
		{
			long currNum = numbers[i];
			long prevNum = numbers[i - 1];
			

			if (currNum > prevNum && prevNum < 0)
			{
				absDiff = currNum + Math.Abs(prevNum);
			}
			else if (currNum > prevNum && prevNum > 0)
			{
				absDiff = currNum - prevNum;
			}

			if (currNum < prevNum && currNum < 0)
			{
				absDiff = prevNum + Math.Abs(currNum);
			}
			else if (currNum < prevNum && currNum > 0)
			{
				absDiff = prevNum - currNum;
			}

			if (absDiff % 2 == 0)
			{
				i++;
				continue;
			}
			else
			{
				sumOddDiffs += absDiff;
				continue;
			}
		}

		Console.WriteLine(sumOddDiffs);
	}
}