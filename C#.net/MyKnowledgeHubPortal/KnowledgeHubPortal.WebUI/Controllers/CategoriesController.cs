using KnowledgeHubPortal.Data;
using KnowledgeHubPortal.Domain;
using KnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeHubPortal.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoriesController : Controller
    {
        private ICategoriesManager mgr = null;
        public CategoriesController(ICategoriesManager mgr)
        {
            this.mgr = mgr;
        }
        // GET: Categories
        public ActionResult Manage()
        {
            //ICategoriesManager mgr = new CategoriesManager(new CategoriesRepository());
            var categoryList = mgr.ListCategories();
            return View(categoryList);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //ICategoriesManager mgr = new CategoriesManager(new CategoriesRepository());
            var catToEdit = mgr.GetCategoryById(id);
            return View(catToEdit);
        }
        
        [HttpPost]
        public ActionResult Edit(Category categoryToEdit)
        {
            //server side validation
            if (!ModelState.IsValid)
            {
                return View();
            }
            //ICategoriesManager mgr = new CategoriesManager(new CategoriesRepository());
            mgr.EditCategory(categoryToEdit);
            TempData["SuccessMessage"] = $"Category Edited Successfully!";
            return RedirectToAction("Manage");
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            //ICategoriesManager mgr = new CategoriesManager(new CategoriesRepository());
            var catToDel = mgr.GetCategoryById(id);
            return View(catToDel);
        }
        
        public ActionResult ConfirmDelete(int id)
        {
            //ICategoriesManager mgr = new CategoriesManager(new CategoriesRepository());
            mgr.DeleteCategory(id);
            TempData["SuccessMessage"] = $"Category Deleted Successfully!";
            return RedirectToAction("Manage");
        }
        
        [HttpGet]
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            //server side validation
            if(!ModelState.IsValid)
            {
                return View();
            }
            //ICategoriesManager mgr = new CategoriesManager(new CategoriesRepository());
            mgr.CreateCategory(category);
            TempData["SuccessMessage"] = $"Category Created Successfully!";
            return RedirectToAction("Manage");
        }
    }
}