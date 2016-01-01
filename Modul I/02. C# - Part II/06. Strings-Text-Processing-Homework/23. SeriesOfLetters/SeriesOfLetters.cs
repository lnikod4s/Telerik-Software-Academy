﻿using System;
/*Problem 23. Series of letters
------------------------------------------------------------------------------------------------------------------------
Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one.
Example:

input						output
aaaaabbbbbcdddeeeedssaa		abcdedsa
*/
class SeriesOfLetters
{
	static void Main()
	{
		string sequence = Console.ReadLine();

		Console.WriteLine("Result -> {0}\n", ReplaceSequenceWithOneElement(sequence));
	}

	static string ReplaceSequenceWithOneElement(string str)
	{
		string result = str[0].ToString();
		for (int i = 1; i < str.Length; i++)
		{
			if (str[i] != result[result.Length - 1])
			{
				result += str[i];
			}
		}

		return result;
	}
}