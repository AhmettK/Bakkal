namespace Bakkal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Urunler")]
    public partial class Urunler
    {
        [Key]
        public int UrunId { get; set; }

        [Required]
        public string UrunKategorisi { get; set; }

        [Required]
        public string UrunAdi { get; set; }

        public double UrunFiyati { get; set; }

        public int Bakkal_Id { get; set; }

        public virtual Bakkallar Bakkallar { get; set; }
    }
}
