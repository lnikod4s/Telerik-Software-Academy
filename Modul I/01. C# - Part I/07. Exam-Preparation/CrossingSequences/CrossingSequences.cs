// C# Basics Exam 11 April 2014 Evening
// Problem 4. Crossing Sequences

using System;
using System.Collections.Generic;

class CrossingSequences
{
	static void Main()
	{
		const int MAX = 1000000;

		int trib1 = int.Parse(Console.ReadLine());
		int trib2 = int.Parse(Console.ReadLine());
		int trib3 = int.Parse(Console.ReadLine());
		int startNum = int.Parse(Console.ReadLine());
		int step = int.Parse(Console.ReadLine());

		var tribNums = TribNums(trib1, trib2, trib3);

		bool oddCorner = true;
		int side = 0;
		int count = 0;
		int currNum = startNum;
		if (tribNums.Contains(currNum))
		{
			Console.WriteLine(currNum);
			count++;
			return;
		}

		while (currNum <= MAX)
		{
			if (oddCorner) side += 1;
			currNum += side * step;
			if (tribNums.Contains(currNum))
			{
				Console.WriteLine(currNum);
				count++;
				return;
			}
			oddCorner = !oddCorner;
		}
		if (count == 0) Console.WriteLine("No");
	}

	private static List<int> TribNums(int trib1, int trib2, int trib3)
	{
		List<int> tribNums = new List<int>() {trib1, trib2, trib3};
		while (true)
		{
			int currTrib = trib1 + trib2 + trib3;
			if (currTrib > 1000000) break;
			tribNums.Add(currTrib);
			trib1 = trib2;
			trib2 = trib3;
			trib3 = currTrib;
		}
		return tribNums;
	}
}
