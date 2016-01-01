using System;
/*Problem 4. Hexadecimal to decimal
-------------------------------------------------------------------------------
Write a program to convert hexadecimal numbers to their decimal representation.
*/
class HexToDec
{
	static void Main()
	{
		string hexadecimal = Console.ReadLine();
		int decimalNumber = 0;
		int grade = 0;

		for (int i = hexadecimal.Length - 1; i >= 0; i--)
		{
			char symbol = hexadecimal[i];
			int symbolValue = 0;
			if (char.IsNumber(symbol))
			{
				symbolValue = symbol - '0';
			}
			else
			{
				switch (symbol)
				{
					case 'A': symbolValue = 10; break;
					case 'B': symbolValue = 11; break;
					case 'C': symbolValue = 12; break;
					case 'D': symbolValue = 13; break;
					case 'E': symbolValue = 14; break;
					case 'F': symbolValue = 15; break;
				}
			}
			double currentGrade = Math.Pow(16, grade);
			decimalNumber += (int)currentGrade * symbolValue;
			grade++;
		}
		Console.WriteLine(decimalNumber);
	}
}