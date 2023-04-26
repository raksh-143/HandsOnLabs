using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EF_Mappings
{
    public partial class Geography : DbContext
    {
        public Geography()
            : base("name=Geography")
        {
        }

        public virtual DbSet<Continent> Continents { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Countries2> Countries2 { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Monastery> Monasteries { get; set; }
        public virtual DbSet<River> Rivers { get; set; }
        public virtual DbSet<Rivers2> Rivers2 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Continent>()
                .Property(e => e.ContinentCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Continent>()
                .HasMany(e => e.Countries)
                .WithRequired(e => e.Continent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.CountryCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.IsoCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.CountryName)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.CurrencyCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.ContinentCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.Capital)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Rivers)
                .WithMany(e => e.Countries)
                .Map(m => m.ToTable("CountriesRivers").MapLeftKey("CountryCode").MapRightKey("RiverId"));

            modelBuilder.Entity<Currency>()
                .Property(e => e.CurrencyCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Monastery>()
                .Property(e => e.CountryCode)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
