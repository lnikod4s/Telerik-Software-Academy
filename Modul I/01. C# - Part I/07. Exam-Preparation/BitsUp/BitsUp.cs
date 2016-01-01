// C# Basics Exam 10 April 2014 Evening
// Problem 5. Bits Up

using System;
using System.Linq;
using System.Text;

class ExamPrep
{
	static void Main()
	{
		// Reading input data
		int N = int.Parse(Console.ReadLine());
		int step = int.Parse(Console.ReadLine());
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < N; i++)
		{
			int currByte = int.Parse(Console.ReadLine());
			sb.Append(Convert.ToString(currByte, 2).PadLeft(8, '0'));
		}

		// Set the bits at 'step' position to 1
		char[] bits = sb.ToString().ToCharArray();
		for (int i = 0; i < bits.Length; i++)
		{
			int index = 1 + i * step;
			if (index >= bits.Length) break;
			if (bits[index] == '0') bits[index] = '1';
		}

		// Copy the char array in the result string
		string result = bits.Aggregate(string.Empty, (current, bit) => current + bit);

		// Print the bytes
		for (int i = 0; i < result.Length; i += 8)
		{
			int currNum = Convert.ToInt16(result.Substring(i, 8), 2);
			Console.WriteLine(currNum);
		}
	}
}