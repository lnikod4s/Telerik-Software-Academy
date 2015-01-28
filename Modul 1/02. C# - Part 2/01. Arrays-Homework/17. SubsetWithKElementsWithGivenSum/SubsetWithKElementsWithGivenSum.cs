using System;
using System.Collections.Generic;
using System.Linq;
/*Problem 17.* Subset K with sum S
------------------------------------------------------------------------------------------------------------------------
Write a program that reads three integer numbers N, K and S and an array of N elements from the console. Find in the array a subset of K elements that have sum S or indicate about its absence.
*/
class SubsetWithKElementsWithGivenSum
{
	static void Main()
	{
		Console.WriteLine("Enter a size of array: ");
		int size = int.Parse(Console.ReadLine());

		Console.WriteLine("Enter a number of elements in subset: ");
		int elements = int.Parse(Console.ReadLine());

		if (size < elements)
		{
			Console.WriteLine("Number of elements must be smaller or equal than the array's length!");
			return;
		}

		Console.WriteLine("Enter a number for a sum that we are going to looking for: ");
		int sum = int.Parse(Console.ReadLine());

		int[] numbers = new int[size];
		Console.WriteLine("Enter {0} number(s) to array: ", size);
		for (int i = 0; i < numbers.Length; i++)
		{
			numbers[i] = int.Parse(Console.ReadLine());
		}

		PrintElementOfArray(numbers);
		FindAndPrintSubsetsWithMaxSum(numbers, elements, sum);
	}

	static void FindAndPrintSubsetsWithMaxSum(int[] numbers, int elements, int sum)
	{
		Console.Write("Subsets with {0} elements and sum {1}: ", elements, sum);

		int totalSubsets = (int)(Math.Pow(2, numbers.Length) - 1); // Total subsets = 2^n - 1
		bool isFoundSubset = false;

		for (int i = 1; i <= totalSubsets; i++)
		{
			if (ElementsInSubset(i) == elements)
			{
				List<int> currentSubset = numbers.Where((t, j) => ((i >> j) & 1) == 1).ToList();

				if (currentSubset.Sum() == sum)
				{
					isFoundSubset = true;
					PrintSubsetWithGivenSum(currentSubset);
				}
			}
		}

		if (!isFoundSubset) Console.WriteLine("There are no subsets with {0} elements and Sum {1}...", elements, sum);
	}

	static int ElementsInSubset(int currentNumber)
	{
		int elementsInSubset = 0;
		while (currentNumber != 0)
		{
			elementsInSubset += currentNumber & 1;
			currentNumber >>= 1;
		}
		return elementsInSubset;
	}

	static void PrintElementOfArray(int[] numbers)
	{
		Console.WriteLine("Array's elements: {0}", string.Join(", ", numbers));
	}

	static void PrintSubsetWithGivenSum(List<int> subset)
	{
		Console.WriteLine(string.Join(", ", subset));
	}
}
