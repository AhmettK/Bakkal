namespace Bakkal.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model2")
        {
        }

        public virtual DbSet<Bakkallar> Bakkallar { get; set; }
        public virtual DbSet<GSepet> GSepet { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<OSepet> OSepet { get; set; }
        public virtual DbSet<Sepet> Sepet { get; set; }
        public virtual DbSet<Siparis> Siparis { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Urunler> Urunler { get; set; }
        public virtual DbSet<Yeni> Yeni { get; set; }
        public virtual DbSet<Login> Login { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bakkallar>()
                .HasMany(e => e.Siparis)
                .WithRequired(e => e.Bakkallar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bakkallar>()
                .HasMany(e => e.Urunler)
                .WithRequired(e => e.Bakkallar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Musteri>()
                .HasMany(e => e.Siparis)
                .WithRequired(e => e.Musteri)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Siparis>()
                .HasMany(e => e.Sepet)
                .WithRequired(e => e.Siparis)
                .WillCascadeOnDelete(false);
        }
    }
}
