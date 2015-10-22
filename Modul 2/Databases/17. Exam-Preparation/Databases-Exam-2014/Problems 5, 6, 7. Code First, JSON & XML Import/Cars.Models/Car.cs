namespace Cars.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Car
    {
        [Key]
        public int Id { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [MaxLength(20)]
        [Required]
        public string Model { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public short Year { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("Dealer")]
        public int DealerId { get; set; }

        public virtual Dealer Dealer { get; set; }
    }
}