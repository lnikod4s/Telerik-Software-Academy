using System;
using System.Text;

// C# Part 2 - 2013/2014 @ 22 Jan 2014 - Evening
// 4. Variable Length Codes
class VariableLengthCodes
{
	static void Main()
	{
		// First line => Read the sequence of integers (encoded text)
		string encodedText = Console.ReadLine();

		string[] encodedStrings = encodedText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

		byte[] encodedNumbers = new byte[encodedStrings.Length];

		for (int i = 0; i < encodedNumbers.Length; i++)
		{
			encodedNumbers[i] = byte.Parse(encodedStrings[i]);
		}

		// Binary conversion of encoded text
		var binaryEncodedText = new StringBuilder();
		foreach (var number in encodedNumbers)
		{
			binaryEncodedText.Append(Convert.ToString(number, 2).PadLeft(8, '0'));
		}

		// Split the binary represantation of encoded text( GOAL: binary reprasentation of every symbol)
		string[] encodedSymbols = binaryEncodedText.ToString().Split(new[] { '0' }, StringSplitOptions.RemoveEmptyEntries);

		// Second line => the number of lines in the code table
		int codeTableSize = int.Parse(Console.ReadLine());

		char[] symbolPerCodeLength = new char[codeTableSize + 1];
		for (int i = 0; i < codeTableSize; i++)
		{
			string currentCodePair = Console.ReadLine();
			char symbol = currentCodePair[0];
			int codeLength = int.Parse(currentCodePair.Substring(1));

			symbolPerCodeLength[codeLength] = symbol;
		}

		for (int i = 0; i < encodedSymbols.Length; i++)
		{
			var codedSymbol = encodedSymbols[i];
			Console.Write(symbolPerCodeLength[codedSymbol.Length]);
		}

		Console.WriteLine();
	}
}