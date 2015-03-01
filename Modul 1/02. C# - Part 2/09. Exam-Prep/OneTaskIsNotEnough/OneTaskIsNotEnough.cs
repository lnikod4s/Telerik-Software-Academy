using System;

class OneTaskIsNotEnough
{
	static void Main()
	{
		Console.WriteLine(Task1(int.Parse(Console.ReadLine())));
		Console.WriteLine(Task2(Console.ReadLine()));
		Console.WriteLine(Task2(Console.ReadLine()));
	}

	private static int Task1(int lamps)
	{
		int[] turnedOn = new int[lamps];

		for (int i = 0; i < lamps; i++)
		{
			turnedOn[i] = i + 1;
		}

		int jump = 2;
		while (lamps > 1)
		{
			for (int i = 0; i < lamps; i += jump)
			{
				turnedOn[i] = 0;
			}

			int index = 0;
			for (int i = 0; i < lamps; i++)
			{
				if (turnedOn[i] != 0)
				{
					turnedOn[index++] = turnedOn[i];
				}
			}

			lamps = index;
			jump++;
		}

		return turnedOn[0];
	}

	private static string Task2(string path)
	{
		int[,] dirs =
		{
			{0, 1},
			{1, 0},
			{0, -1},
			{-1, 0}
		};

		int dir = 0, row = 0, col = 0;
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < path.Length; j++)
			{
				switch (path[j])
				{
					case 'S':
						row += dirs[dir, 0];
						col += dirs[dir, 1];
						break;
					case 'L':
						dir = (dir + 3) % 4;
						break;
					case 'R':
						dir = (dir + 1) % 4;
						break;
				}
			}
		}

		if (row == 0 && col == 0)
		{
			return "bounded";
		}
		else
		{
			return "unbounded";
		}
	}
}