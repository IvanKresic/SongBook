using MP3HRCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MP3HRCloud.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new Mp3Context();
            var files = db.Mp3Files.Count();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}