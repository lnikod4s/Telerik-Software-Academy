using System;
/*Problem 1. Allocate array
--------------------------------------------------------------------------------------------------------------
Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5.
Print the obtained array on the console.
*/
class ArrayWith20Numbers
{
	static void Main()
	{
		int[] nums = new int[20];
		for (int i = 0; i < nums.Length; i++)
		{
			nums[i] = i * 5;
		}

		for (int i = 0; i < nums.Length; i++)
		{
			Console.Write(i != nums.Length - 1 ? nums[i] + ", " : nums[i] + "\n");
		}
	}
}
