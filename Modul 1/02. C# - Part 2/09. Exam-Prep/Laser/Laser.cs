using System;
using System.Linq;

class Laser
{
	/// <summary>
	/// C# Part 2 - 2012/2013 @ 5 Feb 2013
	/// 3. Laser
	/// </summary>
	static void Main()
	{
		int[] dims = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
		int[] pos = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
		int[] vect = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

		bool[, ,] used = new bool[dims[0] + 1, dims[1] + 1, dims[2] + 1];
		while (true)
		{
			used[pos[0], pos[1], pos[2]] = true;
			int[] newPos = new int[3];
			for (int i = 0; i < 3; i++)
			{
				newPos[i] = pos[i] + vect[i];
			}

			if (used[newPos[0], newPos[1], newPos[2]] || CountCubesOnEdges(newPos, dims) >= 2)
			{
				Console.WriteLine("{0} {1} {2}", pos[0], pos[1], pos[2]);
				return;
			}

			if (CountCubesOnEdges(newPos, dims) == 1)
			{
				ReverseComponents(newPos, vect, dims);
			}

			for (int i = 0; i < 3; i++)
			{
				pos[i] = newPos[i];
			}
		}
	}

	private static void ReverseComponents(int[] newPos, int[] dirs, int[] dims)
	{
		for (int i = 0; i < 3; i++)
		{
			if (newPos[i] == 1 && dirs[i] == -1)
			{
				dirs[i] *= -1;
			}
			else if (newPos[i] == dims[i] && dirs[i] == 1)
			{
				dirs[i] *= -1;
			}
		}
	}

	private static int CountCubesOnEdges(int[] newPos, int[] dims)
	{
		int count = 0;
		for (int i = 0; i < 3; i++)
		{
			if (newPos[i] == 1 || newPos[i] == dims[i])
			{
				count++;
			}	
		}

		return count;
	}
}