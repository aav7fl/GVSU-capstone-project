﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Our vision for Charma";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "How to contact us";

            return View();
        }
    }
}