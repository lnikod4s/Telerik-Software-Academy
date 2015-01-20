// Telerik Academy Exam 1 @ 23 June 2013
// Problem 5. Neurons


using System;
using System.Collections.Generic;

class ExamPrep
{
	static void Main()
	{
		List<uint> list = new List<uint>();

		while (true)
		{
			string tmp = Console.ReadLine();

			if (tmp == "-1") break;

			uint n = uint.Parse(tmp);
			list.Add(n);
		}

		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] == 0) continue;

			char[] numbers = Convert.ToString(list[i], 2).PadLeft(32, '0').ToCharArray();

			int startOne = Array.IndexOf(numbers, '1');
			int lastOne = Array.LastIndexOf(numbers, '1');

			for (int j = startOne; j <= lastOne; j++)
			{
				if (numbers[j] == '1') numbers[j] = '0';
				else if (numbers[j] == '0') numbers[j] = '1';
			}

			string result = new string(numbers);

			list[i] = Convert.ToUInt32(result, 2);
		}

		foreach (var u in list)
		{
			Console.WriteLine(u);
		}
	}
}