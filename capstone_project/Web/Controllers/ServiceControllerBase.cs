namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using GVSU.BusinessLogic;

    public class ServiceControllerBase<T> : Controller
    {
        protected T Service { get; }

        protected ServiceControllerBase()
        {
            Service = Factory.GetService<T>();
        }
    }
}