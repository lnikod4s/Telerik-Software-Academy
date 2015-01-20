// C# Basics Exam 19 December 2014
// Problem 2. Spy Hard

using System;
using System.Text;

class TextBombardment
{
	private static void Main()
	{
		int key = int.Parse(Console.ReadLine());
		string text = Console.ReadLine();
		string textLength = text.Length.ToString();

		string output = "";
		output += key + textLength;

		int result = 0;
		string resultToStr = "";
		string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
		foreach (char c in text)
		{
			if (Char.IsLower(c))
			{
				result += (int)(c % 97 + 1);
			}
			else if (Char.IsUpper(c))
			{
				result += (int)(c % 65 + 1);
			}
			else
			{
				result += (int)c;
			}
			resultToStr = ConvertToAnyBase(result, key, chars);
		}
		output += resultToStr;

		Console.WriteLine(output);
	}

	private static string ConvertToAnyBase(int result, int key, string chars)
	{
		if (key <= 0) key = chars.Length;
		var sb = new StringBuilder();
		do
		{
			int m = (int)(result % key);
			sb.Insert(0, chars[m]);
			result = (result - m) / key;
		} while (result > 0);
		return sb.ToString();
	}
}