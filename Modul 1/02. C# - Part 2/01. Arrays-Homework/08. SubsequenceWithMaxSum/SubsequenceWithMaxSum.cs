using System;
/*Problem 8. Maximal sum
----------------------------------------------------------------------------------------------------------------------
Write a program that finds the sequence of maximal sum in given array. 
Example: {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} ? {2, -1, 6, 4} Can you do it with only one loop (with single scan through the elements of the array)?
*/
class SubsequenceWithMaxSum
{
	static int bestStart = 0, bestEnd = 0, bestSum = int.MinValue;
	static void Main()
	{
		Console.WriteLine("Enter a number for N:");
		int N = int.Parse(Console.ReadLine());

		int[] nums = new int[N];
		Console.WriteLine("Enter {0} number(s) to array:", N);
		for (int i = 0; i < N; i++)
		{
			nums[i] = int.Parse(Console.ReadLine());
		}

		FindBestSequence(nums);

		Console.WriteLine("Array's elements: {0} ", string.Join(", ", nums));
		Console.WriteLine("Maximal sum: {0}", bestSum);
		Console.Write("Sequence of maximal sum: ");
		for (int i = bestStart; i <= bestEnd; i++)
		{
			Console.Write(i != bestEnd ? nums[i] + ", " : nums[i] + "\n");
		}
	}

	private static void FindBestSequence(int[] nums)
	{
		int startIndex = 0, currentSum = 0;

		for (int i = 0; i < nums.Length; i++)
		{
			if (currentSum <= 0)
			{
				startIndex = i;
				currentSum = 0;
			}

			currentSum += nums[i];

			if (currentSum > bestSum)
			{
				bestSum = currentSum;
				bestStart = startIndex;
				bestEnd = i;
			}
		}
	}
}