namespace Bakkal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Siparis
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Siparis()
        {
            Sepet = new HashSet<Sepet>();
        }

        public int SiparisId { get; set; }

        public int Bakkal_Id { get; set; }

        public int MusteriId { get; set; }

        [Required]
        public string KullaniciAdi { get; set; }

        [Required]
        public string Adres { get; set; }

        public long Telefon { get; set; }

        [Required]
        public string BakkalAdi { get; set; }

        public DateTime Tarih_Saat { get; set; }

        public int Kod { get; set; }

        public double Para { get; set; }

        public virtual Bakkallar Bakkallar { get; set; }

        public virtual Musteri Musteri { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sepet> Sepet { get; set; }
    }
}
