// C# Basics Exam 11 April 2014 Evening
// Problem 3. New House

using System;
using System.Text;

class NewHouse
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());
		const char dash = '-';
		const char star = '*';
		const char pipe = '|';

		StringBuilder sb = new StringBuilder();

		for (int i = 1; i <= N; i += 2)
		{
			sb.Append(new string(dash, (N - i) / 2));
			sb.Append(new string(star, i));
			sb.AppendLine(new string(dash, (N - i) / 2));
		}

		for (int i = 0; i < N; i++)
		{
			sb.Append(new string(pipe, 1));
			sb.Append(new string(star, N - 2));
			sb.AppendLine(new string(pipe, 1));
		}
		
		Console.WriteLine(sb);
	}
}
