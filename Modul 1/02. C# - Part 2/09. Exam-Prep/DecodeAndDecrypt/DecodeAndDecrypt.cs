using System;
using System.Collections.Generic;
using System.Text;
// C# Part 2 - 2013/2014 @ 14 Sept 2013 - Morning
// 4. Decode and Decrypt
class DecodeAndDecrypt
{
	static void Main()
	{
		/*input = Encode(Encrypt(message, cypher) + cypher) + lengthOfCypher
		=> lengthOfCypher = last digits of input
		=> decodedInput = Encrypt(message, cypher) + cypher
		=> cypher = decodedInput.Substring(end, lengthOfCypher);
		=> encryptedInput = Encrypt(message, cypher)
		=> message = Encrypt(encryptedInput, cypher)
		 */
		var input = Console.ReadLine();
		var lengthOfCypher = GetCypherLength(input);

		var encodedInput = input.Substring(0, input.Length - lengthOfCypher.Length);
		var decodedInput = Decode(encodedInput);
		var cypher = decodedInput.Substring(decodedInput.Length - int.Parse(lengthOfCypher), int.Parse(lengthOfCypher));

		var encryptedInput = decodedInput.Substring(0, decodedInput.Length - int.Parse(lengthOfCypher));
		var message = Encrypt(encryptedInput, cypher);

		Console.WriteLine(message);
	}

	private static string Decode(string encodedInput)
	{
		var result = new StringBuilder();
		var count = 0;
		foreach (char c in encodedInput)
		{
			if (char.IsDigit(c))
			{
				count *= 10;
				count += c - '0';
			}
			else
			{
				if (count == 0)
				{
					result.Append(c);
				}
				else
				{
					result.Append(c, count);
					count = 0;
				}
			}
		}

		return result.ToString();
	}

	private static string Encrypt(string encryptedInput, string cypher)
	{
		var steps = Math.Max(encryptedInput.Length, cypher.Length);
		var result = new StringBuilder(encryptedInput);
		for (int step = 0; step < steps; step++)
		{
			var messageIndex = step % encryptedInput.Length;
			var cypherIndex = step % cypher.Length;
			result[messageIndex] = (char)(((result[messageIndex] - 'A') ^ (cypher[cypherIndex] - 'A')) + 'A');
		}

		return result.ToString();
	}

	private static string GetCypherLength(string input)
	{
		var cypher = new List<int>();
		for (int i = input.Length - 1; i > 0; i--)
		{
			char currChar = input[i];
			if (char.IsDigit(currChar))
			{
				cypher.Add(currChar - '0');
			}
			else
			{
				break;
			}
		}

		cypher.Reverse();

		var result = new StringBuilder();
		foreach (int t in cypher)
		{
			result.Append(t);
		}

		return result.ToString();
	}
}