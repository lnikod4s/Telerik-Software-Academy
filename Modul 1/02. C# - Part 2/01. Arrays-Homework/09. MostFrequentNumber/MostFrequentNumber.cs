using System;
using System.Collections.Generic;
using System.Linq;
/*Problem 9.
----------------------------------------------------------------
Write a program that finds the most frequent number in an array. 
Example: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} ? 4 (5 times)
*/
class MostFrequentNumber
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

		Dictionary<int, int> occurences = new Dictionary<int, int>();
		for (int i = 0; i < N; i++)
		{
			if (!occurences.ContainsKey(nums[i]))
			{
				occurences.Add(nums[i], 1);
			}
			else
			{
				occurences[nums[i]]++;
			}
		}

		int max = occurences.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

		Console.WriteLine("Array's elements: {0}", string.Join(", ", nums));
		Console.WriteLine("Most frequent number: ");
		foreach (KeyValuePair<int, int> pair in occurences)
		{
			if (pair.Value == occurences[max])
			{
				Console.WriteLine("{0} ({1} times)", pair.Key, occurences[pair.Key]);
			}
		}
	}
}