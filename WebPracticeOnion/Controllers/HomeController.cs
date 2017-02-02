using Domain.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;

namespace WebPracticeOnion.Controllers
{
    public class HomeController : Controller
    {
        IBookRepository repo;
        IOrder order;

        public HomeController(IBookRepository r, IOrder o)
        {
            repo = r;
            order = o;
        }

        public ActionResult Index()
        {
            var books = repo.GetBookList();
            return View(books);
        }

        public ActionResult Buy(int id)
        {
            Book book = repo.GetBook(id);
            order.MakeOrder(book);
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            repo.Dispose();
            base.Dispose(disposing);
        }
    }
}