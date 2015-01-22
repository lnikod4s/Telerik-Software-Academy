// Telerik Academy Exam 1 @ 7 Dec 2011 Morning
// Problem 4. Dancing Bits

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class DancingBits
{
	static void Main()
	{
		int K = int.Parse(Console.ReadLine());
		int N = int.Parse(Console.ReadLine());
		
		StringBuilder bits = new StringBuilder();
		int dancingBits = 0;
		for (int i = 0; i < N; i++) bits.Append(Convert.ToString(int.Parse(Console.ReadLine()), 2));

		for (int i = 0; i < bits.Length - K + 1; i++)
		{
			List<char> sequence = new List<char>();

			for (int j = 0; j < K; j++) sequence.Add(bits[j + i]);

			// Remove all similar elements
			sequence = sequence.Distinct().ToList();

			// We have similar elements -> check neighbours
			if (sequence.Count == 1)
			{
				// Check left neightbour for same value
				if (i > 0 && bits[i - 1] == sequence[0]) continue;

				// Check right neightbour for same value
				if (i + K < bits.Length && bits[i + K] == sequence[0]) continue;

				// Increasing 'dancingBitsCount' only if left and right
				// neightbours have different value than sequence value
				dancingBits++;
			}
		}

		Console.WriteLine(dancingBits);
	}
}
