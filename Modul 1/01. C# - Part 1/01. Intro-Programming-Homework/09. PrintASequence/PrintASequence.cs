using System;
/*Problem 9. Print a Sequence
------------------------------------------------------------------------------------------
Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...
*/ 

class PrintASequence
{
	static void Main()
	{
		int number = 2;
		for (int i = 0; i < 10; i++)
		{
			Console.Write(i % 2 == 0 ? "{0} " : "-{0} ", number);
			number++;
		}
		Console.WriteLine();
	}
}