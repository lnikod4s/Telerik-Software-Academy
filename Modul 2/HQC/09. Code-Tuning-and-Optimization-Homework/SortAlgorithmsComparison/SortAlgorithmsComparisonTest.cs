using System;
using System.Diagnostics;

namespace SortAlgorithmsComparison
{
	internal class SortAlgorithmsComparisonTest
	{
		private const int LEFT_INDEX = 0;
		private const int RIGHT_INDEX = 19;
		// Arrays with random values
		private static readonly int[] RandomInts =
		{
			44499,
			97777,
			61955,
			59973,
			41193,
			46492,
			24170,
			6471,
			81197,
			48577,
			87575,
			1874,
			67494,
			71412,
			56445,
			53298,
			73758,
			51233,
			32710,
			4764
		};

		private static readonly double[] RandomDoubles =
		{
			0.1211436928,
			0.0531784174,
			0.4758322224,
			0.9858108183,
			0.4172677647,
			0.3154551402,
			0.6129316231,
			0.2415364845,
			0.9400525739,
			0.0686662735,
			0.2660642200,
			0.1228186682,
			0.0972553439,
			0.9454822662,
			0.8106143743,
			0.2041256105,
			0.7212729970,
			0.9496823468,
			0.2983721539,
			0.3148353632
		};

		private static readonly string[] RandomStrings =
		{
			"ukpLTTabAj",
			"7xfVwuP5vx",
			"OzDjq97ylw",
			"6QvAH5NY9P",
			"jZoyqoRZOr",
			"snm3MTZSPV",
			"bE6tKJvvmM",
			"GuTaPPbj3r",
			"mKhhJYY6MQ",
			"P5Gle3Kk6F",
			"hCVLrOZEhx",
			"o1FYk9biNr",
			"uNBx7NhMam",
			"McZBOyDJ0o",
			"fJZfl4C7m3",
			"kphNJlKKRy",
			"OjgB12LTp1",
			"19WMtBS2z6",
			"a7XYNBCAqu",
			"xorFr2TQp0"
		};

		// Sorted arrays
		private static readonly int[] SortedInts =
		{
			1874,
			4764,
			6471,
			24170,
			32710,
			41193,
			44499,
			46492,
			48577,
			51233,
			53298,
			56445,
			59973,
			61955,
			67494,
			71412,
			73758,
			81197,
			87575,
			97777
		};

		private static readonly double[] SortedDoubles =
		{
			0.0531784174,
			0.0686662735,
			0.0972553439,
			0.1211436928,
			0.1228186682,
			0.2041256105,
			0.2415364845,
			0.26606422,
			0.2983721539,
			0.3148353632,
			0.3154551402,
			0.4172677647,
			0.4758322224,
			0.6129316231,
			0.721272997,
			0.8106143743,
			0.9400525739,
			0.9,
			54822662,
			0.9496823468,
			0.9858108183
		};

		private static readonly string[] SortedStrings =
		{
			"19WMtBS2z6",
			"6QvAH5NY9P",
			"7xfVwuP5vx",
			"GuTaPPbj3r",
			"McZBOyDJ0o",
			"OjgB12LTp1",
			"OzDjq97ylw",
			"P5Gle3Kk6F",
			"a7XYNBCAqu",
			"bE6tKJvvmM",
			"fJZfl4C7m3",
			"hCVLrOZEhx",
			"jZoyqoRZOr",
			"kphNJlKKRy",
			"mKhhJYY6MQ",
			"o1FYk9biNr",
			"snm3MTZSPV",
			"uNBx7NhMam",
			"xorFr2TQp0",
			"ukpLTTabAj"
		};

		// Sorted arrays in reversed order
		private static readonly int[] ReversedInts =
		{
			97777,
			87575,
			81197,
			73758,
			71412,
			67494,
			61955,
			59973,
			56445,
			53298,
			51233,
			48577,
			46492,
			44499,
			41193,
			32710,
			24170,
			6471,
			4764,
			1874
		};

		private static readonly double[] ReversedDoubles =
		{
			0.9858108183,
			0.9496823468,
			0.9454822662,
			0.9400525739,
			0.8106143743,
			0.721272997,
			0.6129316231,
			0.4758322224,
			0.4172677647,
			0.3154551402,
			0.3148353632,
			0.2983721539,
			0.26606422,
			0.2415364845,
			0.2041256105,
			0.1228186682,
			0.1211436928,
			0.0,
			72553439,
			0.0686662735,
			0.0531784174
		};

		private static readonly string[] ReversedStrings =
		{
			"ukpLTTabAj",
			"xorFr2TQp0",
			"uNBx7NhMam",
			"snm3MTZSPV",
			"o1FYk9biNr",
			"mKhhJYY6MQ",
			"kphNJlKKRy",
			"jZoyqoRZOr",
			"hCVLrOZEhx",
			"fJZfl4C7m3",
			"bE6tKJvvmM",
			"a7XYNBCAqu",
			"P5Gle3Kk6F",
			"OzDjq97ylw",
			"OjgB12LTp1",
			"McZBOyDJ0o",
			"GuTaPPbj3r",
			"7xfVwuP5vx",
			"6QvAH5NY9P",
			"19WMtBS2z6"
		};

		internal static void Main()
		{
			Console.WriteLine("------------------------------- INSERTION SORT -------------------------------");

			Console.Write("Random Integers:   ");
			DisplayExecutionTime(() => { SortingAlgorithms.InsertionSort(RandomInts); });

			Console.Write("Sorted Integers:   ");
			DisplayExecutionTime(() => { SortingAlgorithms.InsertionSort(RandomInts); });

			Console.Write("Reversed Integers: ");
			DisplayExecutionTime(() => { SortingAlgorithms.InsertionSort(RandomInts); });

			Console.Write("Random Doubles:    ");
			DisplayExecutionTime(() => { SortingAlgorithms.InsertionSort(RandomDoubles); });

			Console.Write("Sorted Doubles:    ");
			DisplayExecutionTime(() => { SortingAlgorithms.InsertionSort(RandomDoubles); });

			Console.Write("Reversed Doubles:  ");
			DisplayExecutionTime(() => { SortingAlgorithms.InsertionSort(RandomInts); });

			Console.Write("Random Strings:    ");
			DisplayExecutionTime(() => { SortingAlgorithms.InsertionSort(RandomStrings); });

			Console.Write("Sorted Strings:    ");
			DisplayExecutionTime(() => { SortingAlgorithms.InsertionSort(RandomStrings); });

			Console.Write("Reversed Strings:  ");
			DisplayExecutionTime(() => { SortingAlgorithms.InsertionSort(RandomStrings); });

			Console.WriteLine("------------------------------- SELECTION SORT -------------------------------");

			Console.Write("Random Integers:   ");
			DisplayExecutionTime(() => { SortingAlgorithms.SelectionSort(RandomInts); });

			Console.Write("Sorted Integers:   ");
			DisplayExecutionTime(() => { SortingAlgorithms.SelectionSort(RandomInts); });

			Console.Write("Reversed Integers: ");
			DisplayExecutionTime(() => { SortingAlgorithms.SelectionSort(RandomInts); });

			Console.Write("Random Doubles:    ");
			DisplayExecutionTime(() => { SortingAlgorithms.SelectionSort(RandomDoubles); });

			Console.Write("Sorted Doubles:    ");
			DisplayExecutionTime(() => { SortingAlgorithms.SelectionSort(RandomDoubles); });

			Console.Write("Reversed Doubles:  ");
			DisplayExecutionTime(() => { SortingAlgorithms.SelectionSort(RandomInts); });

			Console.Write("Random Strings:    ");
			DisplayExecutionTime(() => { SortingAlgorithms.SelectionSort(RandomStrings); });

			Console.Write("Sorted Strings:    ");
			DisplayExecutionTime(() => { SortingAlgorithms.SelectionSort(RandomStrings); });

			Console.Write("Reversed Strings:  ");
			DisplayExecutionTime(() => { SortingAlgorithms.SelectionSort(RandomStrings); });

			Console.WriteLine("------------------------------- QUICK SORT -------------------------------");

			Console.Write("Random Integers:   ");
			DisplayExecutionTime(() => { SortingAlgorithms.QuickSort(RandomInts, LEFT_INDEX, RIGHT_INDEX); });

			Console.Write("Sorted Integers:   ");
			DisplayExecutionTime(() => { SortingAlgorithms.QuickSort(RandomInts, LEFT_INDEX, RIGHT_INDEX); });

			Console.Write("Reversed Integers: ");
			DisplayExecutionTime(() => { SortingAlgorithms.QuickSort(RandomInts, LEFT_INDEX, RIGHT_INDEX); });

			Console.Write("Random Doubles:    ");
			DisplayExecutionTime(() => { SortingAlgorithms.QuickSort(RandomInts, LEFT_INDEX, RIGHT_INDEX); });

			Console.Write("Sorted Doubles:    ");
			DisplayExecutionTime(() => { SortingAlgorithms.QuickSort(RandomInts, LEFT_INDEX, RIGHT_INDEX); });

			Console.Write("Reversed Doubles:  ");
			DisplayExecutionTime(() => { SortingAlgorithms.QuickSort(RandomInts, LEFT_INDEX, RIGHT_INDEX); });

			Console.Write("Random Strings:    ");
			DisplayExecutionTime(() => { SortingAlgorithms.QuickSort(RandomInts, LEFT_INDEX, RIGHT_INDEX); });

			Console.Write("Sorted Strings:    ");
			DisplayExecutionTime(() => { SortingAlgorithms.QuickSort(RandomInts, LEFT_INDEX, RIGHT_INDEX); });

			Console.Write("Reversed Strings:  ");
			DisplayExecutionTime(() => { SortingAlgorithms.QuickSort(RandomInts, LEFT_INDEX, RIGHT_INDEX); });
		}

		private static void DisplayExecutionTime(Action action)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			action();
			stopwatch.Stop();
			Console.WriteLine(stopwatch.Elapsed);
		}
	}
}