using System;
using System.Linq;
using System.Numerics;
// C# Part 2 - 2013/2014 @ 24 Jan 2014 - Evening
// 2. Two Girls, One Path
class TwoGirlsOnePath
{
	static long[] path;
	static long mollyPosition;
	static long dollyPosition;
	static BigInteger mollyFlowers;
	static BigInteger dollyFlowers;
	static bool mollyEnded;
	static bool dollyEnded;
	static string winner;
	static void Main()
	{
		Initialize();
		StartGame();
		CalculateWinner();
		PrintResult();
	}

	static void Initialize()
	{
		path = ReadPath();

		mollyPosition = 0;
		dollyPosition = path.Length - 1;

		mollyFlowers = path[mollyPosition];
		dollyFlowers = path[dollyPosition];

		mollyEnded = false;
		dollyEnded = false;

		winner = "Draw";
	}

	static long[] ReadPath()
	{
		string[] pathParts = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		long[] pathNumbers = pathParts.Select(long.Parse).ToArray();

		return pathNumbers;
	}

	static void StartGame()
	{
		if (CheckPathForFlowers())
		{
			return;
		}

		long mollyOffset = path[mollyPosition];
		long dollyOffset = path[dollyPosition];

		path[mollyPosition] = 0;
		path[dollyPosition] = 0;

		while (true)
		{
			mollyPosition = mollyPosition + mollyOffset;
			if (mollyPosition >= path.Length)
			{
				mollyPosition %= path.Length;
			}

			dollyPosition = dollyPosition - dollyOffset;
			if (dollyPosition < 0)
			{
				dollyPosition = path.Length + (dollyPosition % path.Length);
				if (dollyPosition == path.Length)
				{
					dollyPosition = 0;
				}
			}

			if (mollyPosition != dollyPosition)
			{
				mollyFlowers += path[mollyPosition];
				dollyFlowers += path[dollyPosition];
			}
			else
			{
				mollyFlowers += path[mollyPosition] / 2;
				dollyFlowers += path[dollyPosition] / 2;
			}

			if (CheckPathForFlowers())
			{
				break;
			}

			mollyOffset = path[mollyPosition];
			dollyOffset = path[dollyPosition];

			if (mollyPosition != dollyPosition)
			{
				path[mollyPosition] = 0;
				path[dollyPosition] = 0;
			}
			else
			{
				path[mollyPosition] = 1;
			}
		}
	}

	static bool CheckPathForFlowers()
	{
		if (path[mollyPosition] == 0 || path[dollyPosition] == 0)
		{
			if (path[mollyPosition] == 0)
			{
				mollyEnded = true;
			}

			if (path[dollyPosition] == 0)
			{
				dollyEnded = true;
			}

			return true;
		}

		return false;
	}

	static void CalculateWinner()
	{
		if (mollyEnded && !dollyEnded)
		{
			winner = "Dolly";
		}
		else if (!mollyEnded && dollyEnded)
		{
			winner = "Molly";
		}
	}

	static void PrintResult()
	{
		Console.WriteLine(winner);
		Console.WriteLine(mollyFlowers + " " + dollyFlowers);
	}
}