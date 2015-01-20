// Telerik Academy Exam 1 @ 6 December 2013 Evening
// Problem 4. Kaspichania Boats

using System;

class Boats
{
	static void Main()
	{
		string userInput = Console.ReadLine();
		int size = int.Parse(userInput);
		int width = size * 2 + 1;
		int height = 6 + ((size - 3) / 2) * 3;

		int middleDotsCounts = 0;
		string firstLineDots = new String('.', (width - 1) / 2);
		Console.WriteLine("{0}*{0}", firstLineDots);

		for (int row = size; row > 0; row--)
		{
			int begginingDotsCount = row - 1;
			string begginingDots = new String('.', begginingDotsCount);

			if (middleDotsCounts <= size - 2)
			{
				string middleDots = new String('.', middleDotsCounts);
				Console.WriteLine("{0}*{1}*{1}*{0}", begginingDots, middleDots);
				middleDotsCounts++;
			}
		}

		var onlyStarsLine = new String('*', width);
		Console.WriteLine(onlyStarsLine);

		for (int row = 0; row < height / 3 - 1; row++)
		{
			int outerDotsCount = row + 1;
			string outerDots = new String('.', outerDotsCount);
			int innerDotsCount = (width - outerDotsCount * 2 - 3) / 2;
			string innerDots = new String('.', innerDotsCount);
			Console.WriteLine("{0}*{1}*{1}*{0}", outerDots, innerDots);
		}

		string startAndEndDots = new String('.', (width - size) / 2);
		string bottomSide = new String('*', size);
		Console.WriteLine("{0}{1}{0}", startAndEndDots, bottomSide);
	}
}