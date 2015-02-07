using System;
/*Problem 2. Enter numbers
---------------------------------------------------------------------------------------------------------
Write a method ReadNumber(int start, int end) that enters an integer number in a given range [start…end].
If an invalid number or non-number text is entered, the method should throw an exception.
Using this method write a program that enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100
*/
class EnterNumbers
{
	static void Main()
	{
		const int START = 1;
		const int END = 100;

		Console.WriteLine("Enter 10 numbers in the range [1..100]:");

		try
		{
			int num = 0;
			for (int i = 0; i < 10; i++)
			{
				num = ReadNumber(START, END);
			}
		}
		catch (ArgumentOutOfRangeException)
		{
			Console.Error.WriteLine("\nError!\nNumber was out of the range [{0}..{1}]!\n", START, END);
		}
		catch (Exception e)
		{
			Console.Error.WriteLine("\n -> {0} -> {1}\n", e.GetType(), e.Message);
		}
	}

	private static int ReadNumber(int start, int end)
	{
		int num = int.Parse(Console.ReadLine());
		if (num < start || num > end)
		{
			throw new ArgumentOutOfRangeException();
		}

		return num;
	}
}