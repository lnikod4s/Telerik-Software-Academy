using System;
using System.Linq;

class JoroTheRabbit
{
	/// <summary>
	/// C# Part 2 - 2012/2013 @ 5 Feb 2013
	/// 2. Joro the Rabbit
	/// </summary>
	static int bestLength = 0;
	static void Main()
	{
		int[] numbers = Console.ReadLine().Split(',').Select(x => Convert.ToInt32(x)).ToArray();

		FindBestLength(numbers);

		Console.WriteLine(bestLength);
	}

	static void FindBestLength(int[] numbers)
	{
		for (int startIndex = 0; startIndex < numbers.Length; startIndex++)
		{
			for (int step = 1; step < numbers.Length; step++)
			{
				int index = startIndex, next = 0, currentLength = 1;

				while (next != startIndex)
				{
					if (index + step >= numbers.Length) next = (index + step) - numbers.Length;
					else next = index + step;

					if (numbers[index] >= numbers[next]) break;
					index = next;
					currentLength++;
				}

				if (currentLength > bestLength) bestLength = currentLength;
			}
		}
	}
}