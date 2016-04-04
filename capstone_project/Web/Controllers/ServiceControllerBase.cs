namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using GVSU.BusinessLogic;
    using GVSU.Contracts;
    using Microsoft.AspNet.Identity.Owin;

    public class ServiceControllerBase<T> : Controller
    {
        protected T Service {
            get
            {
                return HttpContext.GetOwinContext().Get<T>();
            }
        }

        protected ServiceControllerBase()
        {
            //Service = Factory.GetService<T>();
            //Service = HttpContext.GetOwinContext().Get<T>();
        }
    }
}