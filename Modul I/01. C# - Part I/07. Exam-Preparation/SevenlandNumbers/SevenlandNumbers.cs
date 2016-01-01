// Telerik Academy Exam 1 @ 28 Dec 2012
// Problem 1. Sevenland Numbers

using System;

class ExamPrep
{
	static void Main()
	{
		int K = int.Parse(Console.ReadLine());
		int result = 0;

		switch (K)
		{
			case 66: result = 100; break;
			case 166: result = 200; break;
			case 266: result = 300; break;
			case 366: result = 400; break;
			case 466: result = 500; break;
			case 566: result = 600; break;
			case 666: result = 1000; break;
			default:
				if (((K + 1) % 10) < 7) result = K + 1;
				else if (((K + 1) % 10) >= 7)
					switch ((K + 1) % 10)
					{
						case 7: result = K + 4; break;
						case 8: result = K + 3; break;
						case 9: result = K + 2; break;
					}
				break;
		}
		Console.WriteLine(result);
	}
}