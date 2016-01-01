using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefineClasses
{
	public class GSM
	{
		private string model;
		private string manufacturer;
		private double? price;
		private string owner;
		private Battery battery;
		private Display display;
		private static GSM iphone4s;
		private List<Call> callHistory;

		public GSM() { }
		public GSM(string model, string manufacturer) { }
		public GSM(string model, string manufacturer, string owner) { this.Owner = owner; }
		public GSM(string model, string manufacturer, Battery battery) { this.Battery = battery; }
		public GSM(string model, string manufacturer, Display display) { this.Display = display; }
		public GSM(string model, string manufacturer, double? price) { this.Price = price; }
		public GSM(string model, string manufacturer, double? price, string owner, Battery battery, Display display, List<Call> callHistory)
		{
			this.Model = model;
			this.Manucfacturer = manufacturer;
			this.Price = price;
			this.Owner = owner;
			this.Battery = battery;
			this.Display = display;
			this.CallHistory = callHistory;
		}

		static GSM()
		{
			IPhone4S =
				new GSM("IPhone4S", "Apple", 365.99, "Mr. Nobody", new Battery(BatteryType.LiIon, "12:53", "03:34"), new Display(4.5, 16000000), new List<Call>());
		}

		public List<Call> CallHistory { get; set; }

		public static GSM IPhone4S
		{
			get { return iphone4s; }
			set { iphone4s = value; }
		}

		public Display Display
		{
			get { return this.display; }
			set { this.display = value; }
		}

		public Battery Battery
		{
			get { return this.battery; }
			set { this.battery = value; }
		}

		public string Owner
		{
			get { return this.owner; }
			set { this.owner = value; }
		}

		public double? Price
		{
			get { return this.price; }
			set { this.price = value; }
		}

		public string Manucfacturer
		{
			get { return this.manufacturer; }
			set { this.manufacturer = value; }
		}

		public string Model
		{
			get { return this.model; }
			set { this.model = value; }
		}

		public void AddCall(Call call) { this.CallHistory.Add(call); }

		public void DeleteCall(Call call) { this.CallHistory.Remove(call); }

		public void ClearCallHistory() { this.CallHistory = new List<Call>(); }

		public string CalculateOverallCallPrice(decimal pricePerMin)
		{
			return string.Format("{0:F2}", this.CallHistory.Sum(call => (decimal)call.Duration * pricePerMin));
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine("Model: " + this.Model);
			sb.AppendLine("Manufacturer: " + this.Manucfacturer);
			sb.AppendLine("Price: " + this.Price);
			sb.AppendLine("Owner: " + this.Owner);
			sb.AppendLine(this.Battery.ToString());
			sb.AppendLine(this.Display.ToString());
			return sb.ToString();
		}
	}
}