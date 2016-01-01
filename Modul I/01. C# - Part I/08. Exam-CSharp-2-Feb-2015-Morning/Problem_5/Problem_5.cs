using System;
using System.Text;

class Problem_5
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());
		const char ZERO = '0';
		const char ONE = '1';

		string[] nums = new string[N];
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < N; i++)
		{
			int currNum = int.Parse(Console.ReadLine());
			nums[i] = Convert.ToString(currNum, 2).PadLeft(30, '0');
			if (i != N - 1) sb.Append(nums[i]);
			else sb.AppendLine(nums[i]);
		}

		char[] bits = sb.ToString().ToCharArray();
		int zerosCount = GetMaxSubsequence(bits, ZERO);
		int onesCount = GetMaxSubsequence(bits, ONE);
		Console.WriteLine(zerosCount);
		Console.WriteLine(onesCount);
	}

	private static int GetMaxSubsequence(char[] bits, char target)
	{
		int maxLength = 0;
		int tempLength = 0;

		foreach (char bit in bits)
		{
			tempLength = (bit == target) ? 1 + tempLength : 0;
			if (tempLength > maxLength)
			{
				maxLength = tempLength;
			}
		}
		return maxLength;
	}
}
