
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnowledgeHubPortal.WebUI.Models
{
    public class ArticleViewModel
    {
        [Required]
        [MinLength(6)]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        [Url]
        public string url { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Submiter { get; set; }

    }
}