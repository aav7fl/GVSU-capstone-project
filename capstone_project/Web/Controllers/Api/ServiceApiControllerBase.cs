using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using GVSU.BusinessLogic;

namespace Web.Api.Controllers
{
    public class ServiceApiControllerBase<T> : ApiController
    {
        protected T Service { get; }

        protected ServiceApiControllerBase()
        {
            Service = Factory.GetService<T>();
        }
    }
}