using System;
using System.Linq;
using System.Text;

// C# Part 2 - 2013/2014 @ 14 Sept 2013 - Evening
// 2. Moving Letters
class MovingLetters
{
	static void Main()
	{
		// Read input data
		string input = Console.ReadLine();
		string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

		// Aplying Nakov's algorithm
		var sequence = ExtractingLettersAlgorithm(words);
		var result = MovingLettersAlgorithm(sequence);

		// Printing the result
		Console.WriteLine(result);
	}

	private static StringBuilder MovingLettersAlgorithm(StringBuilder sequence)
	{
		for (int i = 0; i < sequence.Length; i++)
		{
			char currLetter = sequence[i];
			int alphaCode = char.IsLower(currLetter) ? currLetter - 'a' + 1 : currLetter - 'A' + 1;
			sequence.Remove(i, 1);
			int position = (i + alphaCode) % (sequence.Length + 1);
			sequence.Insert(position, currLetter);
		}

		return sequence;
	}

	private static StringBuilder ExtractingLettersAlgorithm(string[] words)
	{
		var result = new StringBuilder();
		int length = words.Max(x => x.Length);
		for (int index = 0; index < length; index++)
		{
			foreach (var word in words)
			{
				int currentLetterIndex = word.Length - 1 - index;
				if (currentLetterIndex >= 0)
				{
					result.Append(word[currentLetterIndex]);
				}
			}
		}

		return result;
	}
}