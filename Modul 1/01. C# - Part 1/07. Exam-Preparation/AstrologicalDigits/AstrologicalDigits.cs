// Telerik Academy Exam 1 @ 7 Dec 2011 Morning
// Problem 2. Astrological Digits

using System;
using System.Linq;
using System.Numerics;

class AstrologicalDigits
{
	static void Main()
	{
		string n = Console.ReadLine();
		if (n.Contains('.')) n = n.Remove(n.IndexOf('.'), 1);
		if (n.Contains('-')) n = n.Remove(0, 1);

		BigInteger sum = BigInteger.Parse(n);
		while (sum > 9)
		{
			sum = n.Aggregate<char, BigInteger>(0, (current, t) => current + (t - 48));
			n = sum.ToString();
		}
		Console.WriteLine(sum);
	}
}
