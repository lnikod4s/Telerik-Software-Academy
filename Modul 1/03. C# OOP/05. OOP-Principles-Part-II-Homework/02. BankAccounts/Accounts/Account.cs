using System.Text;
using _02.BankAccounts.Customers;

namespace _02.BankAccounts.Accounts
{
	abstract class Account
	{
		// Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="T:System.Object"/> class.
		/// </summary>
		protected Account() : this(default(Customer), default(decimal), default(decimal)) { }
		protected Account(Customer customer, decimal balance, decimal interestRate)
		{
			this.Customer = customer;
			this.Balance = balance;
			this.InterestRate = interestRate;
		}


		// Properties
		public Customer Customer { get; set; }
		public decimal Balance { get; set; }
		public decimal InterestRate { get;  set; }

		// Methods
		public void Deposit(decimal amount)
		{
			this.Balance += amount;
		}

		public virtual decimal InterestAmount(byte months)
		{
			return this.Balance * this.InterestRate * months;
		}

		#region Overrides of Object

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>
		/// A string that represents the current object.
		/// </returns>
		public override string ToString()
		{
			var result = new StringBuilder();
			result.AppendLine("Customer type: " + this.Customer.GetType().Name);
			result.AppendLine("Customer: " + this.Customer);
			result.AppendLine("Balance: " + this.Balance);
			result.AppendLine("Interest rate: " + this.InterestRate);
			return result.ToString();
		}

		#endregion
	}
}
