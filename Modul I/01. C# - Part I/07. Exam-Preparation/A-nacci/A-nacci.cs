// Telerik Academy Exam 1 @ 28 Dec 2012
// Problem 2. A-nacci

using System;

class ExamPrep
{
	static void Main()
	{
		char firstLetter = char.Parse(Console.ReadLine());
		char secondLetter = char.Parse(Console.ReadLine());
		int numberOfLines = int.Parse(Console.ReadLine());

		Console.WriteLine(firstLetter);
		char previousLetter = firstLetter;
		char currentLetter = secondLetter;
		char nextLetter = GetNextLetter(previousLetter, currentLetter);
		for (int i = 0; i < numberOfLines - 1; i++)
		{
			string whitespace = new string(' ', i);
			Console.WriteLine("{0}{1}{2}", currentLetter, whitespace, nextLetter);
			currentLetter = GetNextLetter(currentLetter, nextLetter);
			nextLetter = GetNextLetter(currentLetter, nextLetter);
		}
	}

	static char GetNextLetter(char previousLetter, char currentLetter)
	{
		char nextLetter = (char)(((previousLetter + currentLetter - 128) % 26) + 64);
		if (nextLetter == '@')
		{
			nextLetter = 'Z';
		}
		return nextLetter;
	}
}