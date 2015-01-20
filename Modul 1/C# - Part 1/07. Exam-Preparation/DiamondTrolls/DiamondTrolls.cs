// Telerik Academy Exam 1 @ 6 December 2013 Morning
// Problem 4. Diamond Trolls

using System;
using System.Text;

class ExamPrep
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());
		char dot = '.';
		char star = '*';

		StringBuilder output = new StringBuilder();

		output.Append(new string(dot, (N + 1) / 2));
		output.Append(new string(star, N));
		output.AppendLine(new string(dot, (N + 1) / 2));

		for (int i = 0; i < N / 2; i++)
		{
			output.Append(new string(dot, (N - 1) / 2 - i));
			output.Append(new string(star, 1));
			output.Append(new string(dot, N / 2 + i));
			output.Append(new string(star, 1));
			output.Append(new string(dot, N / 2 + i));
			output.Append(new string(star, 1));
			output.AppendLine(new string(dot, (N - 1) / 2 - i));
		}

		output.AppendLine(new string(star, 2 * N + 1));

		for (int i = 1; i <= N - 1; i++)
		{
			output.Append(new string(dot, i));
			output.Append(new string(star, 1));
			output.Append(new string(dot, N - 1 - i));
			output.Append(new string(star, 1));
			output.Append(new string(dot, N - 1 - i));
			output.Append(new string(star, 1));
			output.AppendLine(new string(dot, i));
		}

		output.Append(new string(dot, N));
		output.Append(new string(star, 1));
		output.AppendLine(new string(dot, N));

		Console.WriteLine(output);
	}
}