using System;
// C# Part 2 - 2013/2014 @ 14 Sept 2013 - Morning
// 1. Multiverse Communication
class MultiverseCommunication
{
	static void Main()
	{
		string input = Console.ReadLine();
		string[] secretAlpha =
		{
			"CHU",
			"TEL",
			"OFT",
			"IVA",
			"EMY",
			"VNB",
			"POQ",
			"ERI",
			"CAD",
			"K-A",
			"IIA",
			"YLO",
			"PLA"
		};

		if (input.Length == 3)
		{
			Console.WriteLine(Array.IndexOf(secretAlpha, input));
		}
		else
		{
			long decimalResult = 0;
			for (int i = 0; i < input.Length; i += 3)
			{
				string currChunck = input.Substring(i, 3);
				int currChunkValue = Array.IndexOf(secretAlpha, currChunck);

				decimalResult *= 13;
				decimalResult += currChunkValue;
			}

			Console.WriteLine(decimalResult);
		}
	}
}