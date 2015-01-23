// SoftUni C# Basics Exam 10 April 2014 Evening
// Problem 3. Eclipse

using System;
using System.Text;

class Eclipse
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());
		const char star = '*';
		const char blank = ' ';
		const char slash = '/';
		const char dash = '-';

		StringBuilder sb = new StringBuilder();

		sb.Append(new string(blank, 1));
		sb.Append(new string(star, 2 * N - 2));
		sb.Append(new string(blank, 1));
		sb.Append(new string(blank, N - 1));
		sb.Append(new string(blank, 1));
		sb.Append(new string(star, 2 * N - 2));
		sb.AppendLine(new string(blank, 1));

		for (int i = 0; i < N - 2; i++)
		{
			sb.Append(new string(star, 1));
			sb.Append(new string(slash, 2 * N - 2));
			sb.Append(new string(star, 1));
			sb.Append(i == N / 2 - 1 ? new string(dash, N - 1) : new string(blank, N - 1));
			sb.Append(new string(star, 1));
			sb.Append(new string(slash, 2 * N - 2));
			sb.AppendLine(new string(star, 1));
		}

		sb.Append(new string(blank, 1));
		sb.Append(new string(star, 2 * N - 2));
		sb.Append(new string(blank, 1));
		sb.Append(new string(blank, N - 1));
		sb.Append(new string(blank, 1));
		sb.Append(new string(star, 2 * N - 2));
		sb.AppendLine(new string(blank, 1));

		Console.WriteLine(sb);
	}
}
