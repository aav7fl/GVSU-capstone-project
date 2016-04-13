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
        CharityViewModel vm = new CharityViewModel(); 

        // GET: Charity
        [Route("Charity/{id?}")]
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                vm.Charity = this.Service.GetCharityById(3);
                return View(vm);
            }
            else
            {
                vm.Charity = this.Service.GetCharityById(id.Value);
                return View();
            }
        }

        // GET: Charity Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                vm.Charity = this.Service.GetCharityById(3);
                return View(vm);
            }
            else
            {
                vm.Charity = this.Service.GetCharityById(id.Value);
                return View();
            }
        }
    }
}