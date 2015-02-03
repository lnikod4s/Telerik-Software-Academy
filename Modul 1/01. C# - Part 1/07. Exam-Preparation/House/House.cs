// C# Basics Exam 12 April 2014 Morning
// Problem 3. House

using System;
using System.Text;

class House
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());
		const char dot = '.';
		const char star = '*';

		StringBuilder sb = new StringBuilder();

		sb.Append(new string(dot, (N - 1) / 2));
		sb.Append(new string(star, 1));
		sb.AppendLine(new string(dot, (N - 1) / 2));

		for (int i = 0; i < (N - 1) / 2 - 1; i++)
		{
			sb.Append(new string(dot, (N - 1) / 2 - 1 - i));
			sb.Append(new string(star, 1));
			sb.Append(new string(dot, 1 + 2 * i));
			sb.Append(new string(star, 1));
			sb.AppendLine(new string(dot, (N - 1) / 2 - 1 - i));
		}

		sb.AppendLine(new string(star, N));

		for (int i = 0; i < (N - 1) / 2 - 1; i++)
		{
			sb.Append(new string(dot, N / 4));
			sb.Append(new string(star, 1));
			sb.Append(new string(dot, N - (N / 4 + N / 4) - 2));
			sb.Append(new string(star, 1));
			sb.AppendLine(new string(dot, N / 4));
		}

		sb.Append(new string(dot, N / 4));
		sb.Append(new string(star, N - (N / 4 + N / 4)));
		sb.AppendLine(new string(dot, N / 4));
		
		Console.WriteLine(sb);
	}
}
