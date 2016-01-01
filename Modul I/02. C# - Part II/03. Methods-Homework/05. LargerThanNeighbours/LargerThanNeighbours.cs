using System;
/*Problem 5. Larger than neighbours
------------------------------------------------------------------------------------------------------------------------
Write a method that checks if the element at given position in given array of integers is larger than its two neighbours (when such exist).
*/
class LargerThanNeighbours
{
	static void Main()
	{
		Console.Write("Enter an positive number N (array's length): ");
		int N = int.Parse(Console.ReadLine());

		Console.WriteLine("\nEnter {0} number(s) to array:", N);
		int[] nums = new int[N];
		for (int i = 0; i < nums.Length; i++)
		{
			Console.Write("nums[{0}]->", i);
			nums[i] = int.Parse(Console.ReadLine());
		}

		Console.Write("\nEnter a position that we are going to analyze: ");
		int position = int.Parse(Console.ReadLine());
		if (position < 0 || position >= N) Console.WriteLine("Wrong position! Please try again.");
		
		bool isLarger = CheckNeighbours(nums, position, N);
		Console.WriteLine(isLarger);
	}

	private static bool CheckNeighbours(int[] nums, int position, int N)
	{
		bool result;
		if (position == 0) result = nums[position] > nums[position + 1];
		else if (position == N - 1) result = nums[position] > nums[position - 1];
		else result = nums[position] > nums[position - 1] && nums[position] > nums[position + 1];
		return result;
	}
}