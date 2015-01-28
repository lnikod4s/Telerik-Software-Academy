using System;
using System.Collections.Generic;
/*Problem 10. Find sum in array
---------------------------------------------------------------------------------------------
Write a program that finds in given array of integers a sequence of given sum S (if present).
Example: {4, 3, 1, 4, 2, 5, 8}, S=11 ? {4, 2, 5}
*/
class SequenceOfGivenSum
{
	static void Main()
	{
		long S = long.Parse(Console.ReadLine());
		int N = Int32.Parse(Console.ReadLine());

		long[] numbers = new long[N];
		for (int i = 0; i < N; i++) numbers[i] = long.Parse(Console.ReadLine());

		Dictionary<long, int> sums = new Dictionary<long, int> { { 0, 1 } };
		foreach (var currentElement in numbers)
		{
			Dictionary<long, int> copyOfSums = new Dictionary<long, int>(sums);
			foreach (KeyValuePair<long, int> pair in copyOfSums)
			{
				var currentSum = currentElement + pair.Key;
				if (!sums.ContainsKey(currentSum)) sums.Add(currentSum, pair.Value);
				else sums[currentSum] += pair.Value;
			}
		}
		sums[0]--; //remove the empty subset
		Console.WriteLine(sums.ContainsKey(S) ? sums[S] : 0);
	}
}
