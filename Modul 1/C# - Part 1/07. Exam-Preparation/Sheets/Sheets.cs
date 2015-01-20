// Telerik Academy Exam 1 @ 27 Dec 2012
// Problem 3. Sheets

using System;
using System.Collections.Generic;

class ExamPrep
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());

		SortedList<int, int> sheets = new SortedList<int, int>();
		for (int i = 10; i >= 0; i--)
		{
			sheets.Add(i, (int)Math.Pow(2, 10 - i));
		}

		List<string> output = new List<string>();
		foreach (KeyValuePair<int, int> pair in sheets)
		{
			if (pair.Value <= N)
			{
				var lastNum = pair.Value;
				N -= lastNum;
			}
			else
			{
				output.Add("A" + pair.Key);
			}
		}

		for (int i = output.Count - 1; i >= 0; i--)
		{
			Console.WriteLine(output[i]);
		}
	}
}