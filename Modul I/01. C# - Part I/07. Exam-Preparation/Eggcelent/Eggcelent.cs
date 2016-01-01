// Telerik Academy Exam 1 @ 5 December 2013 Evening
// Problem 4. Eggcelent

using System;
using System.IO;
using System.Text;

class ExamPrep
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		char dot = '.';
		char star = '*';
		char at = '@';

		StringBuilder output = new StringBuilder();

		output.Append(new string(dot, n + 1));
		output.Append(new string(star, n - 1));
		output.AppendLine(new string(dot, n + 1));

		if (n > 2)
		{
			int index = n - 1;
			while (index >= 1)
			{
				output.Append(new string(dot, index));
				output.Append(new string(star, 1));
				output.Append(new string(dot, 3 * n - 2 * index - 1));
				output.Append(new string(star, 1));
				output.AppendLine(new string(dot, index));
				index -= 2;
			}

			if (n > 4)
			{
				int endNum = 0;
				switch (n)
				{
					case 6: endNum += 1; break;
					case 8: endNum += 2; break;
					case 10: endNum += 3; break;
					case 12: endNum += 4; break;
					case 14: endNum += 5; break;
					case 16: endNum += 6; break;
					case 18: endNum += 7; break;
					case 20: endNum += 8; break;
					case 22: endNum += 9; break;
					case 24: endNum += 10; break;
					case 26: endNum += 11; break;
				}

				for (int i = 0; i < endNum; i++)
				{
					output.Append(new string(dot, 1));
					output.Append(new string(star, 1));
					output.Append(new string(dot, 3 * n - 3));
					output.Append(new string(star, 1));
					output.AppendLine(new string(dot, 1));
				}
			}
		}

		output.Append(new string(dot, 1));
		output.Append(new string(star, 1));
		for (int i = 0; i < 3 * n - 3; i++)
		{
			output.Append(i % 2 == 0 ? new string(at, 1) : new string(dot, 1));
		}
		output.Append(new string(star, 1));
		output.AppendLine(new string(dot, 1));

		output.Append(new string(dot, 1));
		output.Append(new string(star, 1));
		for (int i = 0; i < 3 * n - 3; i++)
		{
			output.Append(i % 2 == 0 ? new string(dot, 1) : new string(at, 1));
		}
		output.Append(new string(star, 1));
		output.AppendLine(new string(dot, 1));

		if (n > 2)
		{
			if (n > 4)
			{
				int endNum = 0;
				switch (n)
				{
					case 6: endNum += 1; break;
					case 8: endNum += 2; break;
					case 10: endNum += 3; break;
					case 12: endNum += 4; break;
					case 14: endNum += 5; break;
					case 16: endNum += 6; break;
					case 18: endNum += 7; break;
					case 20: endNum += 8; break;
					case 22: endNum += 9; break;
					case 24: endNum += 10; break;
					case 26: endNum += 11; break;
				}

				for (int i = 0; i < endNum; i++)
				{
					output.Append(new string(dot, 1));
					output.Append(new string(star, 1));
					output.Append(new string(dot, 3 * n - 3));
					output.Append(new string(star, 1));
					output.AppendLine(new string(dot, 1));
				}
			}

			int index = 1;
			while (index <= n - 1)
			{
				output.Append(new string(dot, index));
				output.Append(new string(star, 1));
				output.Append(new string(dot, 3 * n - 2 * index - 1));
				output.Append(new string(star, 1));
				output.AppendLine(new string(dot, index));
				index += 2;
			}
		}

		output.Append(new string(dot, n + 1));
		output.Append(new string(star, n - 1));
		output.AppendLine(new string(dot, n + 1));

		Console.WriteLine(output);
	}
}