using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// C# Part 2 - 2012/2013 @ 11 Feb 2013
/// 4. Fake Text Markup Language
/// </summary>
class FTML
{
	private const string OPEN_TAG_REV = "<rev>";
	private const string OPEN_TAG_UPPER = "<upper>";
	private const string OPEN_TAG_LOWER = "<lower>";
	private const string OPEN_TAG_TOGGLE = "<toggle>";
	private const string OPEN_TAG_DEL = "<del>";

	private const string CLOSE_TAG_REV = "</rev>";
	private const string CLOSE_TAG_UPPER = "</upper>";
	private const string CLOSE_TAG_LOWER = "</lower>";
	private const string CLOSE_TAG_TOGGLE = "</toggle>";
	private const string CLOSE_TAG_DEL = "</del>";

	private static readonly StringBuilder result = new StringBuilder();
	private static int openedDelTags = 0;
	private static readonly List<string> currOpenedTag = new List<string>();
	private static readonly List<int> revTagStarts = new List<int>();

	static void Main()
	{
		int numberOfLines = int.Parse(Console.ReadLine());

		for (int i = 0; i < numberOfLines; i++)
		{
			string currLine = Console.ReadLine();

			int index = 0;
			while (index < currLine.Length)
			{
				if (currLine[index] == '<')
				{
					string tag = GetTag(currLine, index);
					ProcessTag(tag);

					index += tag.Length - 1;
				}
				else
				{
					if (openedDelTags == 0)
					{
						char symbolToAdd = currLine[index];

						for (int j = currOpenedTag.Count - 1; j >= 0; j--)
						{
							symbolToAdd = ApplyTags(symbolToAdd, currOpenedTag[j]);
						}

						result.Append(symbolToAdd);
					}
				}

				index++;
			}

			result.Append('\n');
		}

		Console.WriteLine(result);
	}

	private static char ApplyTags(char symbol, string currTag)
	{
		if (char.IsLetter(symbol))
		{
			if (currTag == OPEN_TAG_UPPER)
			{
				symbol = char.ToUpper(symbol);
			}
			else if (currTag == OPEN_TAG_LOWER)
			{
				symbol = char.ToLower(symbol);
			}
			else if (currTag == OPEN_TAG_TOGGLE)
			{
				symbol = char.IsLower(symbol) ? char.ToUpper(symbol) : char.ToLower(symbol);
			}
		}

		return symbol;
	}

	private static void ProcessTag(string tag)
	{
		if (tag == OPEN_TAG_DEL)
		{
			openedDelTags++;
		}
		else if (tag == CLOSE_TAG_DEL)
		{
			openedDelTags--;
		}
		else
		{
			if (openedDelTags == 0)
			{
				if (tag == OPEN_TAG_REV)
				{
					revTagStarts.Add(result.Length);
				}
				else if (tag == CLOSE_TAG_REV)
				{
					int currRevStart = revTagStarts[revTagStarts.Count - 1];
					int currRevEnd = result.Length - 1;

					Reverse(currRevStart, currRevEnd);
					revTagStarts.RemoveAt(revTagStarts.Count - 1);
				}
				else if (tag[1] == '/')
				{
					currOpenedTag.RemoveAt(currOpenedTag.Count - 1);
				}
				else
				{
					currOpenedTag.Add(tag);
				}
			}
		}
	}

	private static void Reverse(int currRevStart, int currRevEnd)
	{
		int start = currRevStart;
		int end = currRevEnd;
		while (start < end)
		{
			char bufferChar = result[start];
			result[start] = result[end];
			result[end] = bufferChar;

			end--;
			start++;
		}
	}

	private static string GetTag(string currLine, int index)
	{
		int tagStart = index;
		int tagEnd = currLine.IndexOf('>', tagStart + 1);

		string tag = currLine.Substring(tagStart, tagEnd - tagStart + 1);

		return tag;
	}
}