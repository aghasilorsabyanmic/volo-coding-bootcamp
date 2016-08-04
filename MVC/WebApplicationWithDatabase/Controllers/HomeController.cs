using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationWithDatabase.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Action = "Index";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Action = "About";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Action = "Contact";
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}