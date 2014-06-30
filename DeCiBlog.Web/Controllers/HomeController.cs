using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeCiBlog.Data.Contracts;
using DeCiBlog.Model;
using DeCiBlog.Web.Model;

namespace DeCiBlog.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : ControllerBase
    {
        public HomeController(IDeCiBlogUow uow)
        {
            Uow = uow;
        }

        public ActionResult Index()
        {
            IEnumerable<BlogEntry> blogEntries = Uow.BlogEntries.GetBlogEntriesIncludingComments().AsEnumerable();
            return View(blogEntries);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            BlogEntry blogEntry = Uow.BlogEntries.GetById(id);

            return View(blogEntry);
        }

    }
}
