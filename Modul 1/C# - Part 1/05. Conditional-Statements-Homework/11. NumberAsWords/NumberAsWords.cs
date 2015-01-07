using System;
/*Problem 11.* Number as Words
-----------------------------------------------------------------------------------------------------------------
Write a program that converts a number in the range [0…999] to words, corresponding to the English pronunciation.
Examples:

numbers		number as words
0			Zero
9			Nine
10			Ten
12			Twelve
19			Nineteen
25			Twenty five
98			Ninety eight
98			Ninety eight
273			Two hundred and seventy three
400			Four hundred
501			Five hundred and one
617			Six hundred and seventeen
711			Seven hundred and eleven
999			Nine hundred and ninety nine
*/

class NumberAsWords
{
	static void Main()
	{
		int number = int.Parse(Console.ReadLine());
		string output = NumberToWords(number);
		Console.WriteLine(output);
	}

	private static string NumberToWords(int number)
	{
		if (number == 0) return "zero";

		string words = "";
		if ((number / 100) > 0)
		{
			words += NumberToWords(number / 100) + " hundred ";
			number %= 100;
		}

		if (number > 0)
		{
			if (words != "") words += "and ";

			string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
			string[] tens = { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

			if (number < 20) words += digits[number];
			else
			{
				words += tens[number / 10];
				if ((number % 10) > 0) words += "-" + digits[number % 10];
			}
		}
		return words;
	}
}
