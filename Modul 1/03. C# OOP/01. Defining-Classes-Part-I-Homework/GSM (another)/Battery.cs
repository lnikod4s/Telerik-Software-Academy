namespace DefineClasses
{
	public class Battery
	{
		private BatteryType batteryType;
		private string hoursIdle;
		private string hoursTalk;

		public Battery() { }
		public Battery(BatteryType batteryType, string hoursIdle, string hoursTalk)
		{
			this.BatteryType = batteryType;
			this.HoursIdle = hoursIdle;
			this.HoursTalk = hoursTalk;
		}

		public string HoursTalk
		{
			get { return this.hoursTalk; }
			set { this.hoursTalk = value; }
		}

		public string HoursIdle
		{
			get { return this.hoursIdle; }
			set { this.hoursIdle = value; }
		}

		public BatteryType BatteryType
		{
			get { return this.batteryType; }
			set { this.batteryType = value; }
		}

		public override string ToString()
		{
			return string.Format("Battery: [{0}/{1}/{2}]", this.BatteryType, this.HoursIdle, this.HoursTalk);
		}
	}
}