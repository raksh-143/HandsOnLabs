
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnowledgeHubPortal.WebUI.Models
{
    public class ArticlesForBrowseViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string url { get; set; }
        [Display(Name ="Category Name")]
        public string CategoryName { get; set; }
        public string Submiter { get; set; }
        [Display(Name ="SUbmitted")]
        public string WhenSubmited { get; set; }

    }
}