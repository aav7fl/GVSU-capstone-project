﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using GVSU.BusinessLogic;
using Microsoft.AspNet.Identity.Owin;

namespace Web.Api.Controllers
{
    public class ServiceApiControllerBase<T> : ApiController
    {
        protected T Service {
            get
            {
                return HttpContext.Current.GetOwinContext().Get<T>();
            }
        }

        protected ServiceApiControllerBase()
        {
            //Service = Factory.GetService<T>();
        }
    }
}