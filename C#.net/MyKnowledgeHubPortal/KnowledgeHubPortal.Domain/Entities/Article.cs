using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain.Entities
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [Url]
        public string Url { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string SubmittedBy { get; set; }
        public bool IsApproved { get; set; }
        public DateTime SubmittedOn { get; set; }
    }
}
