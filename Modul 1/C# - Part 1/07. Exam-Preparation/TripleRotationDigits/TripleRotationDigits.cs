// Telerik Academy Exam 1 @ 29 Dec 2012
// Problem 1. Triple Rotation Digits


using System;

class ExamPrep
{
	static void Main()
	{
		string input = Console.ReadLine();
		int k = int.Parse(input);
		int lenght = input.Length;

		for (int i = 0; i < 3; i++)
		{
			k = k / 10 + (k % 10) * ((int)Math.Pow(10, lenght - 1));
			lenght = k.ToString().Length;
		}
		Console.WriteLine(k);
	}
}