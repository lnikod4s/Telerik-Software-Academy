using System;
using System.Linq;
/*Problem 2.
--------------------------------------------------------------------------------------------
Write a program that reads two arrays from the console and compares them element by element.
*/
class AreTwoArraysEqual
{
	static void Main()
	{
		Console.WriteLine("Enter a length for the first array:");
		int N = int.Parse(Console.ReadLine());
		int[] firstArray = new int[N];
		Initialize(firstArray);

		Console.WriteLine("Enter a length for the first array:");
		int M = int.Parse(Console.ReadLine());
		int[] secondArray = new int[M];
		Initialize(secondArray);

		CompareTwoArrays(firstArray, secondArray);
	}

	private static void Initialize(int[] someArray)
	{
		for (int i = 0; i < someArray.Length; i++)
		{
			someArray[i] = int.Parse(Console.ReadLine());
		}
	}

	private static void CompareTwoArrays(int[] firstArray, int[] secondArray)
	{
		if (firstArray.Length > secondArray.Length)
		{
			Console.WriteLine("The first array has bigger length than the second array, so they cannot be equal.");
		}
		else if (firstArray.Length < secondArray.Length)
		{
			Console.WriteLine("The second array has bigger length than the first array, so they cannot be equal.");
		}
		else
		{
			Array.Sort(firstArray);
			Array.Sort(secondArray);

			Console.WriteLine("Result:");
			Console.WriteLine("The two arrays have equal length...");

			if (firstArray.Where((t, i) => t != secondArray[i]).Any())
			{
				Console.WriteLine("but different elements.");
				return;
			}
			Console.WriteLine("and equal elements.");
		}
	}
}
