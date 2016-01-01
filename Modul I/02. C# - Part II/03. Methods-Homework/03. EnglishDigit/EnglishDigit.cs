using System;
/*Problem 3. English digit
-------------------------------------------------------------------------------
Write a method that returns the last digit of given integer as an English word.
Examples:

input	output
512		two
1024	four
12309	nine
*/
class EnglishDigit
{
	static void Main()
	{
		Console.Write("Enter an integer number: ");
		int n = int.Parse(Console.ReadLine());

		int lastDigit = n % 10;
		string output = GetLastDigitAsWord(lastDigit);
		Console.WriteLine(output);
	}

	private static string GetLastDigitAsWord(int lastDigit)
	{
		string result = string.Empty;
		switch (lastDigit)
		{
			case 0: result = "zero"; break;
			case 1: result = "one"; break;
			case 2: result = "two"; break;
			case 3: result = "three"; break;
			case 4: result = "four"; break;
			case 5: result = "five"; break;
			case 6: result = "six"; break;
			case 7: result = "seven"; break;
			case 8: result = "eight"; break;
			case 9: result = "nine"; break;
		}
		return result;
	}
}