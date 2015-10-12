namespace ATM.UI
{
    using System;
    using System.Threading;
    using Data;
    using Models.Mapping;

    internal class ConsoleClient
    {
        private static readonly AtmDbData AtmDbData = new AtmDbData();

        private static void Main()
        {
            // Valid transaction
            Console.WriteLine("Begin Transaction...");
            Thread.Sleep(1000);
            var validTransactionRequest = new TransactionRequest
            {
                CardNumber = "123-456-78",
                CardPin = "1234",
                RequestedAmount = 200
            };

            ProcessTransaction(validTransactionRequest);
            Console.WriteLine("End Transaction...\n");
            Thread.Sleep(1000);

            // Invalid card number
            Console.WriteLine("Begin Transaction...");
            Thread.Sleep(1000);
            var invalidCardNumberTransaction = new TransactionRequest
            {
                CardNumber = "111-11-11-111",
                CardPin = "1234",
                RequestedAmount = 200
            };

            ProcessTransaction(invalidCardNumberTransaction);
            Console.WriteLine("End Transaction...\n");
            Thread.Sleep(1000);

            // Invalid card pin
            Console.WriteLine("Begin Transaction...");
            Thread.Sleep(1000);
            var invalidCardPinTransaction = new TransactionRequest
            {
                CardNumber = "111-11-111",
                CardPin = "12345",
                RequestedAmount = 200
            };

            ProcessTransaction(invalidCardPinTransaction);
            Console.WriteLine("End Transaction...\n");
            Thread.Sleep(1000);

            // Invalid money request
            Console.WriteLine("Begin Transaction...");
            Thread.Sleep(1000);
            var invalidMoneyRequestTransaction = new TransactionRequest
            {
                CardNumber = "111-11-111",
                CardPin = "1234",
                RequestedAmount = -200
            };

            ProcessTransaction(invalidMoneyRequestTransaction);
            Console.WriteLine("End Transaction...\n");
            Thread.Sleep(1000);
        }

        private static void ProcessTransaction(TransactionRequest transactionRequest)
        {
            try
            {
                AtmDbData.WithdrawMoney(transactionRequest);
                Console.WriteLine("\tRequested transaction was successful!");
            }
            catch (Exception)
            {
                Console.WriteLine("\tRequested transaction was not successful!");
            }
        }
    }
}