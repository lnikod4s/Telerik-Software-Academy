// C# Basics Exam 14 April 2014 Morning
// Problem 03. Wine Glass

using System;
using System.Text;

class WineGlass
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());
		
		const char B_SLASH = '\\';
		const char SLASH = '/';
		const char STAR = '*';
		const char DOT = '.';
		const char V_LINE = '|';
		const char DASH = '-';

		StringBuilder sb = new StringBuilder();

		for (int i = 0; i < N / 2; i++)
		{
			sb.Append(new string(DOT, i));
			sb.Append(new string(B_SLASH, 1));
			sb.Append(new string(STAR, N - 2 * i - 2));
			sb.Append(new string(SLASH, 1));
			sb.AppendLine(new string(DOT, i));
		}

		if (N < 12)
		{
			for (int i = 0; i < N / 2 - 1; i++)
			{
				sb.Append(new string(DOT, (N - 2) / 2));
				sb.Append(new string(V_LINE, 2));
				sb.AppendLine(new string(DOT, (N - 2) / 2));
			}
		}
		else
		{
			for (int i = 0; i < N / 2 - 2; i++)
			{
				sb.Append(new string(DOT, (N - 2) / 2));
				sb.Append(new string(V_LINE, 2));
				sb.AppendLine(new string(DOT, (N - 2) / 2));
			}
		}

		sb.AppendLine(new string(DASH, N));
		if (N >= 12)
		{
			sb.AppendLine(new string(DASH, N));
		}

		Console.WriteLine(sb);
	}
}
