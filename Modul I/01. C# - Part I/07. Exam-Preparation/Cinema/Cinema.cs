// C# Basics Exam 11 April 2014 Evening
// Problem 1. Cinema

using System;
using System.Threading;

class Cinema
{
	static void Main()
	{
		Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
		string type = Console.ReadLine();
		int rows = int.Parse(Console.ReadLine());
		int cols = int.Parse(Console.ReadLine());
		
		decimal cost = 0;
		switch (type)
		{
			case "Premiere": cost += 12; break;
			case "Normal": cost += (decimal)7.50; break;
			case "Discount": cost += 5; break;
		}
		
		decimal incomes = rows * cols * cost;
		Console.WriteLine("{0:F2} leva", incomes);
	}
}
