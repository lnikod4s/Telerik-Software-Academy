using System;
using System.Linq;

/// <summary>
/// Problem 6. Divisible by 7 and 3
/// Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.
/// </summary>
class DivisibleBySevenAndThree
{
	static void Main()
	{
		int[] numbers = Enumerable.Range(0, 700).ToArray();

		// Sorting by extension method
		var sortedNumbers = numbers.Where(x => x % 7 == 0 && x % 3 == 0);
		Console.WriteLine(string.Join("\t", sortedNumbers));

		// Sorting by LINQ query
		sortedNumbers =
			from number in numbers
			where number % 7 == 0 && number % 3 == 0
			select number;
		Console.WriteLine(string.Join("\t", sortedNumbers));
	}
}