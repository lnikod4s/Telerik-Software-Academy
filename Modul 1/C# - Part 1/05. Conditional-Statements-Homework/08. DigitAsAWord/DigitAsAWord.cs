using System;
/*Problem 8. Digit as Word
----------------------------------------------------------------------------------------------------------------
Write a program that asks for a digit (0-9), and depending on the input, shows the digit as a word (in English).
Print “not a digit” in case of invalid input.
Use a switch statement.
Examples:

d		result
2		two
1		one
0		zero
5		five
-0.1	not a digit
hi		not a digit
9		nine
10		not a digit
*/

class DigitAsAWord
{
	static void Main()
	{
		Console.WriteLine("Please enter a digit (0-9): ");
		string input = Console.ReadLine();
		switch (input)
		{
			case "0": Console.WriteLine("zero"); break;
			case "1": Console.WriteLine("one"); break;
			case "2": Console.WriteLine("two"); break;
			case "3": Console.WriteLine("three"); break;
			case "4": Console.WriteLine("four"); break;
			case "5": Console.WriteLine("five"); break;
			case "6": Console.WriteLine("six"); break;
			case "7": Console.WriteLine("seven"); break;
			case "8": Console.WriteLine("eight"); break;
			case "9": Console.WriteLine("nine"); break;
			default: Console.WriteLine("not a digit"); break;
		}
	}
}