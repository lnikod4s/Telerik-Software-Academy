using System;
using System.Linq;

namespace _17.LongestString
{
	/// <summary>
	/// Problem 17. Longest string
	/// Write a program to return the string with maximum length from an array of strings.
	/// Use LINQ.
	/// </summary>
	class LongestString
	{
		public static int maxLength = 0;
		private static readonly Random RND = new Random();

		static void Main()
		{
			string[] stringArr = GenerateRandomStrings();

			var solutionWithLINQ =
				from s in stringArr
				where GetLongestString(s)
				select s;

			Console.WriteLine("Longest string: {0}", solutionWithLINQ.Last());
			Console.WriteLine("Length: {0}", maxLength);
		}

		private static bool GetLongestString(string s)
		{
			if (s.Length > maxLength)
			{
				maxLength = s.Length;
				return true;
			}

			return false;
		}

		private static string[] GenerateRandomStrings()
		{

			string[] resultArr = new string[RND.Next(10, 31)];
			for (int i = 0; i < resultArr.Length; i++)
			{
				resultArr[i] = RND.NextString();
			}

			return resultArr;
		}
	}
}
