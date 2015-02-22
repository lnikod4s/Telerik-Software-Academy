using System;
using System.Collections.Generic;
// C# Part 2 - 2013/2014 @ 22 Jan 2014 - Evening
// 1. TRES4 Numbers
class TRES4Numbers
{
	static readonly string[] alpha = { "LON+", "VK-", "*ACAD", "^MIM", "ERIK|", "SEY&", "EMY>>", "/TEL", "<<DON" };
	static void Main()
	{
		

		ulong inputNumber = ulong.Parse(Console.ReadLine());

		// Convert the input decimal number to nonery number (9 base system)
		List<string> tresNumFourNumber = new List<string>();
		do
		{
			tresNumFourNumber.Add(alpha[inputNumber % 9]);
			inputNumber /= 9;
		}
		while (inputNumber != 0);

		tresNumFourNumber.Reverse(); // Reversing the number to get the real value
		string result = string.Join(string.Empty, tresNumFourNumber);

		Console.WriteLine(result);
	}
}