// Telerik Academy Exam 1 @ 23 June 2013
// Problem 3. Bulls and Cows

using System;
using System.Collections.Generic;

class ExamPrep
{
	static void Main()
	{
		string secretNum = Console.ReadLine();

		int targetBulls = int.Parse(Console.ReadLine());
		int targetCows = int.Parse(Console.ReadLine());

		const char USED_SECRET_DIGIT = '*';
		const char USED_GUESS_DIGIT = '@';

		List<int> results = new List<int>();

		for (int num = 1000; num <= 9999; num++)
		{
			int foundBulls = 0, foundCows = 0;

			char[] digitsGuess = num.ToString().ToCharArray();
			char[] digitsSecret = secretNum.ToCharArray();

			if (digitsGuess[0] >= '1' && digitsGuess[1] >= '1' && digitsGuess[2] >= '1' && digitsGuess[3] >= '1')
			{
				for (int i = 0; i < digitsGuess.Length; i++)
				{
					if (digitsGuess[i] == digitsSecret[i])
					{
						foundBulls++;
						digitsGuess[i] = USED_GUESS_DIGIT;
						digitsSecret[i] = USED_SECRET_DIGIT;
					}
				}

				for (int secretIndex = 0; secretIndex < digitsSecret.Length; secretIndex++)
				{
					for (int guessIndex = 0; guessIndex < digitsGuess.Length; guessIndex++)
					{
						if (digitsSecret[secretIndex] == digitsGuess[guessIndex])
						{
							foundCows++;
							digitsGuess[guessIndex] = USED_GUESS_DIGIT;
							digitsSecret[secretIndex] = USED_SECRET_DIGIT;
						}
					}
				}

				if (foundBulls == targetBulls && foundCows == targetCows)
				{
					results.Add(num);
				}
			}
		}

		if (results.Count == 0)
		{
			Console.WriteLine("No");
		}
		else
		{
			for (int i = 0; i < results.Count; i++)
			{
				Console.Write(i != results.Count - 1 ? results[i] + " " : results[i] + "\n");
			}
		}
	}
}