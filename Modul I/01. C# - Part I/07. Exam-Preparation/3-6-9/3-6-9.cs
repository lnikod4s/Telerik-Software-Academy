// Telerik Academy Exam 1 @ 6 December 2013 Morning
// Problem 1. 3-6-9
using System;

class ExamPrep
{
	static void Main()
	{
		long A = long.Parse(Console.ReadLine());
		long B = long.Parse(Console.ReadLine());
		long C = long.Parse(Console.ReadLine());
		long R = 0;

		switch (B)
		{
			case 3: R = A + C; break;
			case 6: R = A * C; break;
			case 9: R = A % C; break;
		}
		var result = R % 3 == 0 ? R / 3 : R % 3;
		Console.WriteLine(result);
		Console.WriteLine(R);
	}
}