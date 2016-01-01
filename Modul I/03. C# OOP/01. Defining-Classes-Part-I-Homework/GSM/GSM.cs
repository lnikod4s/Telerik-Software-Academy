using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Define a class that holds information about a mobile phone device: model, manufacturer, price, owner, 
/// battery characteristics (model, hours idle and hours talk) => holding instances of class Battery and 
/// display characteristics (size and number of colors) => holding instances of class Display
/// </summary>
class GSM
{
	// default constants
	private const decimal DEFAULT_PRICE = 1800M;
	private const string DEFAULT_OWNER = "LuthorCorp";

	// constants
	private const decimal CALL_PRICE_PER_SECOND = 0.37M;

	// static readonly field to hold information about iPhone4S
	private readonly List<Call> CallHistory;

	// fields
	private string model;
	private string manufacturer;
	private decimal price;
	private string owner;

	// default constructor with mandatory arguments model & manufacturer
	public GSM(string model, string manufacturer)
		: this(model, manufacturer, DEFAULT_PRICE, DEFAULT_OWNER, new Battery(), new Display())
	{
	}

	// constructor with full set of arguments
	public GSM(string model, string manufacturer, decimal price, string owner, Battery battery, Display display)
	{
		this.Model = model;
		this.Manufacturer = manufacturer;
		this.Price = price;
		this.Owner = owner;
		this.Battery = battery;
		this.Display = display;
		this.CallHistory = new List<Call>();
	}

	// properties
	public static GSM IPhone4S { get; } = new GSM("Iphone 4S", "Apple", 1300.00M, "Mtel",
	            new Battery("Apple", 8, 200, Battery.Type.LiIon),
	            new Display(960, 640, 160000000));

	public string Model
	{
		get { return this.model; }
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentException("Model cannot be null or empty.");
			}

			this.model = value;
		}
	}

	public string Manufacturer
	{
		get { return this.manufacturer; }
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentException("Manufacturer cannot be null or empty.");
			}

			this.manufacturer = value;
		}
	}

	public decimal Price
	{
		get { return this.price; }
		set
		{
			if (value < 0)
			{
				throw new ArgumentException("Price must be at least zero.");
			}

			this.price = value;
		}
	}

	public string Owner
	{
		get { return this.owner; }
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentException("Owner cannot be null or empty.");
			}

			this.owner = value;
		}
	}

	public Battery Battery { get; } // data validated in Battery class

	public Display Display { get; } // data validated in Display class

	public override string ToString()
	{
		var result = new StringBuilder();
		result.Append("GSM Specifications:");
		result.AppendLine();
		result.AppendLine(new string('-', 100));
		result.AppendFormat("GSM Model: {0}", this.model);
		result.AppendLine();
		result.AppendFormat("GSM Manufacturer: {0}", this.manufacturer);
		result.AppendLine();
		result.AppendFormat("GSM Price: {0}", this.price);
		result.AppendLine();
		result.AppendFormat("GSM Owner: {0}", this.owner);
		result.AppendLine();
		result.AppendFormat("GSM battery specs : model - {1}, type - {0}, talk time - {2}, idle time - {3}"
					  , this.Battery.BatteryType, this.Battery.Model, this.Battery.HoursTalk, this.Battery.HoursIdle);
		result.AppendLine();
		result.AppendFormat("GSM display specs : height - {0}, width - {1}, number of colors - {2}",
						this.Display.Height, this.Display.Width, this.Display.NumberOfColors);
		result.AppendLine();
		result.AppendLine(new string('-', 100));

		return result.ToString();
	}

	//add call method (takes number as a string and duration - dateTime is always NOW)
	public void AddCall(string currPhoneNumber, ulong currCallDuration)
	{
		this.CallHistory.Add(new Call(currPhoneNumber, currCallDuration));
	}

	//remove call - takes a position from the ShowCallHistoryMethod - starts count from 1 not 0 for more user friendly interface
	public void DeleteCall(int position)
	{
		if ((this.CallHistory.Count <= position - 1) || (position - 1 < 0))
		{
			throw new ArgumentException("Call history log does not exists.");
		}

		this.CallHistory.RemoveAt(position - 1);
	}

	//adds an index so users can choose which call to delete
	public void ShowCallHistory()
	{
		var result = new StringBuilder();
		result.AppendLine("Current call history:");
		int index = 1;
		foreach (var call in this.CallHistory)
		{
			result.Append(index++);
			result.Append(" ---> ");
			result.Append(call);
			result.AppendLine();
		}

		Console.WriteLine(result);
	}

	public void ClearCallHistory()
	{
		this.CallHistory.Clear();
	}

	public decimal TotalCallPrice()
	{
		ulong overallDurationCalls = this.CallHistory.Aggregate<Call, ulong>(0, (current, call) => current + call.Duration);

		return overallDurationCalls * CALL_PRICE_PER_SECOND;
	}
}
