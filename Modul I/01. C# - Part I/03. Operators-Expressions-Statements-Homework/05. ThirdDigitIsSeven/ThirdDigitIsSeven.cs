using System;
/*Problem 5. Third Digit is 7?
---------------------------------------------------------------------------------------------
Write an expression that checks for given integer if its third digit from right-to-left is 7.
Examples:

n			Third digit 7?
5			false
701			true
9703		true
877			false
777877		false
9999799		true
*/

class ThirdDigitIsSeven
{
	static void Main()
	{
		Console.WriteLine("Please enter a positive number: ");
		int n = int.Parse(Console.ReadLine());

		int temp = 0;
		for (int i = 0; i < 3; i++)
		{
			temp = n % 10;
			n /= 10;
		}
		bool isThirdDigitSeven = temp == 7;
		Console.WriteLine("Third digit 7?");
		Console.WriteLine(isThirdDigitSeven);
	}
}