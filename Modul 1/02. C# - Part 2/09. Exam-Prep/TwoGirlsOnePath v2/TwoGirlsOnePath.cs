using System;
using System.Linq;
using System.Numerics;

/// <summary>
/// C# Part 2 - 2013/2014 @ 24 Jan 2014 - Evening
/// 2. Two Girls, One Path
/// </summary>
class TwoGirlsOnePath
{
	static void Main()
	{
		BigInteger[] numbers = Console.ReadLine()
							   .Split()
							   .Select(BigInteger.Parse)
							   .ToArray();

		int mollyIndex = 0, dollyIndex = numbers.Length - 1;
		BigInteger mollyTotalFlowers = 0, dollyTotalFlowers = 0;
		string winner = string.Empty;
		while (true)
		{
			if (numbers[mollyIndex] == 0 ||
				numbers[dollyIndex] == 0)
			{
				if (numbers[mollyIndex] == 0 && numbers[dollyIndex] == 0)
				{
					winner = "Draw";
				}
				else if (numbers[mollyIndex] == 0)
				{
					winner = "Dolly";
				}
				else if (numbers[dollyIndex] == 0)
				{
					winner = "Molly";
				}

				mollyTotalFlowers += numbers[mollyIndex];
				dollyTotalFlowers += numbers[dollyIndex];
				break;
			}

			BigInteger currMollyFlowers = numbers[mollyIndex];
			BigInteger currDollyFlowers = numbers[dollyIndex];

			if (mollyIndex == dollyIndex)
			{
				numbers[mollyIndex] = currMollyFlowers % 2;
				mollyTotalFlowers += currMollyFlowers / 2;
				dollyTotalFlowers += currDollyFlowers / 2;
			}
			else
			{
				numbers[mollyIndex] = 0;
				numbers[dollyIndex] = 0;

				mollyTotalFlowers += currMollyFlowers;
				dollyTotalFlowers += currDollyFlowers;
			}

			mollyIndex = (int)((mollyIndex + currMollyFlowers) % numbers.Length);
			dollyIndex = (int)((dollyIndex - currDollyFlowers) % numbers.Length);
			if (dollyIndex < 0)
			{
				dollyIndex += numbers.Length;
			}
		}

		Console.WriteLine(winner);
		Console.WriteLine("{0} {1}", mollyTotalFlowers, dollyTotalFlowers);
	}
}