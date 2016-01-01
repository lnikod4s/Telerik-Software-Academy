using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer
{
	public class Company : ICompany
	{
		private string name;
		private string registrationNo;

		public Company(string name, string registrationNo)
		{
			this.Name = name;
			this.RegistrationNumber = registrationNo;
			this.Furnitures = new List<IFurniture>();
		}

		public string Name
		{
			get { return this.name; }
			private set
			{
				if (string.IsNullOrEmpty(value) ||
				    value.Length < 5)
				{
					throw new ArgumentException("Name cannot be empty, null or with less than 5 symbols.");
				}

				this.name = value;
			}
		}

		public string RegistrationNumber
		{
			get { return this.registrationNo; }
			private set
			{
				if (value.Length != 10 ||
				    value.Any(r => !char.IsDigit(r)))
				{
					throw new ArgumentException("Registration number must be exactly 10 symbols and must contain only digits.");
				}

				this.registrationNo = value;
			}
		}

		public ICollection<IFurniture> Furnitures { get; private set; }
		public void Add(IFurniture furniture) { this.Furnitures.Add(furniture); }
		public void Remove(IFurniture furniture) { this.Furnitures.Remove(furniture); }

		public IFurniture Find(string model)
		{
			return this.Furnitures.FirstOrDefault(f => f.Model.ToLower() == model.ToLower());
		}

		public string Catalog()
		{
			var sb = new StringBuilder();
			sb.AppendLine(string.Format("{0} - {1} - {2} {3}",
			                            this.Name,
			                            this.RegistrationNumber,
			                            this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
			                            this.Furnitures.Count != 1 ? "furnitures" : "furniture"));

			var sortedFurnitures = this.Furnitures.OrderBy(f => f.Price).ThenBy(f => f.Model);
			foreach (var furniture in sortedFurnitures)
			{
				sb.AppendLine(furniture.ToString());
			}

			return sb.ToString().Trim();
		}
	}
}