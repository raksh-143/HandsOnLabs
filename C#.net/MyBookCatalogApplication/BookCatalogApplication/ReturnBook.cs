namespace BookCatalogApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReturnBook
    {
        [Key]
        public int ReturnId { get; set; }

        public int? IssueId { get; set; }

        public DateTime? DateOfReturn { get; set; }

        public virtual IssueBook IssueBook { get; set; }
    }
}
