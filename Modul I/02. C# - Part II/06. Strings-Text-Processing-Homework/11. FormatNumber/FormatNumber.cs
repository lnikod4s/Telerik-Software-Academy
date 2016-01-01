using System;
/*Problem 11. Format number
------------------------------------------------------------------------------------------------------------------------
Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation.
Format the output aligned right in 15 symbols.
*/
class FormatNumber
{
	static void Main()
	{
		Console.Write("Enter a number: ");
		int num = int.Parse(Console.ReadLine());

		Console.WriteLine("{0,15:D}->Decimal", num);
		Console.WriteLine("{0,15:X}->Hexadecimal", num);
		Console.WriteLine("{0,15:P}->Percentage", num);
		Console.WriteLine("{0,15:E}->Scientific notation", num);
	}
}