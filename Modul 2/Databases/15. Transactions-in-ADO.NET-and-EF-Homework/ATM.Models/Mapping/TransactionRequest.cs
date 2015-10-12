namespace ATM.Models.Mapping
{
    public class TransactionRequest
    {
        public string CardNumber { get; set; }

        public string CardPin { get; set; }

        public decimal RequestedAmount { get; set; }
    }
}