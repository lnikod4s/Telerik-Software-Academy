// C# Basics Exam 12 April 2014 Evening
// 04. Five Special Letters

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class FiveSpecialLetters
{
	static void Main()
	{
		int start = int.Parse(Console.ReadLine());
		int end = int.Parse(Console.ReadLine());

		StringBuilder sb = new StringBuilder();
		var list = new List<string>();
		for (int i = 'a'; i <= 'e'; i++)
		{
			for (int j = 'a'; j <= 'e'; j++)
			{
				for (int k = 'a'; k <= 'e'; k++)
				{
					for (int l = 'a'; l <= 'e'; l++)
					{
						for (int m = 'a'; m <= 'e'; m++)
						{
							sb.Append((char)i);
							sb.Append((char)j);
							sb.Append((char)k);
							sb.Append((char)l);
							sb.Append((char)m);
							list.Add(sb.ToString());
							sb.Clear();
						}
					}
				}
			}
		}

		int count = 0;
		foreach (string s in list)
		{
			int currWeight = CalcLettersWeight(s);
			if (currWeight >= start && currWeight <= end)
			{
				Console.Write(s + " ");
				count++;
			}
		}
		if (count == 0)
		{
			Console.WriteLine("No");
		}
	}

	private static int CalcLettersWeight(string s)
	{
		string currSet = new string(s.Distinct().ToArray());
		int weight = 0;
		for (int i = 0; i < currSet.Length; i++)
		{
			int currWeigth = 0;
			char currChar = currSet[i];
			switch (currChar)
			{
				case 'a': currWeigth += 5; break;
				case 'b': currWeigth -= 12; break;
				case 'c': currWeigth += 47; break;
				case 'd': currWeigth += 7; break;
				case 'e': currWeigth -= 32; break;
			}
			weight += (i + 1) * currWeigth;
		}
		return weight;
	}
}