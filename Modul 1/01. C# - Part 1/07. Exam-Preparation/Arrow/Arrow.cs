// C# Basics Exam 12 April 2014 Evening
// Problem 03. Arrow

using System;
using System.Text;

class Arrow
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());
		const char sharp = '#';
		const char dot = '.';

		StringBuilder sb = new StringBuilder();

		sb.Append(new string(dot, N / 2));
		sb.Append(new string(sharp, N));
		sb.AppendLine(new string(dot, N / 2));

		for (int i = 0; i < N - 2; i++)
		{
			sb.Append(new string(dot, N / 2));
			sb.Append(new string(sharp, 1));
			sb.Append(new string(dot, N - 2));
			sb.Append(new string(sharp, 1));
			sb.AppendLine(new string(dot, N / 2));
		}

		sb.Append(new string(sharp, N / 2 + 1));
		sb.Append(new string(dot, N - 2));
		sb.AppendLine(new string(sharp, N / 2 + 1));

		for (int i = 1; i <= N - 2; i++)
		{
			sb.Append(new string(dot, i));
			sb.Append(new string(sharp, 1));
			sb.Append(new string(dot, 2 * N - 3 - 2 * i));
			sb.Append(new string(sharp, 1));
			sb.AppendLine(new string(dot, i));
		}

		sb.Append(new string(dot, N - 1));
		sb.Append(new string(sharp, 1));
		sb.AppendLine(new string(dot, N - 1));

		Console.WriteLine(sb);
	}
}
