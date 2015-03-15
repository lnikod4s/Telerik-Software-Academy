using _02.BankAccounts.Customers;

namespace _02.BankAccounts.Accounts
{
	class Loan : Account
	{
		// Constructor
		public Loan(Customer customer, decimal balance, decimal interestRate)
			: base(customer, balance, interestRate) { }

		// Methods

		#region Overrides of Account

		public override decimal InterestAmount(byte months)
		{
			if ((Customer is Individual && months > 3) || (Customer is Company && months > 2))
			{
				return base.InterestAmount(months);
			}
			else
			{
				return 0;
			}
		}

		#endregion
	}
}
