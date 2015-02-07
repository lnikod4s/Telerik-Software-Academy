using System;
/*Problem 1. Square root
---------------------------------------------------------------------------------------
Write a program that reads an integer number and calculates and prints its square root.
If the number is invalid or negative, print Invalid number.
In all cases finally print Good bye.
Use try-catch-finally block.
*/
class SquareRoot
{
	static void Main()
	{
		try
		{
			Console.Write("Enter a positive integer number: ");
			uint num = uint.Parse(Console.ReadLine());
			Console.WriteLine("{0:F2}", Math.Sqrt(num));
		}
		catch
		{

			Console.WriteLine("Invalid number.");
		}
		finally
		{
			Console.WriteLine("Good bye.");
		}
	}
}