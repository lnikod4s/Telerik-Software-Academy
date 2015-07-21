using System;
using System.Diagnostics;

namespace SimpleMathsComparison
{
	internal class SimpleMathsComparisonTest
	{
		internal static void Main()
		{
			Console.WriteLine("------------------------------- INT -------------------------------");
			var x1 = 0;
			ExecuteMathTests(x1);

			Console.WriteLine("------------------------------- LONG -------------------------------");
			long x2 = 0;
			ExecuteMathTests(x2);

			Console.WriteLine("------------------------------- FLOAT -------------------------------");
			float x3 = 0;
			ExecuteMathTests(x3);

			Console.WriteLine("------------------------------- DOUBLE -------------------------------");
			double x4 = 0;
			ExecuteMathTests(x4);

			Console.WriteLine("------------------------------- DECIMAL -------------------------------");
			decimal x5 = 0;
			ExecuteMathTests(x5);
		}

		/// <exception cref="Exception">A delegate callback throws an exception.</exception>
		private static void DisplayExecutionTime(Action action)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			action();
			stopwatch.Stop();
			Console.WriteLine(stopwatch.Elapsed);
		}

		private static void ExecuteMathTests(dynamic a)
		{
			const int LOOP_COUNT = 5000000;

			Console.Write("Add: ");
			DisplayExecutionTime(() =>
			                     {
				                     a = a + 0;
				                     for (var i = 0; i < LOOP_COUNT; i++)
				                     {
					                     a = a + 1;
				                     }
			                     });

			Console.Write("Subtract: ");
			DisplayExecutionTime(() =>
			                     {
				                     a = a + 5000000;
				                     for (var i = 0; i < LOOP_COUNT; i++)
				                     {
					                     a = a - 1;
				                     }
			                     });

			Console.Write("Increment: ");
			DisplayExecutionTime(() =>
			                     {
				                     a = a + 0;
				                     for (var i = 0; i < LOOP_COUNT; i++)
				                     {
					                     a++;
				                     }
			                     });

			Console.Write("Multiply: ");
			DisplayExecutionTime(() =>
			                     {
				                     a = a + 1;
				                     for (var i = 0; i < LOOP_COUNT; i++)
				                     {
					                     a = a * 1;
				                     }
			                     });

			Console.Write("Divide: ");
			DisplayExecutionTime(() =>
			                     {
				                     a = a + 1;
				                     for (var i = 0; i < LOOP_COUNT; i++)
				                     {
					                     a = a / 1;
				                     }
			                     });
		}
	}
}