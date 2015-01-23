using System;
/*Problem 13.*
------------------------------------------------------------------------------------------------------
Write a program that sorts an array of integers using the Merge sort algorithm (find it in Wikipedia).
*/
class MergeSortAlgorithm
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

		int[] tmp = new int[N];

		Console.WriteLine("Before sorting: {0}", string.Join(", ", nums));

		MergeSort(nums, tmp, 0, nums.Length - 1);

		Console.WriteLine("After sorting: {0}", string.Join(", ", nums)); 
	}

	static void MergeSort(int[] elements, int[] temp, int start, int end)
	{
		if (start >= end) return;  // Array with 1 element

		int middle = start + (end - start) / 2; // Define a middle of the array

		MergeSort(elements, temp, start, middle);
		MergeSort(elements, temp, middle + 1, end);
		CompareAndSort(elements, temp, start, middle, end);
	}

	static void CompareAndSort(int[] elements, int[] temp, int start, int middle, int end)
	{
		int i = start; // 'temp' index
		int l = start, m = middle + 1; // 'elements' indexes

		while (l <= middle && m <= end)
			temp[i++] = (elements[l] > elements[m]) ? elements[m++] : elements[l++];

		while (l <= middle) temp[i++] = elements[l++];

		while (m <= end) temp[i++] = elements[m++];

		for (int j = start; j <= end; j++) elements[j] = temp[j];
	}
}
