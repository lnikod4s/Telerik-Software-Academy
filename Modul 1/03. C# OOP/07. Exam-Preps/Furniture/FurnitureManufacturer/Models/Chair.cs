using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Models;

namespace FurnitureManufacturer
{
	public class Chair : Furniture, IChair
	{
		public Chair() { }

		public Chair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
			: base(model, materialType, price, height) { this.NumberOfLegs = numberOfLegs; }

		public int NumberOfLegs { get; private set; }
		public override string ToString() { return base.ToString() + string.Format(", Legs: {0}", this.NumberOfLegs); }
	}
}