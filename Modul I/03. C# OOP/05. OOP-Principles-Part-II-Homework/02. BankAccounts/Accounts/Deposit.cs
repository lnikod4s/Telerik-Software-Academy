using _02.BankAccounts.Customers;

namespace _02.BankAccounts.Accounts
{
	class Deposit : Account
	{
		// Constructor
		public Deposit(Customer customer, decimal balance, decimal interestRate)
			: base(customer, balance, interestRate) { }

		// Methods
		public void Withdraw(decimal amount)
		{
			this.Balance -= amount;
		}

		#region Overrides of Account

		public override decimal InterestAmount(byte months)
		{
			if (this.Balance < 1000)
			{
				return 0;
			}
			else
			{
				return base.InterestAmount(months);
			}
		}

		#endregion
	}
}
