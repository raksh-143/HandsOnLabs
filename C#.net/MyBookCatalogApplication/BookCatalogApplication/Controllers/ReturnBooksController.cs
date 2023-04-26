using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCatalogApplication.Controllers
{
    public class ReturnBooksController : Controller
    {
        // GET: ReturnBooks
        public ActionResult Index()
        {
            return View();
        }
    }
}