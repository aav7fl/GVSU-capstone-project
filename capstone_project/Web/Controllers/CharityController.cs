using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GVSU.Contracts;

namespace Web.Controllers
{
    [Authorize]
    public class CharityController : ServiceControllerBase<ICharityService>
    {
        // GET: Charity
        [Route("Charity/{id}")]
        public ActionResult Index(int id)
        {
            Web.Models.CharityViewModel cm = new Web.Models.CharityViewModel();

            cm.Charity = this.Service.GetCharityById(id);

            if (cm.Charity != null) {
                return View(cm);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // GET: Charity Edit
        public ActionResult Edit()
        {
            return View();
        }
    }
}