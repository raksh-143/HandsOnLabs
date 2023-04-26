namespace BookCatalogApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            IssueBooks = new HashSet<IssueBook>();
        }

        public int BookID { get; set; }

        [Required]
        [StringLength(50)]
        public string BookName { get; set; }

        [StringLength(30)]
        public string ISBN { get; set; }

        [StringLength(30)]
        public string Author { get; set; }

        public decimal? Price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IssueBook> IssueBooks { get; set; }
    }
}
