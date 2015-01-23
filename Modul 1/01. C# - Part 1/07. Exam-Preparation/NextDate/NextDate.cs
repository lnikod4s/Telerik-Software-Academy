// Telerik Academy Exam 1 @ 27 Dec 2012
// Problem 1. Next Date

using System;

class ExamPrep
{
	static void Main()
	{
		int day = int.Parse(Console.ReadLine());
		int month = int.Parse(Console.ReadLine());
		int year = int.Parse(Console.ReadLine());

		DateTime currenDate = new DateTime(year, month, day);
		DateTime tommorow = currenDate.AddDays(1);

		Console.WriteLine(tommorow.ToString("d.M.yyyy"));
	}
}