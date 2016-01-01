using System;
/*Problem 13. Reverse sentence
------------------------------------------------------------------------------
Write a program that reverses the words in given sentence.
Example:

input									output
C# is not C++, not PHP and not Delphi!	Delphi not and PHP, not C++ not is C#!
*/
class ReverseSentence
{
	static void Main()
	{
		string text = "C# is not C++ not PHP and not Delphi!";

		char sign = text[text.Length - 1];
		text = text.Remove(text.Length - 1, 1);
		string[] words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

		Array.Reverse(words);

		Console.WriteLine("Result: {0}{1}\n", string.Join(" ", words), sign);
	}
}