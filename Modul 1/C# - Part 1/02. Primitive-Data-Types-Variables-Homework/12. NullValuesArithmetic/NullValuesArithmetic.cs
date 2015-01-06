using System;
/*Problem 12. Null Values Arithmetic
-----------------------------------------------------------------------------------
Create a program that assigns null values to an integer and to a double variable.
Try to print these variables at the console.
Try to add some number or the null literal to these variables and print the result.
*/

class NullValuesArithmetic
{
	static void Main()
	{
		int? someInteger = 5;

		if (someInteger == 5)
		{
			someInteger = null;
		}
		double? someDouble = 5.5;
		if (someDouble == 5.5)
		{
			someDouble = null;
		}
		Console.WriteLine("--- Before ---");
		Console.WriteLine("This is the integer number with Null value -> " + someInteger);
		Console.WriteLine("This is the double number with Null value -> " + someDouble);
		someInteger += 1;
		someDouble += 0.1;
		Console.WriteLine("--- After ---");
		Console.WriteLine("This is the integer number with Null value -> " + someInteger);
		Console.WriteLine("This is the double number with Null value -> " + someDouble);
	}
}