using System;
/*Problem 10.* Beer Time
------------------------------------------------------------------------------------------------------------------------
A beer time is after 1:00 PM and before 3:00 AM.
Write a program that enters a time in format “hh:mm tt” (an hour in range [01...12], a minute in range [00…59] and AM / PM designator) and prints beer time or non-beer time according to the definition above or invalid time if the time cannot be parsed. Note: You may need to learn how to parse dates and times.
Examples:

time		result
1:00 PM		beer time
4:30 PM		beer time
10:57 PM	beer time
8:30 AM		non-beer time
02:59 AM	beer time
03:00 AM	non-beer time
03:26 AM	non-beer time
*/

internal class BeerTime
{
	private static void Main()
	{
		Console.WriteLine("Please enter a time in format \"hh:mm tt\": ");
		string input = Console.ReadLine();
		TimeSpan start = TimeSpan.Parse("13:00"); // 1:00 PM
		TimeSpan end = TimeSpan.Parse("03:00");   // 3:00 AM
		TimeSpan currentTimeSpan = DateTime.Parse(input).TimeOfDay;

		if (start <= end)
		{
			// start and stop times are in the same day
			if (currentTimeSpan >= start && currentTimeSpan <= end)
			{
				// current time is between start and stop
				Console.WriteLine("beer time");
			}
			else
			{
				Console.WriteLine("non-beer time");
			}
		}
		else
		{
			// start and stop times are in different days
			if (currentTimeSpan >= start || currentTimeSpan <= end)
			{
				// current time is between start and stop
				Console.WriteLine("beer time");
			}
			else
			{
				Console.WriteLine("non-beer time");
			}
		}
	}
}