namespace Bakkal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bakkallar")]
    public partial class Bakkallar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bakkallar()
        {
            Siparis = new HashSet<Siparis>();
            Urunler = new HashSet<Urunler>();
        }

        [Key]
        public int Bakkal_Id { get; set; }

        [Required]
        public string BakkalAdi { get; set; }

        [Required]
        public string BakkalSifresi { get; set; }

        public int SiparisUcreti { get; set; }

        [Required]
        public string BakkalMail { get; set; }

        public long Vergi_kimlikno { get; set; }

        public long Esnafodasi_no { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Siparis> Siparis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Urunler> Urunler { get; set; }
    }
}
