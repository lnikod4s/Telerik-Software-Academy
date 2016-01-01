using System;
using System.Globalization;
/*Problem 16. Date difference
------------------------------------------------------------------------------------------------------------------------
Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.
Example:

Enter the first date: 27.02.2006
Enter the second date: 3.03.2006
Distance: 4 days
*/
class DateDifference
{
	static void Main()
	{
		Console.Write("Enter the first date in the format [dd.MM.yyyy]: ");
		string startDate = Console.ReadLine();
		Console.Write("Enter the second date in the format [dd.MM.yyyy]: ");
		string endDate = Console.ReadLine();

		DateTime start = DateTime.ParseExact(startDate, "d.M.yyyy", CultureInfo.InvariantCulture);
		DateTime end = DateTime.ParseExact(endDate, "d.M.yyyy", CultureInfo.InvariantCulture);

		Console.WriteLine("Distance between {0} and {1} -> {2} days\n", startDate, endDate, Math.Abs((end - start).TotalDays));
	}
}