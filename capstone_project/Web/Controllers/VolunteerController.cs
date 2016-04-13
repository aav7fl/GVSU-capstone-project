namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using GVSU.Contracts;
    using Owin;
    using Web.Models; 

    public class VolunteerController : ServiceControllerBase<IVolunteerService>
    {
        VolunteerViewModel vm = new VolunteerViewModel();

        // GET: Volunteer
        [Route("Volunteer/{id?}")]
        public ActionResult Index(int? id)
        {
            
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

        // GET: Volunteer Edit
        public ActionResult Edit(int? id)
        {
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