using System;
using System.Linq;
using System.Text;

/// <summary>
/// Defines a class Call to hold a call performed through a GSM. 
/// It contains following characteristics date, time, dialed phone number and duration (in seconds).
/// </summary>
class Call
{
	// fields
	private DateTime dateTime;
	private string phoneNumber;
	private ulong durationCall;

	// default constructor without any parameters
	public Call()
	{
	}

	// constructor with parameters
	public Call(string phoneNumber, ulong durationCall)
	{
		this.DateTime = DateTime.Now;
		this.PhoneNumber = phoneNumber;
		this.Duration = durationCall;
	}

	// properties => encapsulation
	public DateTime DateTime { get; private set; } = DateTime.Now;

	public string PhoneNumber
	{
		get { return this.phoneNumber; }
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentException("Phone number cannot be null or empty.");
			}

			if ((value.Length != 10 && value.Length != 13) || (value.First() != '0' && value.First() != '+'))
			{
				throw new ArgumentException("Phone number format is not properly set.");
			}

			this.phoneNumber = value;
		}
	}

	public ulong Duration
	{
		get { return this.durationCall; }
		set
		{
			if (value < 0)
			{
				throw new ArgumentException("Duration must be at least zero.");
			}

			this.durationCall = value;
		}
	}

	public override string ToString()
	{
		var result = new StringBuilder();
		result.AppendFormat("Phone number[{0}] has following call duration[{1}] at [{2}]", this.phoneNumber, this.durationCall, this.dateTime);

		return result.ToString();
	}
}