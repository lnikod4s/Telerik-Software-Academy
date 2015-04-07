using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics
{
	public class ShoppingCart : IShoppingCart
	{
		private const string VALUE_TYPE = "Products list in the shopping cart";

		public ShoppingCart()
		{
			this.Products = new List<IProduct>();
		}

		private List<IProduct> products;

		public List<IProduct> Products
		{
			get { return this.products; }
			set
			{
				if (value == null)
				{
					var errorMsg = string.Format(GlobalErrorMessages.ObjectCannotBeNull, VALUE_TYPE);
					throw new ArgumentNullException(errorMsg);
				}
				else
				{
					this.products = value;
				}
			}
		}

		public void AddProduct(IProduct product) { this.Products.Add(product); }

		public void RemoveProduct(IProduct product) { this.Products.Remove(product); }

		public bool ContainsProduct(IProduct product) { return this.Products.Contains(product); }

		public decimal TotalPrice()
		{
			return this.Products.Sum(product => product.Price);
		}
	}
}
