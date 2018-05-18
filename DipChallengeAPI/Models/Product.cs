namespace DipChallengeAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Ordered = new HashSet<Ordered>();
        }

        [Key]
        [StringLength(15)]
        public string ProdID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public int CatID { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordered> Ordered { get; set; }
    }
}
