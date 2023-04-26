using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCatalogApplication.Controllers
{
    public class IssueBooksController : Controller
    {
        private MyDbModel db = new MyDbModel();
        // GET: IssueBooks
        public ActionResult Index()
        {
            return View(db.IssueBooks.ToList());
        }
        [HttpGet]
        public ActionResult Edit(int id) {
            return View(db.IssueBooks.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            db.Entry(book).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(db.IssueBooks.Find(id));
        }
        [HttpPost]
        public ActionResult DeleteIssueBook(int id)
        {
            db.IssueBooks.Remove(db.IssueBooks.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}