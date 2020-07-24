namespace Bakkal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OSepet")]
    public partial class OSepet
    {
        public int OSepetId { get; set; }

        public int OSiparisId { get; set; }

        public int OMusteriId { get; set; }

        public int OBakkal_Id { get; set; }

        [Required]
        public string OUrunAdi { get; set; }

        public double OUrunFiyati { get; set; }
    }
}
