namespace _02.BankAccounts.Customers
{
	abstract class Customer
	{
		// Constructors
		protected Customer() { }
		protected Customer(string name)
		{
			this.Name = name;
		}

		// Property
		public string Name { get; set; }

		// Method
		#region Overrides of Object

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>
		/// A string that represents the current object.
		/// </returns>
		public override string ToString()
		{
			return string.Format("Name: " + this.Name);
		}

		#endregion
	}
}
