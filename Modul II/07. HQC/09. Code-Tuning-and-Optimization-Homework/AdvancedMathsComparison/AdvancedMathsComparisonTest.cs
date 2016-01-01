using System;
using System.Diagnostics;

namespace AdvancedMathsComparison
{
	internal class AdvancedMathsComparisonTest
	{
		internal static void Main()
		{
			Console.WriteLine("------------------------------- FLOAT -------------------------------");
			float x1 = 0;
			ExecuteMathTests(x1);

			Console.WriteLine("------------------------------- DOUBLE -------------------------------");
			double x2 = 0;
			ExecuteMathTests(x2);

			Console.WriteLine("------------------------------- DECIMAL -------------------------------");
			decimal x3 = 0;
			ExecuteMathTests(x3);
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
			a = a + 1;

			Console.Write("Square Root: ");
			DisplayExecutionTime(() =>
								 {
									 for (var i = 0; i < LOOP_COUNT; i++)
									 {
										 Math.Sqrt((double)a);
									 }
								 });

			Console.Write("Natural algorithm: ");
			DisplayExecutionTime(() =>
								 {
									 for (var i = 0; i < LOOP_COUNT; i++)
									 {
										 Math.Log((double)a);
									 }
								 });

			Console.Write("Sinus: ");
			DisplayExecutionTime(() =>
								 {
									 for (var i = 0; i < LOOP_COUNT; i++)
									 {
										 Math.Sin((double)a);
									 }
								 });
		}
	}
}