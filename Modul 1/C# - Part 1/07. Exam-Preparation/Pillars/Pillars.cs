// Telerik Academy Exam 1 @ 6 Dec 2011 Morning
// Problem 5. Pillars

using System;
using System.Text;

class Pillars
{
	static readonly char[,] matrix = new char[8, 8];
	static readonly StringBuilder sb = new StringBuilder();
	static void Main()
	{
		for (int row = 0; row < 8; row++)
		{
			int num = int.Parse(Console.ReadLine());
			char[] bits = Convert.ToString(num, 2).PadLeft(8, '0').ToCharArray();
			for (int col = 7; col >= 0; col--)
			{
				matrix[row, col] = bits[col];
			}
		}
		
		for (int index = 0; index < 8; index++)
		{
			int leftCount = 0;
			int rightCount = 0;
			
			// Counting the ones on the left side of the pillar
			for (int col = index - 1; col >= 0; col--)
			{
				for (int row = 0; row < 8; row++)
				{
					if (matrix[row, col] == '1') leftCount++;
				}
			}

			// Counting the ones on the right side of the pillar
			for (int col = index + 1; col <= 7; col++)
			{
				for (int row = 0; row < 8; row++)
				{
					if (matrix[row, col] == '1') rightCount++;
				}
			}

			if (leftCount == rightCount)
			{
				sb.AppendLine((7 - index).ToString());
				sb.AppendLine(leftCount.ToString());
				break;
			}
		}
		if (sb.Length == 0)
		{
			sb.AppendLine("No");
		}
		Console.WriteLine(sb);
	}
}
