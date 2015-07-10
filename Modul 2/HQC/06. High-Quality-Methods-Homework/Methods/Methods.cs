using System;

namespace Methods
{
	public class Methods
	{
		public static double CalcTriangleArea(double a, double b, double c)
		{
			if (a <= 0 ||
			    b <= 0 ||
			    c <= 0)
			{
				throw new ArgumentException("Triangle sides should be positive integers.");
			}

			if (a + b <= c ||
			    a + c <= b ||
			    b + c <= a)
			{
				throw new ArgumentException("The given sides cannot construct a valid triangle.");
			}

			var s = (a + b + c) / 2;
			var area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
			return area;
		}

		public static string NumberToDigit(int digit)
		{
			switch (digit)
			{
				case 0:
					return "zero";
				case 1:
					return "one";
				case 2:
					return "two";
				case 3:
					return "three";
				case 4:
					return "four";
				case 5:
					return "five";
				case 6:
					return "six";
				case 7:
					return "seven";
				case 8:
					return "eight";
				case 9:
					return "nine";
				default:
					return "Invalid digit!";
			}
		}

		public static int FindMax(params int[] elements)
		{
			if (elements == null ||
			    elements.Length == 0)
			{
				throw new ArgumentNullException("Arguments array should be non-empty.");
			}

			var max = elements[0];
			for (var i = 1; i < elements.Length; i++)
			{
				if (max < elements[i])
				{
					max = elements[i];
				}
			}

			return max;
		}

		public static void PrintAsNumber(double number, string format)
		{
			switch (format)
			{
				case "f":
					Console.WriteLine(number.ToString("F2"));
					break;
				case "%":
					Console.WriteLine(number.ToString("P"));
					break;
				case "r":
					Console.WriteLine(number.ToString("R8"));
					break;
			}
		}

		public static double CalcDistance(double x1, double y1, double x2, double y2,
		                                  out bool isHorizontal, out bool isVertical)
		{
			// Define the tolerance for variation in the values of x- and y-axis values
			var differenceXAxis = Math.Abs(x1 * .00001);
			var differenceYAxis = Math.Abs(y1 * .00001);

			isVertical = (Math.Abs(y1 - y2) <= differenceYAxis);
			isHorizontal = (Math.Abs(x1 - x2) <= differenceXAxis);

			var distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
			return distance;
		}
	}
}