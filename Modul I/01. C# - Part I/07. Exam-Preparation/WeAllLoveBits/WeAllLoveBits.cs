// Telerik Academy Exam 1 @ 6 Dec 2011 Morning
// Problem 4. We All Love Bits!

using System;

class WeAllLoveBits
{
	private static void Main()
	{
		int N = int.Parse(Console.ReadLine());

		for (int i = 0; i < N; i++)
		{
			int P = int.Parse(Console.ReadLine());
			int P_new = 0;

			while (P != 0)
			{
				P_new <<= 1;
				P_new |= (P & 1);
				P >>= 1;
			}
			Console.WriteLine(P_new);
		}
	}
}
