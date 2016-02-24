using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CharityController : Controller
    {
        // GET: Charity
        public ActionResult Index()
        {
            return View();
        }

        // GET: Charity Edit
        public ActionResult Edit()
        {
            return View();
        }
    }
}