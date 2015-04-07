using Cosmetics.Common;
using System;
using System.Text;

namespace Cosmetics
{
	public abstract class Product : Contracts.IProduct
	{
		private const int MIN_NAME_LENGTH = 3;
		private const int MAX_NAME_LENGTH = 10;
		private const int MIN_BRAND_LENGTH = 2;
		private const int MAX_BRAND_LENGTH = MAX_NAME_LENGTH;
		private const string PRODUCT_NAME = "Product name";
		private const string PRODUCT_BRAND = "Product brand";

		private string name;
		private string brand;
		private decimal price;
		private GenderType gender;

		protected Product(string name, string brand, decimal price, GenderType gender)
		{
			this.Name = name;
			this.Brand = brand;
			this.Price = price;
			this.Gender = gender;
		}

		public string Name
		{
			get { return this.name; }
			protected set
			{
				if (value.Length < MIN_NAME_LENGTH || value.Length > MAX_NAME_LENGTH)
				{
					var errorMsg = string.Format(GlobalErrorMessages.InvalidStringLength, PRODUCT_NAME, MIN_NAME_LENGTH, MAX_NAME_LENGTH);
					throw new ArgumentOutOfRangeException(string.Empty, errorMsg);
				}
				else
				{
					this.name = value;
				}
			}
		}

		public string Brand
		{
			get { return this.brand; }
			protected set
			{
				if (value.Length < MIN_BRAND_LENGTH || value.Length > MAX_BRAND_LENGTH)
				{
					var errorMsg = string.Format(GlobalErrorMessages.InvalidStringLength, PRODUCT_BRAND, MIN_BRAND_LENGTH, MAX_BRAND_LENGTH);
					throw new ArgumentOutOfRangeException(string.Empty, errorMsg);
				}
				else
				{
					this.brand = value;
				}
			}
		}

		public decimal Price
		{
			get { return this.price; }
			protected set { this.price = value; }
		}

		public GenderType Gender
		{
			get { return this.gender; }
			protected set { this.gender = value; }
		}

		public virtual string Print()
		{
			var result = new StringBuilder();
			result.AppendLine(string.Format(Environment.NewLine + "- {0} - {1}:", this.Brand, this.Name));
			result.AppendLine(string.Format("  * Price: ${0}", this.Price));
			result.Append(string.Format("  * For gender: {0}", this.Gender));
			return result.ToString();
		}
	}
}
