// C# Basics Exam 11 April 2014 Morning
// Problem 3. The Explorer

using System;
using System.Text;

class TheExplorer
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		const char dash = '-';
		const char star = '*';

		StringBuilder sb = new StringBuilder();

		sb.Append(new string(dash, (n - 1) / 2));
		sb.Append(new string(star, 1));
		sb.AppendLine(new string(dash, (n - 1) / 2));

		for (int i = (n - 1) / 2 - 1; i >= 0; i--)
		{
			sb.Append(new string(dash, i));
			sb.Append(new string(star, 1));
			sb.Append(new string(dash, n - 2 * (i + 1)));
			sb.Append(new string(star, 1));
			sb.AppendLine(new string(dash, i));
		}

		for (int i = 1; i <= n / 2 - 1; i++)
		{
			sb.Append(new string(dash, i));
			sb.Append(new string(star, 1));
			sb.Append(new string(dash, n - 2 * (i + 1)));
			sb.Append(new string(star, 1));
			sb.AppendLine(new string(dash, i));
		}

		sb.Append(new string(dash, (n - 1) / 2));
		sb.Append(new string(star, 1));
		sb.AppendLine(new string(dash, (n - 1) / 2));

		Console.WriteLine(sb);
	}
}
