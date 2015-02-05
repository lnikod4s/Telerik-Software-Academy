using System;
/*Problem 7. Reverse number
----------------------------------------------------------------
Write a method that reverses the digits of given decimal number.
Example:

input	output
256		652
*/
class ReverseNumber
{
	static void Main()
	{
		Console.Write("Enter a positive integer number: ");
		int num = int.Parse(Console.ReadLine());

		int reversedNum = ReverseDigits(num);
		Console.WriteLine("The reversed number is: {0}", reversedNum);
	}

	private static int ReverseDigits(int num)
	{
		int result = 0;
		while (num > 0)
		{
			result = result * 10 + num % 10;
			num /= 10;
		}
		return result;
	}
}