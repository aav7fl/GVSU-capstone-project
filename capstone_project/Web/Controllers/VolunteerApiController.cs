namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using GVSU.Contracts;

    public class VolunteerController : ServiceApiControllerBase<IVolunteerService>
    {
        public IEnumerable<IVolunteer> Get()
        {
            return this.Service.GetAllVolunteers();
        }
    }
}
