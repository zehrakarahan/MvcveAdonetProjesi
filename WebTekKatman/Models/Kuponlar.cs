namespace WebTekKatman.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kuponlar")]
    public partial class Kuponlar
    {
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string Kodu { get; set; }

        public int Oran { get; set; }

        [Column(TypeName = "date")]
        public DateTime BitisTarihi { get; set; }
    }
}
