namespace DipChallengeAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Ordered = new HashSet<Ordered>();
        }

        [Key]
        [StringLength(8)]
        public string CustID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string FullName { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Country { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string City { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string State { get; set; }

        public int PostCode { get; set; }

        public int SegID { get; set; }

        [Required]
        [StringLength(7)]
        public string Region { get; set; }

        public virtual Region Region1 { get; set; }

        public virtual Segment Segment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordered> Ordered { get; set; }
    }
}
