namespace ATM.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TransactionHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public decimal TransactionAmount { get; set; }

        public int CardAccountId { get; set; }

        public virtual CardAccount CardAccount { get; set; }
    }
}