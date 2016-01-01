using System;
/*Problem 2. Float or Double?
-----------------------------------------------------------------------------------------------------------------
Which of the following values can be assigned to a variable of type float and which to a variable of type double: 34.567839023, 12.345, 8923.1234857, 3456.091?
Write a program to assign the numbers in variables and print them to ensure no precision is lost.
 */ 

class FloatOrDouble
{
	static void Main()
	{
		const double variable1 = 34.567839023;
		const float variable2 = 12.345f;
		const double variable3 = 8923.1234857;
		const float variable4 = 3456.091f;
		Console.WriteLine(variable1);
		Console.WriteLine(variable2);
		Console.WriteLine(variable3);
		Console.WriteLine(variable4);
	}
}