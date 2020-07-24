namespace Bakkal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GSepet")]
    public partial class GSepet
    {
        public int GSepetId { get; set; }

        public int GSiparisId { get; set; }

        public int GMusteriId { get; set; }

        public int GBakkal_Id { get; set; }

        [Required]
        public string GUrunAdi { get; set; }

        public double GUrunFiyati { get; set; }
    }
}
