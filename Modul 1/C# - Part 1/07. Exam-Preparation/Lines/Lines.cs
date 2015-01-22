// Telerik Academy Exam 1 @ 7 Dec 2011 Morning
// Problem 5. Lines

using System;

class Lines
{
	static readonly char[,] matrix = new char[8, 8];
	static int bestLength = 0;
	static int bestLengthCount = 0;
	static void Main()
	{
		for (int row = 0; row < 8; row++)
		{
			int currNum = int.Parse(Console.ReadLine());
			char[] bits = Convert.ToString(currNum, 2).PadLeft(8, '0').ToCharArray();
			for (int col = 7; col >= 0; col--)
			{
				matrix[row, col] = bits[col];
			}
		}

		for (int row = 0; row < 8; row++)
		{
			int currLength = 0;
			for (int col = 0; col < 8; col++)
			{
				if (matrix[row, col] == '1')
				{
					currLength++;
					if (currLength > bestLength)
					{
						bestLength = currLength;
						bestLengthCount = 1;
					}
					else if (currLength == bestLength)
					{
						bestLengthCount++;
					}
				}
				else
				{
					currLength = 0;
				}
			}
		}

		for (int col = 0; col < 8; col++)
		{
			int currLength = 0;
			for (int row = 0; row < 8; row++)
			{
				if (matrix[row, col] == '1')
				{
					currLength++;
					if (currLength > bestLength)
					{
						bestLength = currLength;
						bestLengthCount = 1;
					}
					else if (currLength == bestLength && bestLength != 0)
					{
						bestLengthCount++;
					}
				}
				else
				{
					currLength = 0;
				}
			}
		}

		if (bestLength == 1)
		{
			bestLengthCount /= 2;
		}
		Console.WriteLine(bestLength);
		Console.WriteLine(bestLengthCount);
	}
}
