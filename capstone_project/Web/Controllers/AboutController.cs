using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult About()
        {
            ViewBag.Message = "Our vision for Charma";

            return View();
        }
    }
}