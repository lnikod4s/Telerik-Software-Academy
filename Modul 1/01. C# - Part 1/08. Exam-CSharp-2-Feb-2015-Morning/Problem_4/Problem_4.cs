using System;
using System.Text;

class Problem_4
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());
		const char BLANK = ' ';
		const char X = 'X';
		const char SLASH = '/';
		const char COLON = ':';

		StringBuilder sb = new StringBuilder();

		sb.Append(new string(BLANK, N - 1));
		sb.AppendLine(new string(COLON, N));


		int index = N - 2;
		for (int i = 0; index >= 1; i++)
		{
			sb.Append(new string(BLANK, index));
			sb.Append(new string(COLON, 1));
			sb.Append(new string(SLASH, N - 2));
			sb.Append(new string(COLON, 1));
			sb.Append(new string(X, i));
			sb.AppendLine(new string(COLON, 1));
			index--;
		}

		sb.Append(new string(COLON, N));
		sb.Append(new string(X, N - 2));
		sb.AppendLine(new string(COLON, 1));

		for (int i = N - 3; i >= 0; i--)
		{
			sb.Append(new string(COLON, 1));
			sb.Append(new string(BLANK, N - 2));
			sb.Append(new string(COLON, 1));
			sb.Append(new string(X, i));
			sb.AppendLine(new string(COLON, 1));
		}

		sb.AppendLine(new string(COLON, N));

		Console.WriteLine(sb);
	}
}
