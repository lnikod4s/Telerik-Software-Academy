using System;
using System.Linq;
/*Problem 5. Workdays
------------------------------------------------------------------------------------------------------------------------
Write a method that calculates the number of workdays between today and given date, passed as parameter.
Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.
*/
class Workdays
{
	static readonly DateTime[] holidays =
	{
		new DateTime(2015, 1, 1), new DateTime(2015, 3, 3), new DateTime(2015, 4, 10),
		new DateTime(2015, 4, 13), new DateTime(2015, 5, 1), new DateTime(2015, 5, 6),
		new DateTime(2015, 5, 24), new DateTime(2015, 9, 6), new DateTime(2015, 9, 22),
		new DateTime(2015, 12, 24), new DateTime(2015, 12, 25)
	};

	static readonly DateTime[] workingWeekends =
	{
		new DateTime(2015, 1, 2), new DateTime(2015, 3, 2), new DateTime(2015, 9, 21),
		new DateTime(2015, 12, 31)
	};
	
	static void Main()
	{
		DateTime dateNow = DateTime.Now;
		
		Console.Write("Please enter a future date from today till 31.12.2015 in the format dd-MM-yyyy: ");
		string input = Console.ReadLine();
		int[] splittedInput = input.Split('-').Select(int.Parse).ToArray();
		DateTime dateFuture = new DateTime(splittedInput[2], splittedInput[1], splittedInput[0]);

		Console.WriteLine("Checking work days from {0:dd/MM/yyyy} to {1:dd/MM/yyyy}...\n", dateNow, dateFuture);
		Console.WriteLine("Total work days: {0}\n", GetNumberOfWorkDays(dateNow, dateFuture));
	}

	static int GetNumberOfWorkDays(DateTime dateNow, DateTime dateFuture)
	{
		int numberOfWorkDays = 0;

		if (dateNow > dateFuture)
		{
			DateTime swap = dateNow;
			dateNow = dateFuture;
			dateFuture = swap;
		}

		while (dateNow <= dateFuture)
		{
			if (!holidays.Contains(dateNow) 
			&& !workingWeekends.Contains(dateNow) 
			&& dateNow.DayOfWeek != DayOfWeek.Saturday 
			&& dateNow.DayOfWeek != DayOfWeek.Sunday)
			{
				numberOfWorkDays++;
			}
			dateNow = dateNow.AddDays(1);
		}

		return numberOfWorkDays;
	}
}