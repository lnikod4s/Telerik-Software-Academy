using System;
// Telerik Academy Exam 2 @ 6 Feb 2012
// Problem 3 Tubes
class Tubes
{
	static void Main()
	{
		// This solution uses Binary Search, because the input data is enorm
		int N = int.Parse(Console.ReadLine());
		int M = int.Parse(Console.ReadLine());
		int left = 0, right = 0, maxTube = 0;

		int[] tubes = new int[N];
		for (int i = 0; i < N; i++)
		{
			tubes[i] = int.Parse(Console.ReadLine());
			if (right < tubes[i])
			{
				right = tubes[i];
			}
		}

		int mid = (left + right) / 2;
		while (left <= right)
		{
			var eventualTubes = 0;
			for (int i = 0; i < N; i++)
			{
				eventualTubes += tubes[i] / mid;
			}

			if (eventualTubes >= M)
			{
				left = mid + 1;
				maxTube = mid;
			}
			else
			{
				right = mid - 1;
			}

			mid = (left + right) / 2;
		}

		Console.WriteLine(maxTube);
	}
}