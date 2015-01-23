using System;
using System.Linq;

/*Problem 11.
------------------------------------------------------------------------------------------------------------------------
Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia).
*/
class BinarySearchAlgorithm
{
	static void Main()
	{
		Console.WriteLine("Enter a number for N:");
		int N = int.Parse(Console.ReadLine());

		Console.WriteLine("Enter a number which index we are going to looking for:");
		int S = int.Parse(Console.ReadLine());

		int[] nums = new int[N];
		Console.WriteLine("Enter {0} number(s) to array:", N);
		for (int i = 0; i < N; i++)
		{
			nums[i] = int.Parse(Console.ReadLine());
		}

		Array.Sort(nums);
		Console.WriteLine("Array after sorting: {0}", string.Join(", ", nums));

		int index = BinarySearch(nums, S, 0, nums.Length);

		if (index != -1) Console.WriteLine("Number {0} found at index: {1}", S, index);
		else Console.WriteLine("Number {0} not found!", S);
	}

	private static int BinarySearch(int[] nums, int value, int start, int end)
	{
		if (end < start)
		{
			return -1;
		}
		else
		{
			int middleIndex = (start + end) / 2;
			if (nums[middleIndex] > value)
			{
				return BinarySearch(nums, value, start, middleIndex - 1);
			}
			else if (nums[middleIndex] < value)
			{
				return BinarySearch(nums, value, middleIndex + 1, end);
			}
			else
			{
				return middleIndex;
			}
		}
	}
}
