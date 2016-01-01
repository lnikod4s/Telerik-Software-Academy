// SoftUni C# Basics Exam 10 April 2014 Evening
// Problem 4. Hayvan Numbers

using System;
using System.Collections.Generic;
using System.Linq;

class HayvanNumbers
{
	static void Main()
	{
		int sum = int.Parse(Console.ReadLine());
		int diff = int.Parse(Console.ReadLine());

		int count = 0;
		for (int num1 = 555; num1 <= 999; num1++)
		{
			int num2 = num1 + diff;
			int num3 = num2 + diff;
			if (CalcSumOfDigits(num1) + CalcSumOfDigits(num2) + CalcSumOfDigits(num3) == sum
				&& IsValidNumber(num1) && IsValidNumber(num2) && IsValidNumber(num3))
			{
				Console.WriteLine("{0}{1}{2}", num1, num2, num3);
				count++;
			}
		}

		if (count == 0)
		{
			Console.WriteLine("No");
		}
	}

	private static bool IsValidNumber(int num)
	{
		string numToString = num.ToString();
		return numToString.All(c => c >= '5' && c <= '9');
	}

	private static int CalcSumOfDigits(int num)
	{
		int sumOfDigits = 0;
		while (num != 0)
		{
			sumOfDigits += num % 10;
			num /= 10;
		}
		return sumOfDigits;
	}
}
