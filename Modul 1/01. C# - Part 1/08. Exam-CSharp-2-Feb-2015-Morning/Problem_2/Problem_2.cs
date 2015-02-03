using System;

class Problem_2
{
	static void Main()
	{
		int M = int.Parse(Console.ReadLine());
		string input = Console.ReadLine();

		long result = 0;
		char currChar = input[0];
		int index = 1;
		if (currChar == '@')
		{
			Console.WriteLine(result);
			return;
		}

		while (currChar != '@')
		{
			if (char.IsDigit(currChar))
			{
				result *= currChar - '0';
			}
			else if (char.IsLetter(currChar))
			{
				if (char.IsLower(currChar))
				{
					result += currChar - 'a';
				}
				else
				{
					result += currChar - 'A';
				}
			}
			else
			{
				result %= M;
			}
			currChar = input[index];
			index++;
		}
		Console.WriteLine(result);
	}
}
