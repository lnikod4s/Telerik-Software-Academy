using System;
using System.Collections.Generic;
using System.Linq;

/*Problem 8. Number as array
------------------------------------------------------------------------------------------------------------------------
Write a method that adds two positive integer numbers represented as arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]).
Each of the numbers that will be added could have up to 10 000 digits.
*/
class NumberAsArray
{
	static void Main()
	{
		Console.Write("Enter the first non-negative number: ");
		string first = Console.ReadLine();

		Console.Write("Enter the second non-negative number: ");
		string second = Console.ReadLine();

		if (IsCorrectNumber(first) && IsCorrectNumber(second))
		{
			List<int> result = AccumulateTwoNumbers(first, second);
			Console.Write("\nResult: ");
			PrintResult(result);
		}
		else
		{
			Console.WriteLine("\n-> You have entered invalid number(s)...\n");
		}
	}

	static bool IsCorrectNumber(string number)
	{
		return number.All(t => t >= '0' && t <= '9');
	}

	static List<int> AccumulateTwoNumbers(string first, string second)
	{
		// Here convert string to int[], because
		// according to the assignment we must represent numbers as array of digits
		var a = first.Select(ch => ch - '0').ToArray();
		var b = second.Select(ch => ch - '0').ToArray();

		Array.Reverse(a);
		Array.Reverse(b);

		List<int> result = new List<int>(Math.Max(a.Length, b.Length));

		int left = 0;

		for (int i = 0; i < result.Capacity; i++)
		{
			int num = (i < a.Length ? a[i] : 0) + (i < b.Length ? b[i] : 0) + left;
			left = num / 10;
			result.Add(num % 10);
		}

		if (left > 0) result.Add(left);
		return result;
	}

	static void PrintResult(List<int> result)
	{
		for (int i = result.Count - 1; i >= 0; i--)
		{
			Console.Write(result[i]);
		}
		Console.WriteLine("\n");
	}
}