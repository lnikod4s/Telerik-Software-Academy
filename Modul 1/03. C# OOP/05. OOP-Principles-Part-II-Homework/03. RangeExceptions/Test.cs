/*Problem 3. Range Exceptions
Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range. It should hold error message and a range definition [start … end].
Write a sample application that demonstrates the InvalidRangeException<int> and InvalidRangeException<DateTime> by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].
*/

using System;

namespace _03.RangeExceptions
{
	class Test
	{
		static void Main()
		{
			// Numbers in the range: [1 … 100]
			Console.WriteLine("Test 1: Numbers in the range [1 ... 100]");
			Console.Write("Enter some integer number: ");
			CheckRange(1, 100, int.Parse(Console.ReadLine()));

			// Dates in the range: [1.1.1980 … 31.12.2013]
			Console.WriteLine("\nTest 2: Dates in the range [1.1.1980 ... 31.12.2013]");
			Console.Write("Enter some date /YYYY.MM.DD/: ");
			CheckRange(new DateTime(1980, 1, 1), new DateTime(2013, 12, 31), DateTime.Parse(Console.ReadLine()));
		}

		private static void CheckRange<T>(T start, T end, T value) where T : IComparable
		{
			try
			{
				if (value.CompareTo(start) < 0 ||
				    value.CompareTo(end) > 0)
				{
					// The value is out of range
					throw new InvalidRangeException<T>(start, end);
				}
				else
				{
					// The value is in the range
					Console.WriteLine("The value is in the range.");
				}
			}
			catch (InvalidRangeException<T> e)
			{
				Console.WriteLine("\n*** Error! ***");
				Console.WriteLine("Member name: {0}", e.TargetSite);
				Console.WriteLine("Class defining member: {0}",
				                  e.TargetSite.DeclaringType);
				Console.WriteLine("Member type: {0}", e.TargetSite.MemberType);
				Console.WriteLine("Message: {0}", e.Message);
				Console.WriteLine("Source: {0}", e.Source);
			}
			catch (Exception e)
			{
				Console.WriteLine("\n*** Error! ***");
				Console.WriteLine("Member name: {0}", e.TargetSite);
				Console.WriteLine("Class defining member: {0}",
								  e.TargetSite.DeclaringType);
				Console.WriteLine("Member type: {0}", e.TargetSite.MemberType);
				Console.WriteLine("Message: {0}", e.Message);
				Console.WriteLine("Source: {0}", e.Source);
			}
		}
	}
}
