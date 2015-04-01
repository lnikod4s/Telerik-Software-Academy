using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Models;

namespace FurnitureManufacturer
{
	public class ConvertibleChair : Chair, IConvertibleChair
	{
		private readonly decimal initialHeight;
		public ConvertibleChair() { }

		public ConvertibleChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
			: base(model, materialType, price, height, numberOfLegs)
		{
			this.initialHeight = height;
		}

		public bool IsConverted { get; private set; }

		public void Convert()
		{
			this.Height = this.IsConverted ? this.initialHeight : 0.10M;
			this.IsConverted = !this.IsConverted;
		}

		public override string ToString()
		{
			return base.ToString() + string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal");
		}
	}
}