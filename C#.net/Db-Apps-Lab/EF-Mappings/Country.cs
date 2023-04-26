namespace EF_Mappings
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Country
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Country()
        {
            Monasteries = new HashSet<Monastery>();
            Rivers = new HashSet<River>();
        }

        [Key]
        [StringLength(2)]
        public string CountryCode { get; set; }

        [Required]
        [StringLength(3)]
        public string IsoCode { get; set; }

        [Required]
        [StringLength(45)]
        public string CountryName { get; set; }

        [StringLength(3)]
        public string CurrencyCode { get; set; }

        [Required]
        [StringLength(2)]
        public string ContinentCode { get; set; }

        public int Population { get; set; }

        public int AreaInSqKm { get; set; }

        [Required]
        [StringLength(100)]
        public string Capital { get; set; }

        public virtual Continent Continent { get; set; }

        public virtual Currency Currency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Monastery> Monasteries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<River> Rivers { get; set; }
    }
}
