using System;
/*Problem 6. Four-Digit Number
--------------------------------------------------------------------------------------------------------------
Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
Calculates the sum of the digits (in our example 2 + 0 + 1 + 1 = 4).
Prints on the console the number in reversed order: dcba (in our example 1102).
Puts the last digit in the first position: dabc (in our example 1201).
Exchanges the second and the third digits: acbd (in our example 2101).
The number has always exactly 4 digits and cannot start with 0.

Examples:

n		sum of digits	reversed	last digit in front		second and third digits exchanged
2011	4				1102				1201						2101
3333	12				3333				3333						3333
9876	30				6789				6987						9786
*/

class FourDigitNumber
{
	static void Main()
	{
		Console.WriteLine("Please enter a four-digit number: ");
		int n = int.Parse(Console.ReadLine());
		byte D = (byte)(n % 10);
		n /= 10;
		byte C = (byte)(n % 10);
		n /= 10;
		byte B = (byte)(n % 10);
		n /= 10;
		byte A = (byte)(n % 10);
		int sumOfDigits = A + B + C + D;
		Console.Write("Sum of digits: ");
		Console.WriteLine(sumOfDigits);
		Console.Write("Reversed: ");
		Console.WriteLine("{0}{1}{2}{3}", D, C, B, A);
		Console.Write("Last digit in front: ");
		Console.WriteLine("{0}{1}{2}{3}", D, A, B, C);
		Console.Write("Second and third digits exchanged: ");
		Console.WriteLine("{0}{1}{2}{3}", A, C, B, D);
	}
}