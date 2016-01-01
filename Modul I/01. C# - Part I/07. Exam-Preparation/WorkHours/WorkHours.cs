// C# Basics Exam 11 April 2014 Morning
// Problem 1. Work Hours

using System;

class WorkHours
{
	static void Main()
	{
		int requiredHours = int.Parse(Console.ReadLine());
		int availableDays = int.Parse(Console.ReadLine());
		decimal productivity = (decimal)int.Parse(Console.ReadLine()) / 100;

		const decimal tenPercent = 0.1M;
		decimal efiicientDays = availableDays - availableDays * tenPercent;
		int efficientHours = (int)(efiicientDays * 12 * productivity);
		int diff = efficientHours - requiredHours;
		if (diff < 0)
		{
			Console.WriteLine("No");
			Console.WriteLine(diff);
		}
		else
		{
			Console.WriteLine("Yes");
			Console.WriteLine(diff);
		}
	}
}
