using System;
using System.Threading;

/// <summary>
/// Problem 7. Timer
/// Using delegates write a class Timer that can execute certain method at each t seconds.
/// </summary>
public delegate void TimerEvent();

public class Timer
{
	private readonly TimerEvent timerEvent;
	private int count;
	private int interval; // in miliseconds
	private int ticks;

	// Constructor with two arguments => ticks and interval in seconds
	public Timer(int count, int interval, TimerEvent timerEvent)
	{
		this.Count = count;
		this.Interval = interval;
		this.Ticks = 0;
		this.timerEvent = timerEvent;
	}

	// Constructor with one argument => interval in seconds and ticks value = int.MaxValue
	public Timer(int interval, TimerEvent timerEvent)
		: this(int.MaxValue, interval, timerEvent)
	{
	}

	// Empty constructor with interval value = 1 second and ticks value = int.MaxValue
	public Timer(TimerEvent timerEvent)
		: this(int.MaxValue, 1, timerEvent)
	{
	}

	public int Ticks { get; set; }

	public int Interval
	{
		get { return this.interval; }
		private set
		{
			if (value <= 0)
			{
				throw new ArgumentException("Interval must be > 0 !");
			}

			this.interval = value * 1000;
		}
	}

	public int Count
	{
		get { return this.count; }
		private set
		{
			if (value <= 0)
			{
				throw new ArgumentException("Count must be > 0 !");
			}

			this.count = value;
		}
	}

	/// <exception cref="Exception">A delegate callback throws an exception. </exception>
	public void RunTimer()
	{
		while (this.Ticks < this.Count)
		{
			Thread.Sleep(this.Interval);
			this.Ticks++;
			timerEvent();
		}
	}
}