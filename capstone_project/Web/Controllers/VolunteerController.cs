namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using GVSU.Contracts;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Owin;

    [Authorize]
    public class VolunteerController : ServiceControllerBase<IVolunteerService>
    {
        // GET: Volunteer
        [Route("Volunteer/{id?}")]
        public ActionResult Index(int? id)
        {
            Web.Models.VolunteerViewModel vm = new Web.Models.VolunteerViewModel();
            if (id == null)
            {
                int current = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>()
                    .FindById(User.Identity.GetUserId()).Volunteer.Id;

                vm.Volunteer = this.Service.GetVolunteerById(current);
                return View(vm);
            }
            else
            {
                vm.Volunteer = this.Service.GetVolunteerById(id.Value);
                return View(vm);
            }
        }

        // GET: Volunteer Edit
        public ActionResult Edit()
        {
            return View();
        }

        /**
        [HttpPost]
        public ActionResult Edit(Web.Models.VolunteerViewModel vm) {

            this.Service.UpdateVolunteer()
        } 
        **/
    }
}