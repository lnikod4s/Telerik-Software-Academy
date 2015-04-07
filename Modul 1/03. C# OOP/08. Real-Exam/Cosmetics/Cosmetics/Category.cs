using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmetics
{
	public class Category : ICategory
	{
		private const int MIN_NAME_LENGTH = 2;
		private const int MAX_NAME_LENGTH = 15;
		private const string STRING_NAME = "Category name";

		private string name;

		public Category(string name)
		{
			this.Name = name;
			this.Products = new List<IProduct>();
		}

		public string Name
		{
			get { return this.name; }
			private set
			{
				if (value.Length < MIN_NAME_LENGTH || value.Length > MAX_NAME_LENGTH)
				{
					var errorMsg = string.Format(GlobalErrorMessages.InvalidStringLength, STRING_NAME, MIN_NAME_LENGTH, MAX_NAME_LENGTH);
					throw new ArgumentOutOfRangeException(string.Empty, errorMsg);
				}
				else
				{
					this.name = value;
				}
			}
		}

		public IList<IProduct> Products { get; set; }

		public void AddCosmetics(IProduct cosmetics) { this.Products.Add(cosmetics); }

		public void RemoveCosmetics(IProduct cosmetics)
		{
			if (cosmetics == null)
			{
				var errorMsg = string.Format("Product {0} does not exist in category {1}!", cosmetics.Name, this.Name);
				throw new ArgumentNullException(string.Empty, errorMsg);
			}
			else
			{
				this.Products.Remove(cosmetics);
			}
		}

		public string Print()
		{
			var result = new StringBuilder();
			result.Append(string.Format("{0} category - {1} {2} in total",
				this.Name,
				this.Products.Count,
				this.Products.Count != 1 ? "products" : "product"));

			if (this.Products.Count == 0)
			{
				return result.ToString();
			}
			else
			{
				var sortedProducts = this.Products.OrderBy(p => p.Brand).ThenByDescending(p => p.Price);
				foreach (var product in sortedProducts)
				{
					result.Append(product.Print());
				}

				return result.ToString();
			}
		}
	}
}
