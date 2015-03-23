using System;

namespace DefineClasses
{
	public class Call
	{
		public DateTime DateTime { get; set; }
		public string DialedNumber { get; set; }
		public double Duration { get; set; }

		public Call() { }
		public Call(DateTime dateTime, string dialedNumber, double duration)
		{
			this.DateTime = dateTime;
			this.DialedNumber = dialedNumber;
			this.Duration = duration;
		}

		public override string ToString()
		{
			return string.Format("Call: [{0}/{1}/{2}]", this.DateTime, this.DialedNumber, this.Duration);
		}
	}
}