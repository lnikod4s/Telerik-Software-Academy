using System;
/*Problem 9. Sum of n Numbers
------------------------------------------------------------------------------------------------------------------------
Write a program that enters a number n and after that enters more n numbers and calculates and prints their sum. Note: You may need to use a for-loop.
Examples:

numbers	sum
3	90
20	
60	
10	
5	6.5
2	
-1	
-0.5	
4	
2	
1	1
1	
*/

class SumOfNNumbers
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
		Console.WriteLine(sum);
	}
}