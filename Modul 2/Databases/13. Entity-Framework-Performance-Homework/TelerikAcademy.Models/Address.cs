namespace TelerikAcademy.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    public class Address
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            this.Employees = new HashSet<Employee>();
        }

        public int AddressID { get; set; }

        [Required]
        [StringLength(100)]
        public string AddressText { get; set; }

        public int? TownID { get; set; }

        public virtual Town Town { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}