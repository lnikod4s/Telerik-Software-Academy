using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// C# Part 2 - 2012/2013 @ 4 Feb 2013 - Morning
/// 4. Console Justification
/// </summary>
class ConsoleJustification
{
	static void Main()
	{
		int lines = int.Parse(Console.ReadLine());
		int width = int.Parse(Console.ReadLine());

		var result = new List<string>();
		var text = new StringBuilder();
		for (int i = 0; i < lines; i++)
		{
			text.AppendFormat("{0} ", Console.ReadLine());
		}

		string[] words = text.ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

		AddWordsToList(width, ref result, ref words);

		AddSpacesBetweenWords(width, ref result);

		Console.WriteLine(string.Join(Environment.NewLine, result));
	}

	private static void AddSpacesBetweenWords(int width, ref List<string> result)
	{
		for (int i = 0; i < result.Count; i++)
		{
			int space = 1, index = 0;
			while (result[i].Length < width && index != -1)
			{
				index = result[i].IndexOf(new string(' ', space), StringComparison.Ordinal);
				while (index != -1 && result[i].Length < width && index != result[i].Length - 1)
				{
					result[i] = result[i].Insert(index, " ");
					index = result[i].IndexOf(new string(' ', space), index + space + 1, StringComparison.Ordinal);
				}

				space++;
				index = result[i].IndexOf(new string(' ', space), StringComparison.Ordinal);
			}
		}
	}

	static void AddWordsToList(int letterLimit, ref List<string> result, ref string[] words)
	{
		var text = new StringBuilder();
		for (int i = 0; i < words.Length; i++)
		{
			text.Append(words[i]);
			if (text.Length + (i + 1 < words.Length ? words[i + 1].Length : 0) >= letterLimit)
			{
				result.Add(text.ToString());
				text = text.Clear();
			}
			else
			{
				text.Append(" ");
			}
		}

		result.Add(text.ToString().Trim());
	}


}