using System;
using System.Globalization;
using System.Threading;

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
		Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
		Console.Write("Enter a decimal number: ");
		double num = double.Parse(Console.ReadLine());

		double reversedNum = ReverseDecimal(num);
		Console.WriteLine("The reversed number is: {0}", reversedNum);
	}

	private static double ReverseDecimal(double number)
	{
		return double.Parse(ReverseString(number.ToString(CultureInfo.InvariantCulture)));
	}

	private static string ReverseString(string s)
	{
		char[] charArray = s.ToCharArray();
		Array.Reverse(charArray);
		return new string(charArray);
	}
}