using System;
using System.Collections.Generic;
// C# Part 2 - 2013/2014 @ 24 Jan 2014 - Evening
// 4. Relevance Index
class RelevanceIndex
{
	static void Main()
	{
		string[] separators = { " ", ",", ".", "(", ")", ";", "-", "!", "?" };

		string searchWord = Console.ReadLine().ToLower();

		int lines = int.Parse(Console.ReadLine());

		string[] paragraphs = new string[lines];
		for (int i = 0; i < lines; i++)
		{
			paragraphs[i] = Console.ReadLine();
		}

		int[] relevances = new int[lines];
		string[] editedParagraphs = new string[lines];

		for (int paragraphInd = 0; paragraphInd < lines; paragraphInd++)
		{
			string[] paragraphWords = paragraphs[paragraphInd].Split(separators, StringSplitOptions.RemoveEmptyEntries);

			int currentRelevance = 0;
			for (int wordInd = 0; wordInd < paragraphWords.Length; wordInd++)
			{
				if (paragraphWords[wordInd].ToLower() == searchWord)
				{
					currentRelevance++;
					paragraphWords[wordInd] = paragraphWords[wordInd].ToUpper();
				}
			}

			relevances[paragraphInd] = currentRelevance;
			editedParagraphs[paragraphInd] = String.Join(" ", paragraphWords);
		}

		List<string> paragraphsByRelevance = new List<string>();

		while (paragraphsByRelevance.Count < editedParagraphs.Length)
		{
			int maxRelevance = 0;
			int maxRelevanceIndex = 0;
			for (int i = 0; i < relevances.Length; i++)
			{
				int currentRelevance = relevances[i];
				if (maxRelevance < currentRelevance)
				{
					maxRelevanceIndex = i;
					maxRelevance = currentRelevance;
				}
			}

			paragraphsByRelevance.Add(editedParagraphs[maxRelevanceIndex]);
			relevances[maxRelevanceIndex] = 0;
		}

		Console.WriteLine(String.Join(Environment.NewLine, paragraphsByRelevance));
	}
}