using System;
using System.Threading;

/*Problem 6. First larger than neighbours
------------------------------------------------------------------------------------------------------------------------
Write a method that returns the index of the first element in array that is larger than its neighbours, or -1, if there’s no such element.
Use the method from the previous exercise.
*/
class FirstLargerThanNeighbours
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

		int count = 0;
		for (int i = 0; i < nums.Length; i++)
		{
			if (CheckNeighbours(nums, i, N))
			{
				Console.WriteLine("The index of the first element in array that is larger than its neighbours is: {0}", i);
				count++;
				return;
			}
		}

		if (count == 0) Console.WriteLine(-1);
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