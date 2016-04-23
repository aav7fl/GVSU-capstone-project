using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GVSU.Contracts;
using Owin;
using Web.Models;

namespace Web.Controllers
{
    public class CharityController : ServiceControllerBase<ICharityService>
    {

        // GET: Charity
        [Route("Charity/{id?}")]
        public ActionResult Index(int? id)
        {
            CharityViewModel vm = new CharityViewModel();

            if (id == null)
            {
                vm.Charity = this.Service.GetCharityById(2);
                return View(vm);
            }
            else
            {
                vm.Charity = this.Service.GetCharityById(id.Value);
                return View(vm);
            }
        }

        // GET: Charity Edit
        public ActionResult Edit(int? id)
        {

            CharityViewModel vm = new CharityViewModel();

            if (id == null)
            {
                vm.Charity = this.Service.GetCharityById(3);
                return View(vm);
            }
            else
            {
                vm.Charity = this.Service.GetCharityById(id.Value);
                return View(vm);
            }
        }
    }
}