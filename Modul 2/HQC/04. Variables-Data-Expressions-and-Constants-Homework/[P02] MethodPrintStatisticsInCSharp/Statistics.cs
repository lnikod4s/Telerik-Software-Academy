using System;

namespace MethodPrintStatisticsInCSharp
{
	public class Statistics
	{
		public void PrintStatistics(double[] array, int count)
		{
			var max = FindMaxElement(array, count);
			Console.WriteLine(max);

			var min = FindMinElement(array, count);
			Console.WriteLine(min);

			var sum = FindSumOfAllElements(array, count);
			Console.WriteLine(sum / count);
		}

		private static double FindSumOfAllElements(double[] array, int count)
		{
			double sum = 0;
			for (var i = 0; i < count; i++)
			{
				sum += array[i];
			}

			return sum;
		}

		private static double FindMinElement(double[] array, int count)
		{
			var min = double.MaxValue;
			for (var i = 0; i < count; i++)
			{
				if (array[i] < min)
				{
					min = array[i];
				}
			}

			return min;
		}

		private static double FindMaxElement(double[] array, int count)
		{
			var max = double.MinValue;
			for (var i = 0; i < count; i++)
			{
				if (array[i] > max)
				{
					max = array[i];
				}
			}

			return max;
		}
	}
}