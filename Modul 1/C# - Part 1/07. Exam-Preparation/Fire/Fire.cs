// Telerik Academy Exam 1 @ 23 June 2013
// Problem 4. Fire


using System;
using System.Text;

class ExamPrep
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());

		const char dot = '.';
		const char dash = '-';
		const char hash = '#';
		const char slash = '/';
		const char bslash = '\\';

		StringBuilder result = new StringBuilder();

		for (int i = (N - 2) / 2; i >= 0; i--)
		{
			result.Append(new string(dot, i));
			result.Append(new string(hash, 1));
			result.Append(new string(dot, N - 2 - 2 * i));
			result.Append(new string(hash, 1));
			result.AppendLine(new string(dot, i));
		}

		for (int i = 0; i < N / 4; i++)
		{
			result.Append(new string(dot, i));
			result.Append(new string(hash, 1));
			result.Append(new string(dot, N - 2 - 2 * i));
			result.Append(new string(hash, 1));
			result.AppendLine(new string(dot, i));
		}

		result.AppendLine(new string(dash, N));

		for (int i = 0; i < N / 2; i++)
		{
			result.Append(new string(dot, i));
			result.Append(new string(bslash, N / 2 - i));
			result.Append(new string(slash, N / 2 - i));
			result.AppendLine(new string(dot, i));
		}

		Console.WriteLine(result);
	}
}