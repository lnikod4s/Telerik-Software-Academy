using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions.Helpers
{
	internal class HelperMethods
	{
		internal static T[] Subsequence<T>(T[] arr, int startIndex, int count)
		{
			var result = new List<T>();
			for (int i = startIndex; i < startIndex + count; i++)
			{
				result.Add(arr[i]);
			}

			return result.ToArray();
		}

		internal static string ExtractEnding(string str, int count)
		{
			if (count > str.Length)
			{
				return "Invalid count!";
			}

			var result = new StringBuilder();
			for (int i = str.Length - count; i < str.Length; i++)
			{
				result.Append(str[i]);
			}

			return result.ToString();
		}

		internal static void CheckPrime(int number)
		{
			for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
			{
				if (number % divisor == 0)
				{
					throw new Exception("The number is not prime!");
				}
			}
		}
	}
}
