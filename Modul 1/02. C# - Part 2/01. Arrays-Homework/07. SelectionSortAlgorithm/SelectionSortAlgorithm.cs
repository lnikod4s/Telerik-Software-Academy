using System;
/*Problem 7. Selection sort
----------------------------------------------------------------------------------------------------------------------
Sorting an array means to arrange its elements in increasing order. Write a program to sort an array.
Use the Selection sort algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.
*/
class SelectionSortAlgorithm
{
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

		Console.Write("Before sorting: ");
		Console.WriteLine(string.Join(" ", nums));

		nums = SelectionSort(nums);

		Console.Write("After sorting: ");
		Console.WriteLine(string.Join(" ", nums) + "\n");
	}

	// Classical implementation of Selection Sort Algorithm
	private static int[] SelectionSort(int[] nums)
	{
		for (int i = 0; i < nums.Length - 1; i++)
		{
			int index = i;
			for (int j = i + 1; j < nums.Length; j++)
			{
				if (nums[j] < nums[index])
				{
					index = j;
				}
			}
			int swap = nums[i];
			nums[i] = nums[index];
			nums[index] = swap;
		}
		return nums;
	}
}
