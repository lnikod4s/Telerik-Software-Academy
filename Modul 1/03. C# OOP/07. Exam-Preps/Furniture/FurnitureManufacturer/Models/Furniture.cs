using System;
using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Models;

namespace FurnitureManufacturer
{
	public abstract class Furniture : IFurniture
	{
		private readonly MaterialType materialType;
		private decimal height;
		private string model;
		private decimal price;
		protected Furniture() { }

		protected Furniture(string model, MaterialType materialType, decimal price, decimal height)
		{
			this.Model = model;
			this.materialType = materialType;
			this.Price = price;
			this.Height = height;
		}

		public string Model
		{
			get { return this.model; }
			protected set
			{
				if (string.IsNullOrEmpty(value) ||
				    value.Length < 3)
				{
					throw new ArgumentException("Model cannot be empty, null or with less than 3 symbols.");
				}

				this.model = value;
			}
		}

		public string Material
		{
			get { return this.materialType.ToString(); }
		}

		public decimal Price
		{
			get { return this.price; }
			set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Price cannot be less or equal to $0.00.");
				}

				this.price = value;
			}
		}

		public decimal Height
		{
			get { return this.height; }
			set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Height cannot be less or equal to 0.00 m.");
				}

				this.height = value;
			}
		}

		public override string ToString()
		{
			return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}",
			                     this.GetType().Name, this.Model, this.Material, this.Price, this.Height);
		}
	}
}