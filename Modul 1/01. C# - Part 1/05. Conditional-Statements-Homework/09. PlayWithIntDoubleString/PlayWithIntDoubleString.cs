using System;
/*Problem 9. Play with Int, Double and String
-----------------------------------------------------------------------------------------------
Write a program that, depending on the user’s choice, inputs an int, double or string variable.
If the variable is int or double, the program increases it by one.
If the variable is a string, the program appends * at the end.
Print the result at the console. Use switch statement.

Example 1:

program					user
Please choose a type:	
1 --> int	
2 --> double			3
3 --> string	
Please enter a string:	hello
hello*	

Example 2:

program					user
Please choose a type:	
1 --> int	
2 --> double			2
3 --> string	
Please enter a double:	1.5
2.5	
*/

class PlayWithIntDoubleString
{
	static void Main()
	{
		Console.WriteLine("Please choose a type: ");
		Console.WriteLine("1-->int");
		Console.WriteLine("2-->double");
		Console.WriteLine("3-->string");
		string input = Console.ReadLine();
 
		switch (input)
		{
			case "1":
				int outputInt = int.Parse(Console.ReadLine());
				Console.WriteLine(outputInt + 1); 
				break;
			case "2":
				double outputDouble = double.Parse(Console.ReadLine());
				Console.WriteLine(outputDouble + 1); 
				break;
			case "3":
				string outputString = Console.ReadLine();
				Console.WriteLine("{0}*", outputString);
				break;
		}
	}
}