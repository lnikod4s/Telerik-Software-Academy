using System;
/*Problem 4.Problem 4. Maximal sequence
------------------------------------------------------------------------------
Write a program that finds the maximal sequence of equal elements in an array.
Example:

input							output
{2, 1, 1, 2, 3, 3, 2, 2, 2, 1}	{2, 2, 2}
*/
class MaxSequenceOfEqualElements
{
	static int bestLength = 0, bestElement = 0;
	static void Main()
	{
		Console.WriteLine("Enter a lenght of the array:");
		int N = int.Parse(Console.ReadLine());

		int[] nums = new int[N];
		Console.WriteLine("Enter {0} number(s) to array:", N);
		for (int i = 0; i < N; i++)
		{
			nums[i] = int.Parse(Console.ReadLine());
		}

		FindBestSequence(nums);

		Console.Write("The array contains following elements: " + "{" + string.Join(", ", nums) + "}\n");
		Console.Write("The maximal sequence of equal elements in the array is: {");
		for (int i = 0; i < bestLength; i++)
		{
			Console.Write(i != bestLength - 1 ? bestElement + ", " : bestElement + "}\n");
		}
	}

	private static void FindBestSequence(int[] nums)
	{
		int currLength = 1, currElement = nums[0];

		if (nums.Length == 1)
		{
			bestElement = currElement;
			bestLength = 1;
			return;
		}

		for (int i = 1; i < nums.Length; i++)
		{
			if (nums[i] == currElement)
			{
				currLength++;
			}
			else
			{
				currElement = nums[i];
				currLength = 1;
			}

			if (currLength >= bestLength)
			{
				bestLength = currLength;
				bestElement = currElement;
			}
		}
	}
}
