using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Please enter category name")]
        [MinLength(5,ErrorMessage ="Provide minimum 5 characters")]
        [MaxLength(50,ErrorMessage ="Provide a maximum of 50 characters")]
        public string CategoryName { get; set; }
        [MaxLength(500, ErrorMessage = "Provide a maximum of 500 characters")]
        public string CategoryDescription { get; set; }
    }
}
