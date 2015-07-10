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
				Console.Error.WriteLine("Sides should be positive.");
				return -1;
			}

			var s = (a + b + c) / 2;
			var area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
			return area;
		}

		public static string NumberToDigit(int number)
		{
			switch (number)
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
			}

			return "Invalid number!";
		}

		public static int FindMax(params int[] elements)
		{
			if (elements == null ||
			    elements.Length == 0)
			{
				return -1;
			}

			for (var i = 1; i < elements.Length; i++)
			{
				if (elements[i] > elements[0])
				{
					elements[0] = elements[i];
				}
			}

			return elements[0];
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