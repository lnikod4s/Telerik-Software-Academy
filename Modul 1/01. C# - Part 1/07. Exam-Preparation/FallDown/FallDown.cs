// C# Fundamentals 2011/2012 Part 1 - Test Exam
// Problem 5. Fall Down

using System;
using System.Text;

class ExamPrep
{
	static void Main()
	{
		char[,] matrix = new char[8, 8];
		for (int row = 0; row < 8; row++)
		{
			int num = int.Parse(Console.ReadLine());
			char[] bits = Convert.ToString(num, 2).PadLeft(8, '0').ToCharArray();
			for (int col = 0; col < 8; col++)
			{
				matrix[row, col] = bits[col];
			}
		}

		for (int col = 0; col < 8; col++)
		{
			int count = 0;
			for (int row = 0; row < 8; row++)
			{
				if (matrix[row, col] == '1')
				{
					count++;
					matrix[row, col] = '0';
				}
			}

			for (int i = 0; i < count; i++)
			{
				matrix[7 - i, col] = '1';
			}
		}

		for (int row = 0; row < 8; row++)
		{
			StringBuilder sb = new StringBuilder();
			for (int col = 0; col < 8; col++)
			{
				sb.Append(matrix[row, col]);
			}
			int num = Convert.ToInt32(sb.ToString(), 2);
			Console.WriteLine(num);
		}
	}
}