using System;
using System.Linq;
/*Problem 4. Appearance count
------------------------------------------------------------------------------
Write a method that counts how many times given number appears in given array.
Write a test program to check if the method is workings correctly.
*/
class ApperanceCount
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

		Console.Write("\nEnter a number that we are going to looking for in the array: ");
		int searchedNumber = int.Parse(Console.ReadLine());

		int counter = GetNumberOfOccurs(nums, searchedNumber);
		Console.WriteLine("\nNumber {0} occurs {1} time(s) in the array!\n", searchedNumber,
			counter);
	}

	public static int GetNumberOfOccurs(int[] nums, int searchedNumber)
	{
		return nums.Count(t => t == searchedNumber);
	}
}