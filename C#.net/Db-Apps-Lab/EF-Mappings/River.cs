namespace EF_Mappings
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class River
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public River()
        {
            Countries = new HashSet<Country>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string RiverName { get; set; }

        public int Length { get; set; }

        public int? DrainageArea { get; set; }

        public int? AverageDischarge { get; set; }

        [Required]
        [StringLength(50)]
        public string Outflow { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Country> Countries { get; set; }
    }
}
