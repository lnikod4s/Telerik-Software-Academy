﻿using System;
/*Problem 4. Binary search
------------------------------------------------------------------------------------------------------------------------
Write a program, that reads from the console an array of N integers and an integer K, sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K.
*/
class BinarySearch
{
	static void Main()
	{
		Console.Write("Enter a number N (size of array): ");
		int N = int.Parse(Console.ReadLine());

		Console.Write("Enter a number K: ");
		int K = int.Parse(Console.ReadLine());

		int[] numbers = new int[N];
		Console.WriteLine("\nEnter {0} number(s) to array: ", N);
		for (int i = 0; i < numbers.Length; i++)
		{
			Console.Write("   {0}: ", i + 1);
			numbers[i] = int.Parse(Console.ReadLine());
		}

		PrintLargestNumber(numbers, K);
	}

	// Prints largest number smaller or equal to 'k' using method Array.BinarySearch()
	static void PrintLargestNumber(int[] numbers, int k)
	{
		Array.Sort(numbers);

		int index = Array.BinarySearch(numbers, k);
		index = index >= 0 ? index : (index == -1 ? -1 : Math.Abs(index + 2));

		if (index != -1)
		{
			Console.WriteLine("\nFound smaller or equal number to K = {0}", k);
			Console.WriteLine("-> Result number: {0}\n", numbers[index]);
		}
		else
		{
			Console.WriteLine("\n- There is no smaller or equal to K = {0} number in array!\n", k);
		}
	}
}