using System;
/*Problem 1. Leap year
---------------------------------------------------------------------------------------
Write a program that reads a year from the console and checks whether it is a leap one.
Use System.DateTime.
*/
class LeapYear
{
	static void Main()
	{
		Console.Write("Enter a year in the format yyyy: ");
		int year = int.Parse(Console.ReadLine());

		DateTime newDate = new DateTime(year, 1, 1);
		bool isLeapYear = DateTime.IsLeapYear(newDate.Year);
		Console.WriteLine(isLeapYear);
	}
}