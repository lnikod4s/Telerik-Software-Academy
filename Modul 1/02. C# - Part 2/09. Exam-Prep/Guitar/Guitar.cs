using System;
using System.Data.OleDb;
using System.Linq;

// C# Fundamentals 2011/2012 Part 2 - Test Exam
// Problem 5 Guitar
class Guitar
{
	static void Main()
	{
		// Split the entry songs by ',' and ' ' and copy them in string array
		string[] inputSongs = Console.ReadLine().Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);

		// Copy and parse directly the string values from inputSongs to songs with 
		int[] songs = inputSongs.Select(int.Parse).ToArray();
		
		// Read the initial(B) and highest possible(M) volume settings of Bobi's guitar 
		int B = int.Parse(Console.ReadLine());
		int M = int.Parse(Console.ReadLine());

		int[,] matrix = new int[songs.Length + 1, M + 1];
		matrix[0, B] = 1;

		for (int row = 1; row < matrix.GetLength(0); row++)
		{
			var interval = songs[row - 1];
			for (int col = 0; col < matrix.GetLength(1); col++)
			{
				// Check if the previous row contains 1
				if (matrix[row - 1, col] == 1)
				{
					// Check if the volume setting is in the range [0...M]
					if (col - interval >= 0)
					{
						matrix[row, col - interval] = 1;
					}

					if (col + interval <= M)
					{
						matrix[row, col + interval] = 1;
					}
				}
			}
		}

		// Printing the nearest to M col
		for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
		{
			if (matrix[songs.Length, col] == 1)
			{
				Console.WriteLine(col);
				return;
			}
		}

		// If there is no way to go through the list without exceeding M or going below 0, print -1
		Console.WriteLine(-1);
	}
}