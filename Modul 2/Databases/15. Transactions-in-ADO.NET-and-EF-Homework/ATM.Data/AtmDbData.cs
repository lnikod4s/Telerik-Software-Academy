namespace ATM.Data
{
    using System;
    using System.Linq;
    using Models.Mapping;
    using Models.Validation;

    public class AtmDbData
    {
        private readonly AtmDbContext atmDbContext;
        private readonly Validator validator;

        public AtmDbData()
        {
            this.atmDbContext = new AtmDbContext();
            this.validator = new Validator();
        }

        public void WithdrawMoney(TransactionRequest transactionRequest)
        {
            using (var transaction = new AtmDbContext().Database.BeginTransaction())
            {
                try
                {
                    if (!this.validator.IsValidCardNumber(transactionRequest.CardNumber))
                    {
                        throw new ArgumentException("Invalid card number. Current transaction is aborted!");
                    }

                    if (!this.validator.IsValidCardPin(transactionRequest.CardPin))
                    {
                        throw new ArgumentException("Invalid Card PIN Code. Current transaction is aborted!");
                    }

                    var cardAccount = this.atmDbContext.CardAccounts
                        .FirstOrDefault(ca => ca.CardNumber == transactionRequest.CardNumber &&
                                              ca.CardPin == transactionRequest.CardPin);
                    if (cardAccount == null)
                    {
                        throw new ArgumentException(
                            "There is no Card account with the given Card number. Current transaction is aborted!");
                    }

                    if (!this.validator.IsPinCodeMatches(transactionRequest.CardPin, cardAccount.CardPin))
                    {
                        throw new ArgumentException(
                            "Chosen Card PIN Code does not matches the actual PIN Code of the card account. Current transaction is aborted!");
                    }

                    if (
                        !this.validator.IsPermittedWithdrawalAmount(transactionRequest.RequestedAmount,
                            cardAccount.CardCash))
                    {
                        throw new ArgumentException(
                            "Invalid withdrawal money amount to retrieve. Current transaction is aborted!");
                    }

                    cardAccount.CardCash -= transactionRequest.RequestedAmount;

                    transaction.Commit();
                    this.atmDbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("\t" + ex.Message);
                }
            }
        }
    }
}