namespace Cars.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class City
    {
        private ICollection<Dealer> dealers;

        public City()
        {
            this.dealers = new HashSet<Dealer>();
        }

        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(10)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Dealer> Dealers
        {
            get
            {
                return this.dealers;
            }
            set
            {
                this.dealers = value;
            }
        }
    }
}