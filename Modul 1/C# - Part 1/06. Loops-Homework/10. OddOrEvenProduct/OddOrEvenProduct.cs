using System;
using System.Linq;
/*Problem 10. Odd and Even Product
-----------------------------------------------------------------------------------------------------------------
You are given n integers (given in a single line, separated by a space).
Write a program that checks whether the product of the odd elements is equal to the product of the even elements.
Elements are counted from 1 to n, so the first element is odd, the second is even, etc.
Examples:

numbers				result
2 1 1 6 3			yes
product = 6	
3 10 4 6 5 1		yes
product = 60	
4 3 2 5 2			no
odd_product = 16	
even_product = 15	
*/

class OddOrEvenProduct
{
	static void Main()
	{
		string input = Console.ReadLine();
		int[] numbers = input.Split(' ').Select(int.Parse).ToArray();

		int oddElementsProduct = 1, evenElementsProduct = 1;
		for (int i = 0; i < numbers.Length; i++)
		{
			if (i % 2 == 0) evenElementsProduct *= numbers[i];
			else oddElementsProduct *= numbers[i];
		}
		bool areEqual = oddElementsProduct == evenElementsProduct;
		Console.WriteLine(areEqual);
	}
}
