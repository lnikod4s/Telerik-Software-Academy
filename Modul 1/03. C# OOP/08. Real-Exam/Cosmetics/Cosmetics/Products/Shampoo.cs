using Cosmetics.Common;
using System;

namespace Cosmetics
{
	public class Shampoo : Product, Contracts.IShampoo
	{
		private uint millimeters;
		private UsageType usage;

		public Shampoo(string name, string brand, decimal price, GenderType gender, uint millimeters, UsageType usage)
			: base(name, brand, price, gender)
		{
			this.Milliliters = millimeters;
			this.Usage = usage;
		}

		public uint Milliliters
		{
			get { return this.millimeters; }
			protected set
			{
				if (value < 0)
				{
					var errorMsg = string.Format("Product quantity cannot be less than zero!");
					throw new ArgumentOutOfRangeException(string.Empty, errorMsg);
				}
				else
				{
					this.millimeters = value;
				}
			}
		}

		public UsageType Usage
		{
			get { return this.usage; }
			protected set { this.usage = value; }
		}

		public override string Print()
		{
			return base.Print() +
				   Environment.NewLine +
				   string.Format("  * Quantity: {0} ml", this.Milliliters) +
				   Environment.NewLine +
				   string.Format("  * Usage: {0}", this.Usage);
		}
	}
}
