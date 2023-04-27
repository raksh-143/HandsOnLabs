using Humanizer;
using KnowledgeHubPortal.Data;
using KnowledgeHubPortal.Domain;
using KnowledgeHubPortal.Domain.Data;
using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeHubPortal.WebUI.Controllers
{
    public class ArticlesController : Controller
    {
        //private IArticlesRepository arepo = null;
        private IArticlesManager amgr = null;
        //private ICategoriesRepository crepo = null;
        private ICategoriesManager cmgr = null;
        //public ArticlesController()
        //{
        //    arepo = new ArticlesRepository();
        //    crepo = new CategoriesRepository();
        //    amgr = new ArticlesManager(arepo);
        //    cmgr = new CategoriesManager(crepo);
        //}
        public ArticlesController(IArticlesManager amgr,ICategoriesManager cmgr)
        {
            this.amgr = amgr;
            this.cmgr = cmgr;
        }

        // GET: Article
        public ActionResult Index(string searchTerm=null)
        {
            var articlesForBrowse = from a in amgr.GetArticlesForBrowse()
                                    select new ArticlesForBrowseViewModel
                                    {
                                        Title = a.Title,
                                        CategoryName = a.Category.CategoryName,
                                        Description = a.Description,
                                        Submiter = a.SubmittedBy,
                                        url = a.Url,
                                        WhenSubmited = a.SubmittedOn.Humanize(false)
                                    };
            if(searchTerm != null)
            {
                var filteredArticlesForBrowse = from a in articlesForBrowse
                                                where a.Title.ToLower().Contains(searchTerm.ToLower()) ||
                                                a.Description.ToLower().Contains(searchTerm.ToLower()) ||
                                                a.url.ToLower().Contains(searchTerm.ToLower())||
                                                a.CategoryName.ToLower().Contains(searchTerm.ToLower())
                                                select a;
                return View(filteredArticlesForBrowse);
            }
            return View(articlesForBrowse);
        }
        [Authorize(Roles = "admin")]
        public ActionResult ReviewArticles()
        {
            var articlesForReview = from a in amgr.GetArticlesForReview()
                                    select new ArticlesForReviewViewModel
                                    {
                                        Id = a.Id,
                                        Title = a.Title,
                                        url = a.Url,
                                        Category = a.Category.CategoryName,
                                        WhenSubmited = a.SubmittedOn.Humanize(false),
                                        Submiter = a.SubmittedBy
                                    };
            return View(articlesForReview);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Submit()
        {
            var category = from c in cmgr.ListCategories()
                           select new SelectListItem 
                           { Text = c.CategoryName, 
                             Value = c.CategoryId.ToString() };
            ViewBag.CategoryId = category;
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Submit(ArticleSubmitViewModel article) {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var myArticle = new Article
            {
                Title = article.Title,
                CategoryID = article.CategoryId,
                Description = article.Description,
                Url = article.url,
                IsApproved=false,
                SubmittedOn=DateTime.Now,
            };
            if (User.Identity.IsAuthenticated)
            {
                myArticle.SubmittedBy = User.Identity.Name;
            }
            else
            {
                myArticle.SubmittedBy = "Unknown";
            }
            amgr.SubmitArticle(myArticle);
            //TempData["SuccessMessage"] = "Article submitted successfully!";
            //return RedirectToAction("Index");
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "admin")]
        public ActionResult Approve(List<int> articleIds) {
            amgr.ApproveArticles(articleIds);
            TempData["Message"] = $"{articleIds.Count} Articles approved successfully!";
            return RedirectToAction("ReviewArticles");
        }
        [Authorize(Roles = "admin")]
        public ActionResult Reject(List<int> articleIds)
        {
            amgr.DeleteArticles(articleIds);
            TempData["Message"] = $"{articleIds.Count} Articles rejected successfully!";
            return RedirectToAction("ReviewArticles");
        }
    }
}