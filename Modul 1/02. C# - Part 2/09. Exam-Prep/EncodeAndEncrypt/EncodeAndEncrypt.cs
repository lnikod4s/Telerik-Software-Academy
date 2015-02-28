using System;
using System.Text;
// C# Part 2 - 2013/2014 @ 14 Sept 2013 - Evening
// 4. Encode and Encrypt
class EncodeAndEncrypt
{
	static void Main(string[] args)
	{
		string message = Console.ReadLine();
		string cypher = Console.ReadLine();

		var cypherText = Encrypt(message, cypher) + cypher;
		var compressedCypherText = Encode(cypherText) + cypher.Length;

		Console.WriteLine(compressedCypherText);
	}

	private static string Encode(string message)
	{
		var encodedTextBuilder = new StringBuilder(message.Length);
		int indexInMessage = 0;
		while (indexInMessage < message.Length)
		{
			char currentSymbol = message[indexInMessage];
			int scanIndex = indexInMessage + 1;
			int repeatLength = 1;
			while (scanIndex < message.Length &&
				message[scanIndex] == currentSymbol)
			{
				repeatLength++;
				scanIndex++;
			}

			indexInMessage = scanIndex;
			if (repeatLength > 2)
			{
				encodedTextBuilder.Append(repeatLength);
				encodedTextBuilder.Append(currentSymbol);
			}
			else
			{
				encodedTextBuilder.Append(new string(currentSymbol, repeatLength));
			}
		}

		return encodedTextBuilder.ToString();
	}

	private static string Encrypt(string message, string cypher)
	{
		var cypherTextBuilder = new StringBuilder(message);

		int longer = Math.Max(message.Length, cypher.Length);

		for (int index = 0; index < longer; index++)
		{
			int indexInMessage = index % message.Length;
			int indexInCypher = index % cypher.Length;

			int charInMessageOffset = cypherTextBuilder[indexInMessage] - 'A';
			int charInCypherOffset = cypher[indexInCypher] - 'A';

			cypherTextBuilder[indexInMessage] = (char)('A' + (charInMessageOffset ^ charInCypherOffset));
		}

		return cypherTextBuilder.ToString();
	}
}