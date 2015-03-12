using System;
using System.Threading;

namespace _08.Events
{
	/// <summary>
	/// Problem 8.* Events
	/// Read in MSDN about the keyword event in C# and how to publish events. 
	/// Re-implement the above using .NET events and following the best practices.
	/// </summary>
	public class TimeElapsedEventArgs : EventArgs
	{
		private int ticksCount;

		public TimeElapsedEventArgs(int ticksCount)
		{
			this.TicksCount = ticksCount;
		}

		public int TicksCount { get; private set; }
	}

	public delegate void TimeElapsedEventHandler(object sender, TimeElapsedEventArgs e);

	public class Timer
	{
		private int delay;
		private int clicks;

		public Timer(int delay, int clicks)
		{
			this.Delay = delay;
			this.Clicks = clicks;
		}

		public int Delay
		{
			get { return this.delay; }
			private set
			{
				if (value < 0)
				{
					throw new ArgumentException("Delay must be non-negative number.");
				}

				this.delay = value;
			}
		}

		public int Clicks
		{
			get { return this.clicks; }
			private set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Clicks must be non-negative number.");
				}

				this.clicks = value;
			}
		}

		public event TimeElapsedEventHandler TimeElapsed;

		protected internal void OnTimeElapsed(int tick)
		{
			if (TimeElapsed != null)
			{
				TimeElapsed(this, new TimeElapsedEventArgs(tick));
			}
		}

		public void Activate()
		{
			int tick = this.Clicks;

			Thread newThread = new Thread(() =>
										  {
											  Thread.Sleep(this.Delay * 1000);
											  tick--;
											  OnTimeElapsed(tick);
										  });
			newThread.Start();
		}
	}

	public class Events
	{
		public static void Timer_TimeChanged(object sender, TimeElapsedEventArgs e)
		{
			Console.WriteLine("Time elapsed {0}", e.TicksCount);
		}

		static void Main()
		{
			Timer newTimer = new Timer(1, 20);
			newTimer.TimeElapsed += Timer_TimeChanged;
			newTimer.Activate();
		}
	}
}
