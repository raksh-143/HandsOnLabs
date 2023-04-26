using KnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace KnowledgeHubPortal.WebUI.Models
{
    public class ArticlesForReviewViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string url { get; set; }
        public string Category { get; set; }
        public string Submiter { get; set; }
        [Display(Name = "Submitted")]
        public string WhenSubmited { get; set; }
    }
}