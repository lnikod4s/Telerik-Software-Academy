using _02.BankAccounts.Customers;

namespace _02.BankAccounts.Accounts
{
	class Mortgage : Account
	{
		// Constructor
		public Mortgage(Customer customer, decimal balance, decimal interestRate)
			: base(customer, balance, interestRate) { }

		// Methods

		#region Overrides of Account

		public override decimal InterestAmount(byte months)
		{
			if (Customer is Company)
			{
				if (months > 12)
				{
					return base.InterestAmount(months);
				}
				else
				{
					return base.InterestAmount(months) / 2;
				}
			}
			else // Customer is Individual
			{
				if (months > 6)
				{
					return base.InterestAmount(months);
				}
				else
				{
					return 0;
				}
			}
		}

		#endregion
	}
}
