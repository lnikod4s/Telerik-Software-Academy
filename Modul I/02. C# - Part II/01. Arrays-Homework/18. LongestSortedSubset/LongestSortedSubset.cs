using System;
using System.Collections.Generic;
using System.Linq;
/*Problem 18.* Remove elements from array
------------------------------------------------------------------------------------------------------------------------
Write a program that reads an array of integers and removes from it a minimal number of elements in such way that the remaining array is sorted in increasing order. Print the remaining sorted array. Example: {6, 1, 4, 3, 0, 3, 6, 4, 5} ? {1, 3, 3, 4, 5}
*/
class LongestSortedSubset
{
	static List<int>[] allBestSubsets = new List<int>[40];
	static int index = 0;

	static void Main()
	{
		Console.WriteLine("Enter a number for the array's length: ");
		int n = int.Parse(Console.ReadLine());

		int[] numbers = new int[n];
		Console.WriteLine("Enter {0} number(s) to array: ", n);
		for (int i = 0; i < numbers.Length; i++)
		{
			numbers[i] = int.Parse(Console.ReadLine());
		}

		FindAllSubsetsWithGivenSum(numbers);
		PrintLongestSubsets(numbers);
	}

	static void PrintLongestSubsets(int[] numbers)
	{
		Console.WriteLine("Array's elements: {0}", string.Join(", ", numbers));

		Console.WriteLine("Longest subset(s) with increasing elements: ");
		for (int i = 0; i < index; i++) Console.WriteLine(string.Join(", ", allBestSubsets[i]));
	}

	// Find all subsets using BITWISE REPRESENTATION
	static void FindAllSubsetsWithGivenSum(int[] numbers)
	{
		List<int> subset = new List<int>();
		long bestLength = 0;
		long totalSubsets = (long)(Math.Pow(2, numbers.Length) - 1); // Number of subsets

		for (long i = totalSubsets; i >= 1; i--)
		{
			long elementInSubset = ElementsInSubset(i);

			if (elementInSubset < bestLength) continue;

			subset.Clear();

			subset.AddRange(numbers.Where((t, j) => ((i >> j) & 1) == 1));

			if (IsIncreasingElements(subset))
			{
				if (bestLength < elementInSubset)
				{
					allBestSubsets = new List<int>[40];
					index = 0;
				}
				bestLength = elementInSubset;
				allBestSubsets[index++] = new List<int>(subset);
			}
		}
	}

	// Optimization method
	static long ElementsInSubset(long currentNumber)
	{
		long elementsInSubset = 0;

		while (currentNumber != 0)
		{
			elementsInSubset += currentNumber & 1;
			currentNumber >>= 1;
		}
		return elementsInSubset;
	}

	static bool IsIncreasingElements(List<int> numbers)
	{
		for (int i = 0; i < numbers.Count - 1; i++)
			if (numbers[i] > numbers[i + 1])
				return false;

		return true;
	}
}
