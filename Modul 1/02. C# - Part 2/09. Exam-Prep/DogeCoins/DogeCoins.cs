using System;

class DogeCoins
{
	static void Main()
	{
		// Read input data
		var line = Console.ReadLine().Split(' ');
		int n = int.Parse(line[0]);
		int m = int.Parse(line[1]);

		var field = new int[n, m];

		int k = int.Parse(Console.ReadLine());
		for (int i = 0; i < k; i++)
		{
			line = Console.ReadLine().Split(' ');
			int x = int.Parse(line[0]);
			int y = int.Parse(line[1]);

			field[x, y]++;
		}

		// Solve
		var answer = new int[n, m];
		for (int x = 0; x < n; x++)
		{
			for (int y = 0; y < m; y++)
			{
				int up = 0, left = 0;
				if (x > 0)
				{
					up = answer[x - 1, y];
				}

				if (y > 0)
				{
					left = answer[x, y - 1];
				}

				answer[x, y] = Math.Max(up, left) + field[x, y];
			}
		}

		// Print answer
		Console.WriteLine(answer[n - 1, m - 1]);
	}
}