using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeCiBlog.Data.Contracts;
using DeCiBlog.Web.Model;

namespace DeCiBlog.Web.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected ControllerBase()
        {
            ViewBag.Settings = new Settings();
        }

        public Settings Settings { get; set; }

        protected IDeCiBlogUow Uow { get; set; }
    }
}