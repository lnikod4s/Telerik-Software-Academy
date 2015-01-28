using System;
using System.Linq;
/*Problem 3. Compare char arrays
-----------------------------------------------------------------------------------
Write a program that compares two char arrays lexicographically (letter by letter).
*/
class ComparingCharArrays
{
	static void Main()
	{
		Console.WriteLine("Enter a length for the first array:");
		int N = int.Parse(Console.ReadLine());
		char[] firstArray = new char[N];
		Initialize(firstArray);

		Console.WriteLine("Enter a length for the first array:");
		int M = int.Parse(Console.ReadLine());
		char[] secondArray = new char[M];
		Initialize(secondArray);

		CompareTwoArrays(firstArray, secondArray);
	}

	private static void Initialize(char[] someArray)
	{
		for (int i = 0; i < someArray.Length; i++)
		{
			someArray[i] = char.Parse(Console.ReadLine());
		}
	}

	private static void CompareTwoArrays(char[] firstArray, char[] secondArray)
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
