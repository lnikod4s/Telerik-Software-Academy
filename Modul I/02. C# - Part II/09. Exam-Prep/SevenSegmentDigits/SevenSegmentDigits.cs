using System;
using System.Collections.Generic;

/// <summary>
/// Telerik Academy Exam 2 @ 6 Feb 2012
/// Problem 2 7-segment display
/// </summary>
class SevenSegmentDigits
{
	static readonly byte[] digits = 
	{
			Convert.ToByte("1111110", 2), // 0 digit => 126
			Convert.ToByte("0110000", 2), // 1 digit => 48
			Convert.ToByte("1101101", 2), // 2 digit => 109
			Convert.ToByte("1111001", 2), // 3 digit => 121
			Convert.ToByte("0110011", 2), // 4 digit => 51
			Convert.ToByte("1011011", 2), // 5 digit => 91
			Convert.ToByte("1011111", 2), // 6 digit => 95
			Convert.ToByte("1110000", 2), // 7 digit => 112
			Convert.ToByte("1111111", 2), // 8 digit => 127
			Convert.ToByte("1111011", 2), // 9 digit => 123
	};
	static int N;
	static byte[] segments;
	static readonly List<string> answers = new List<string>();
	static char[] currentAnswer;

	static void Main()
	{
		ReadInput();
		SolveWithRecursion(0);
		PrintResult();
	}

	private static void PrintResult()
	{
		Console.WriteLine(answers.Count);
		foreach (string answer in answers)
		{
			Console.WriteLine(answer);
		}
	}

	private static void SolveWithRecursion(int position)
	{
		if (position == N)
		{
			answers.Add(currentAnswer.ToString());
			return;
		}

		for (int j = 0; j < digits.Length; j++)
		{
			if ((digits[j] & segments[position]) == segments[position])
			{
				currentAnswer[position] = (char)('0' + position);
				SolveWithRecursion(position + 1);
			}
		}
	}

	private static void ReadInput()
	{
		N = int.Parse(Console.ReadLine());
		segments = new byte[N];
		currentAnswer = new char[N];

		for (int i = 0; i < N; i++)
		{
			segments[i] = Convert.ToByte(Console.ReadLine(), 2);
		}
	}
}