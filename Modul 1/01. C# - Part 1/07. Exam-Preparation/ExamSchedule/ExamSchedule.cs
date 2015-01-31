// C# Basics Exam 12 April 2014 Evening
// Problem 1. Exam Schedule

using System;
using System.Globalization;

class ExamSchedule
{
	static void Main()
	{
		int hours = int.Parse(Console.ReadLine());
		int minutes = int.Parse(Console.ReadLine());
		string partOfDay = Console.ReadLine();
		string startTime = string.Format("{0}:{1}{2}", hours, minutes, partOfDay);
		int durationHours = int.Parse(Console.ReadLine());
		int durationMinutes = int.Parse(Console.ReadLine());
		durationMinutes += durationHours * 60;
		string endTime = ConvertFrom12To24Clock(startTime, durationMinutes).ToString("hh:mm:tt",CultureInfo.CurrentCulture);
		Console.WriteLine(endTime);
	}

	private static DateTime ConvertFrom12To24Clock(string startTime, int durationMinutes)
	{
		DateTime startDateTime = DateTime.Parse(startTime);
		DateTime endDateTime = startDateTime.AddMinutes(durationMinutes);
		return endDateTime;
	}
}
