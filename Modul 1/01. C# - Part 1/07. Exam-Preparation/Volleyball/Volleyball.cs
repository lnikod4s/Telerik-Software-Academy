// SoftUni C# Basics Exam 10 April 2014 Evening
// Problem 1. Volleyball

using System;

class Volleyball
{
	static void Main()
	{
		string year = Console.ReadLine();
		decimal holidays = (decimal)(2 * int.Parse(Console.ReadLine())) / 3;
		int hometownWeekends = int.Parse(Console.ReadLine());
		decimal normalWeekends = (decimal)(3 * (48 - hometownWeekends)) / 4;
		
		decimal totalPlays = holidays + hometownWeekends + normalWeekends;
		if (year == "leap") totalPlays += (15 * totalPlays) / 100;

		Console.WriteLine((int)totalPlays);
	}
}
