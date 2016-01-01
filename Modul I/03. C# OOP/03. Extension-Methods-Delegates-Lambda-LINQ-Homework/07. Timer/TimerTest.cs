using System;
using System.Threading;

public class TimerTest
{
	public static void Main()
	{
		TimerEvent te1 = ExecuteEachThreeSeconds;
		Timer tm1 = new Timer(3, te1);

		TimerEvent te2 = ExecuteEachFiveSeconds;
		Timer tm2 = new Timer(5, te2);

		Timer tm3 = new Timer(delegate { Console.WriteLine("Hello, there! You can see me each second."); });

		Thread thr1 = new Thread(tm1.RunTimer);
		thr1.Start();

		Thread thr2 = new Thread(tm2.RunTimer);
		thr2.Start();

		Thread thr3 = new Thread(tm3.RunTimer);
		thr3.Start();
	}

	private static void ExecuteEachThreeSeconds()
	{
		Console.WriteLine("You can see me every third second.");
	}

	private static void ExecuteEachFiveSeconds()
	{
		Console.WriteLine("You can see me every fifth second.");
	}
}