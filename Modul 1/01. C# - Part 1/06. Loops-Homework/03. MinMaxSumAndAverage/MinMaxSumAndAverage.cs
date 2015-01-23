using System;
using System.Linq;

/*Problem 3. Min, Max, Sum and Average of N Numbers
------------------------------------------------------------------------------------------------------------------------
Write a program that reads from the console a sequence of n integer numbers and returns the minimal, the maximal number, the sum and the average of all numbers (displayed with 2 digits after the decimal point).
The input starts by the number n (alone in a line) followed by n lines, each holding an integer number.
The output is like in the examples below.

Example 1:

input	output
3		min = 1
2		max = 5
5		sum = 8
1		avg = 2.67

Example 2:

input	output
2		min = -1
-1		max = 4
4		sum = 3
		avg = 1.50
*/

class MinMaxSumAndAverage
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		
		int[] numbers = new int[n];
		int sum = 0;
		for (int i = 0; i < n; i++)
		{
			numbers[i] = int.Parse(Console.ReadLine());
			sum += numbers[i];
		}
		Array.Sort(numbers);
		decimal average = (decimal)sum / n;
		
		Console.WriteLine("min = {0}", numbers.First());
		Console.WriteLine("max = {0}", numbers.Last());
		Console.WriteLine("sum = {0}", sum);
		Console.WriteLine("avg = {0:F2}", average);
	}
}