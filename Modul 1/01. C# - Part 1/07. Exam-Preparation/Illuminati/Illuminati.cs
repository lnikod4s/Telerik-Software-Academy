// C# Basics Exam 11 April 2014 Evening
// Problem 2. Illuminati

using System;

class Illuminati
{
	static int count = 0;
	static int sum = 0;
	static void Main()
	{
		string input = Console.ReadLine().ToUpper();

		foreach (char c in input)
		{
			if (c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
			{
				sum += c;
				count++;
			}
		}
		Console.WriteLine(count);
		Console.WriteLine(sum);
	}
}
