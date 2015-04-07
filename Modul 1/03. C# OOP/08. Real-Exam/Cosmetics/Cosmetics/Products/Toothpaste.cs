using Cosmetics.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics
{
	public class Toothpaste : Product, Contracts.IToothpaste
	{
		private const int MIN_NAME_LENGTH = 4;
		private const int MAX_NAME_LENGTH = 12;
		private const string INGREDIENT = "Each ingredient";

		private IList<string> ingredients;

		public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
			: base(name, brand, price, gender)
		{
			this.ingredients = ingredients;
		}

		public string Ingredients
		{
			get { return string.Join(", ", this.ingredients); }
			private set
			{
				if (this.ingredients.Any(ingredient => ingredient.Length < MIN_NAME_LENGTH || ingredient.Length > MAX_NAME_LENGTH))
				{
					var errorMsg = string.Format(GlobalErrorMessages.InvalidStringLength, INGREDIENT, MIN_NAME_LENGTH, MAX_NAME_LENGTH);
					throw new ArgumentOutOfRangeException(string.Empty, errorMsg);
				}
				else
				{
					var stringifiedIngredients = string.Join(", ", this.ingredients);
					stringifiedIngredients = value;
				}
			}
		}

		public override string Print() { return string.Format(base.Print() + Environment.NewLine + "  * Ingredients: {0}", this.Ingredients); }
	}
}
