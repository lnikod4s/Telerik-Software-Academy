using System;
using System.Threading;

class Problem_1
{
	static void Main()
	{
		Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
		int N = int.Parse(Console.ReadLine());
		int S = int.Parse(Console.ReadLine());
		decimal P = decimal.Parse(Console.ReadLine());

		int totalStuds = N * S;
		decimal realms = (decimal)totalStuds / 500;
		decimal totalPrice = realms * P;
		Console.WriteLine("{0:F2}", totalPrice);
	}
}