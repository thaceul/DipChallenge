namespace DipChallengeAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ordered")]
    public partial class Ordered
    {
        [Key]
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime ShipDate { get; set; }

        [Required]
        [StringLength(8)]
        public string CustID { get; set; }

        [Required]
        [StringLength(15)]
        public string ProdID { get; set; }

        [Required]
        [StringLength(17)]
        public string ShipMode { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }

        public virtual Shipping Shipping { get; set; }
    }
}
