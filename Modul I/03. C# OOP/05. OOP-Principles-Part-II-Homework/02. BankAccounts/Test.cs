
/*Problem 2. Bank accounts
A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts. Customers could be individuals or companies.
All accounts have customer, balance and interest rate (monthly based).
Deposit accounts are allowed to deposit and with draw money.
Loan and mortgage accounts can only deposit money.
All accounts can calculate their interest amount for a given period (in months). In the common case its is calculated as follows: number_of_months * interest_rate.
Loan accounts have no interest for the first 3 months if are held by individuals and for the first 2 months if are held by a company.
Deposit accounts have no interest if their balance is positive and less than 1000.
Mortgage accounts have ½ interest for the first 12 months for companies and no interest for the first 6 months for individuals.
Your task is to write a program to model the bank system by classes and interfaces.
You should identify the classes, interfaces, base classes and abstract actions and implement the calculation of the interest functionality through overridden methods.
*/

using System;
using _02.BankAccounts.Accounts;
using _02.BankAccounts.Customers;

namespace _02.BankAccounts
{
	class Test
	{
		static void Main()
		{
			// Initialize accounts set
			var myAccountsSet = new Account[]
			                    {
									new Deposit(new Individual("Hristo Mutafchiev"), 500, 0.034M),
									new Loan(new Company("Microsoft Corporation"), 700, 0.023M),
									new Mortgage(new Individual("Stoyanka Mutafova"), 300, 0.45M)
			                    };

			// Testing deposit
			myAccountsSet[0].Deposit(100);
			myAccountsSet[1].Deposit(200);
			myAccountsSet[2].Deposit(300);

			// Testing withdraw
			((Deposit)myAccountsSet[0]).Withdraw(150);

			// Print result
			Console.WriteLine("***** Fun with bank accounts *****\n");
			foreach (var account in myAccountsSet)
			{
				Console.WriteLine(account);
			}
		}
	}
}
