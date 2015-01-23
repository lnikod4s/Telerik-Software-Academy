using System;
using System.Collections.Generic;

/*Problem 16.*
------------------------------------------------------------------------------------------------------------------------
We are given an array of integers and a number S. Write a program to find if there exists a subset of the elements of the array that has a sum S. Example: arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 ? yes (1+2+5+6)
*/
class SubsetWithGivenSum
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
