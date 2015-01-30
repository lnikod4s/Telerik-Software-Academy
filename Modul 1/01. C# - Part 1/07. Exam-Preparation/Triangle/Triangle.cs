// C# Basics Exam 12 April 2014 Morning
// Problem 1. Triangle

using System;
using System.Threading;

class Triangle
{
	static void Main()
	{
		Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
		int aX = int.Parse(Console.ReadLine());
		int aY = int.Parse(Console.ReadLine());
		int bX = int.Parse(Console.ReadLine());
		int bY = int.Parse(Console.ReadLine());
		int cX = int.Parse(Console.ReadLine());
		int cY = int.Parse(Console.ReadLine());

		double ab = Math.Sqrt(
			(bX - aX) * (bX - aX) +
			(bY - aY) * (bY - aY));

		double bc = Math.Sqrt(
			(bX - cX) * (bX - cX) +
			(bY - cY) * (bY - cY));

		double ac = Math.Sqrt(
			(cX - aX) * (cX - aX) +
			(cY - aY) * (cY - aY));

		bool areFormingTriangle =
			(ab + bc > ac && ab + ac > bc && ac + bc > ab);

		if (areFormingTriangle == false)
		{
			Console.WriteLine("No");
			Console.WriteLine("{0:F2}", ab);
		}
		else
		{
			Console.WriteLine("Yes");
			double p = (ab + bc + ac) / 2;
			double area = Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac));
			Console.WriteLine("{0:F2}", area);
		}
	}
}
