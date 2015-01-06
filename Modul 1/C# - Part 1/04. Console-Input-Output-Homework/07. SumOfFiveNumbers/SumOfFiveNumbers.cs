using System;
using System.Linq;
/*Problem 7. Sum of 5 Numbers
----------------------------------------------------------------------------------------------------------------------
Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum.
Examples:

numbers				sum
1 2 3 4 5			15
10 10 10 10 10		50
1.5 3.14 8.2 -1 0	11.84
*/

class SumOfFiveNumbers
{
	static void Main()
	{
		string input = Console.ReadLine();
		double[] numbers = input.Split(' ').Select(double.Parse).ToArray();
		double sum = numbers.Sum();
		Console.WriteLine(sum);
	}
}
