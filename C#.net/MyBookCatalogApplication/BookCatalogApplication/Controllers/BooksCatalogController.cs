using BookCatalogApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCatalogApplication.Controllers
{
    public class BooksCatalogController : Controller
    {
        private MyDbModel db = new MyDbModel();
        // GET: BooksCatalog
        public ActionResult Index()
        {
            var Books = db.Books.ToList();
            return View(Books);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(db.Books.Find(id));
        }
        [HttpPost]
        public ActionResult DeleteBook(int id)
        {
            db.Books.Remove(db.Books.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.Books.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            db.Entry(book).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}