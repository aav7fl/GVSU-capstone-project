namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using GVSU.Contracts;

    public class VolunteerController : ServiceControllerBase<IVolunteerService>
    {
        // GET: Volunteer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Volunteer Edit
        public ActionResult Edit()
        {
            return View();
        }
    }
}