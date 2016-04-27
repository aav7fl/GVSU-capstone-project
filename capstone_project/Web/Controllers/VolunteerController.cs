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
    using Web.Models; 

    [Authorize]
    public class VolunteerController : ServiceControllerBase<IVolunteerService>
    {

        // GET: Volunteer
        [Route("Volunteer/{id?}")]
        public ActionResult Index(int? id)
        {
            VolunteerViewModel vm = new VolunteerViewModel();

            int current = HttpContext.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>()
                    .FindById(User.Identity.GetUserId()).Volunteer.Id;

            if (current > 0)
            {
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
        public ActionResult Edit(int? id)
        {
            VolunteerViewModel vm = new VolunteerViewModel();

            if (id == null)
            {
                vm.Volunteer = this.Service.GetVolunteerById(1);
                return View(vm);
            }
            else
        {
                vm.Volunteer = this.Service.GetVolunteerById(id.Value);
                return View(vm);
            }
        }

        /**
        [HttpPost]
        public ActionResult Edit(Web.Models.VolunteerViewModel vm) {

            this.Service.UpdateVolunteer()
        } 
        **/
    }
}