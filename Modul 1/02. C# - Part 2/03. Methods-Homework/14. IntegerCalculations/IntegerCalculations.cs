using System;
using System.Linq;

/*Problem 14. Integer calculations
------------------------------------------------------------------------------------------------------
Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers.
Use variable number of arguments.
*/
class IntegerCalculations
{
	static void Main()
	{
		Console.WriteLine("The Minimum of set integers: {0}", GetMin(1, 2, 3, 4, 5, 6, 7, 8, 9));
		Console.WriteLine("The Maximum of set integers: {0}", GetMax(1, 2, 3, 4, 5, 6, 7, 8, 9));
		Console.WriteLine("The Average Sum of set integers: {0}", GetAverageSum(1, 2, 3, 4, 5, 6, 7, 8, 9));
		Console.WriteLine("The Sum of set integers: {0}", GetSum(1, 2, 3, 4, 5, 6, 7, 8, 9));
		Console.WriteLine("The Product of set integers: {0}\n", GetProduct(1, 2, 3, 4, 5, 6, 7, 8, 9));
	}

	static int GetMin(params int[] numbers)
	{
		int min = numbers[0];

		for (int i = 1; i < numbers.Length; i++)
		{
			if (numbers[i] < min) min = numbers[i];
		}
		return min;
	}

	static int GetMax(params int[] numbers)
	{
		int max = numbers[0];

		for (int i = 1; i < numbers.Length; i++)
		{
			if (numbers[i] > max) max = numbers[i];
		}
		return max;
	}

	static int GetSum(params int[] numbers)
	{
		return numbers.Sum();
	}

	static decimal GetAverageSum(params int[] numbers)
	{
		return (decimal)GetSum(numbers) / numbers.Length;
	}

	static int GetProduct(params int[] numbers)
	{
		return numbers.Aggregate(1, (current, t) => current * t);
	}
}