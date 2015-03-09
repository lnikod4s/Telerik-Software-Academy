using System;

/// <summary>
/// Defines class Battery with following characteristics: model, hours idle and hours talk
/// </summary>
class Battery
{
	// default const values
	private const string DEFAULT_MODEL = "Unknown";
	private const uint DEFAULT_HOURS_TALK = 100;
	private const uint DEFAULT_HOURS_IDLE = 200;
	private const Type DEFAULT_BATTERY_TYPE = Type.Unknown;

	// fields
	private string model;
	private uint hoursIdle;
	private uint hoursTalk;
	private Type batteryType;

	// enumeration, holding different battery types
	public enum Type
	{
		LiIon,
		NiMH,
		NiCd,
		Unknown
	}


	// constructors
	public Battery()
		: this(DEFAULT_MODEL, DEFAULT_HOURS_TALK, DEFAULT_HOURS_IDLE, DEFAULT_BATTERY_TYPE) // default constructor, invoked with default parameters
	{
	}

	public Battery(string model, uint hoursIdle, uint hoursTalk, Type batteryType) // constructor with parameters
	{
		this.Model = model;
		this.hoursIdle = hoursIdle;
		this.hoursTalk = hoursTalk;
		this.batteryType = batteryType;
	}

	// properties
	public string Model
	{
		get { return this.model; }
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentException("The battery model cannot be null or emtpy.");
			}
			else
			{
				this.model = value;
			}
		}
	}

	public uint HoursTalk
	{
		get { return this.hoursTalk; }
		set
		{
			if (value < 0)
			{
				throw new ArgumentException("Talk hours must be at least zero.");
			}
			else
			{
				this.hoursTalk = value;
			}
		}
	}

	public uint HoursIdle
	{
		get { return this.hoursIdle; }
		set
		{
			if (value < 0)
			{
				throw new ArgumentException("Idle hours must be at least zero.");
			}
			else
			{
				this.hoursIdle = value;
			}
		}
	}

	public Type BatteryType { get; set; } = Type.Unknown;
}