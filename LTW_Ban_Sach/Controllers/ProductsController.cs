using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_Ban_Sach.Models;

namespace LTW_Ban_Sach.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        private DBContext db = new DBContext();
        public ActionResult Index()
        {
            List<Books> books = db.Books.ToList();

            return View(books);
        }
    }
}