// Telerik Academy Exam 1 @ 6 December 2013 Morning
// Problem 3. X Expression

using System;

class ExpressionSolution
{
	static void Main()
	{
		int symbol = Console.Read();
		decimal sum = 0;
		int o = '+';

		while (symbol != '=')
		{
			if (symbol == '(')
			{
				decimal innerSum = 0;
				int innerO = '+';
				symbol = Console.Read();

				while (symbol != ')')
				{
					if (0 <= symbol - '0' && symbol - '0' <= 9)
					{
						switch (innerO)
						{
							case '+':
								innerSum += symbol - '0';
								break;
							case '-':
								innerSum -= symbol - '0';
								break;
							case '*':
								innerSum *= symbol - '0';
								break;
							case '/':
								innerSum /= symbol - '0';
								break;
						}
					}
					else if (symbol == '+' ||
							 symbol == '-' ||
							 symbol == '/' ||
							 symbol == '*')
					{
						innerO = symbol;
					}
					symbol = Console.Read();
				}

				switch (o)
				{
					case '+':
						sum += innerSum;
						break;
					case '-':
						sum -= innerSum;
						break;
					case '*':
						sum *= innerSum;
						break;
					case '/':
						sum /= innerSum;
						break;
				}
			}
			else if (0 <= symbol - '0' && symbol - '0' <= 9)
			{
				switch (o)
				{
					case '+':
						sum += symbol - '0';
						break;
					case '-':
						sum -= symbol - '0';
						break;
					case '*':
						sum *= symbol - '0';
						break;
					case '/':
						sum /= symbol - '0';
						break;
				}
			}
			else if (symbol == '+' ||
					 symbol == '-' ||
					 symbol == '/' ||
					 symbol == '*')
			{
				o = symbol;
			}
			symbol = Console.Read();
		}

		Console.WriteLine("{0:0.00}", sum);
	}
}