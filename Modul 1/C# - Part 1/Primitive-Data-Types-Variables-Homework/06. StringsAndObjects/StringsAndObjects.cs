using System;
/*Problem 6. Strings and Objects
-------------------------------------------------------------------------------------------------------------------
Declare two string variables and assign them with Hello and World.
Declare an object variable and assign it with the concatenation of the first two variables (mind adding an interval between).
Declare a third string variable and initialize it with the value of the object variable (you should perform type casting).
*/

class StringsAndObjects
{
	static void Main()
	{
		const string variable1 = "Hello";
		const string variable2 = "World";
		object variable3 = variable1 + " " + variable2;
		string variable4 = (string)variable3;
		Console.WriteLine(variable3);
		Console.WriteLine(variable4);
	}
}