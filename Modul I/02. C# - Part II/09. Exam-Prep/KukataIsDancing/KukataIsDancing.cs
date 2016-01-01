using System;
// C# Part 2 - 2012/2013 @ 11 Feb 2013
// 3. Kukata is Dancing
class KukataIsDancing
{
	private static readonly int[] directionX = { 1, 0, -1, 0 };
	private static readonly int[] directionY = { 0, -1, 0, 1 };

	private static int FinalPosition(string movement)
	{
		int[,] cube = new int[3, 3];
		cube[0, 0] = cube[0, 2] = cube[2, 0] = cube[2, 2] = 1; // RED
		cube[1, 1] = 2; // GREEN
		// 0 is BLUE

		int row = 1;
		int col = 1;
		int directionIndex = 0;

		for (int i = 0; i < movement.Length; i++)
		{
			char currentMove = movement[i];
			if (currentMove == 'L')
			{
				directionIndex++;
				directionIndex = (directionIndex == 4) ? 0 : directionIndex;
			}
			else if (currentMove == 'R')
			{
				directionIndex--;
				directionIndex = (directionIndex == -1) ? 3 : directionIndex;
			}
			else
			{
				row += directionX[directionIndex];
				col += directionY[directionIndex];
				if (row == -1)
				{
					row = 2;  // Checking for edge
				}
				if (row == 3)
				{
					row = 0;  // Checking for edge
				}
				if (col == -1)
				{
					col = 2; // Checking for edge
				}
				if (col == 3)
				{
					col = 0; // Checking for edge
				}
			}
		}

		return cube[row, col];
	}

	private static void PrintResult(int result)
	{
		if (result == 0)
		{
			Console.WriteLine("BLUE");
		}
		else if (result == 1)
		{
			Console.WriteLine("RED");
		}
		else
		{
			Console.WriteLine("GREEN");
		}
	}

	static void Main()
	{
		int dances = int.Parse(Console.ReadLine());
		for (int i = 0; i < dances; i++)
		{
			string movement = Console.ReadLine();
			int finalPosition = FinalPosition(movement);
			PrintResult(finalPosition);
		}
	}
}