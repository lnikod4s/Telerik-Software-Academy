// Telerik Academy Exam 1 @ 28 Dec 2012
// Problem 3. Excel Columns

using System;

class ExamPrep
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());

		char[] letters = new char[n];
		long sum = 0;
		for (int i = 0; i < n; i++)
		{
			letters[i] = char.Parse(Console.ReadLine());
			sum *= 26;
			sum += (long)(letters[i] - 'A' + 1);
		}
		Console.WriteLine(sum);
	}
}