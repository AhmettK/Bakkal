namespace Bakkal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yeni")]
    public partial class Yeni
    {
        [Key]
        public int SepetId { get; set; }

        public int SiparisId { get; set; }

        public int MusteriId { get; set; }

        public int Bakkal_Id { get; set; }

        [Required]
        public string UrunAdi { get; set; }

        public double UrunFiyati { get; set; }
    }
}
