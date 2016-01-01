using System;
using System.Linq;
using System.Text;
// C# Part 2 - 2012/2013 @ 11 Feb 2013
// 5. Three in One
class ThreeInOne
{
	private static readonly StringBuilder result = new StringBuilder();
	static void Main()
	{
		FirstTaskSolver();
		SecondTaskSolver();
		ThirdTaskSolver();

		Console.WriteLine(result);
	}

	private static void ThirdTaskSolver()
	{
		string[] input = Console.ReadLine().Split(' ');
		int G1 = int.Parse(input[0]);
		int S1 = int.Parse(input[1]);
		int B1 = int.Parse(input[2]);
		int G2 = int.Parse(input[3]);
		int S2 = int.Parse(input[4]);
		int B2 = int.Parse(input[5]);

		int exchangeOperations = FindMinOperations(G1, S1, B1, G2, S2, B2);

		result.AppendLine(string.Empty + exchangeOperations);
	}

	private static int FindMinOperations(int G1, int S1, int B1, int G2, int S2, int B2)
	{
		int exchangeOperations = 0;
		while (G2 > G1)
		{
			--G2;
			S2 += 11;
			exchangeOperations++;
		}

		while (S2 > S1)
		{
			if (G1 > G2)
			{
				--G1;
				S1 += 9;
				exchangeOperations++;
			}
			else
			{
				--S2;
				B2 += 11;
				exchangeOperations++;
			}
		}

		while (B2 > B1)
		{
			if (S1 > S2)
			{
				--S1;
				B1 += 9;
				exchangeOperations++;
			}
			else if (G1 > G2)
			{
				--G1;
				S1 += 9;
				exchangeOperations++;
			}
			else
			{
				return -1;
			}
		}

		return exchangeOperations;
	}

	private static void SecondTaskSolver()
	{
		string[] bites = Console.ReadLine().Split(',');
		int[] cakes = bites.Select(int.Parse).ToArray();
		Array.Sort(cakes);
		Array.Reverse(cakes);
		int F = int.Parse(Console.ReadLine());

		int count = 0;
		for (int cake = 0; cake < cakes.Length; cake += F + 1)
		{
			count += cakes[cake];
		}

		result.AppendLine(string.Empty + count);
	}

	private static void FirstTaskSolver()
	{
		string[] input = Console.ReadLine().Split(',');
		int[] points = input.Select(int.Parse).ToArray();

		int bestPoints = -1;
		int bestPlayer = -1;

		for (int i = 0; i < points.Length; i++)
		{
			if (points[i] > 21)
			{
				continue;
			}

			if (points[i] > bestPoints)
			{
				bestPoints = points[i];
				bestPlayer = i;
			}
			else if (points[i] == bestPoints)
			{
				bestPlayer = -1;
			}
		}

		result.AppendLine(string.Empty + bestPlayer);
	}
}