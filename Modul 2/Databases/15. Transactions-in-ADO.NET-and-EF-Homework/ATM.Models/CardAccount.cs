namespace ATM.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Validation;

    public class CardAccount
    {
        public CardAccount()
        {
            this.TransactionHistories = new HashSet<TransactionHistory>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "Card Number")]
        [Required]
        [CardNumber]
        public string CardNumber { get; set; }

        [Display(Name = "Card PIN")]
        [Required]
        [CardPin]
        public string CardPin { get; set; }

        [Display(Name = "Balance")]
        public decimal CardCash { get; set; }

        public ICollection<TransactionHistory> TransactionHistories { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id}, " +
                   $"CardNumber: {this.CardNumber}, " +
                   $"CardPIN: {this.CardPin}, " +
                   $"CardCash: {this.CardCash}";
        }
    }
}