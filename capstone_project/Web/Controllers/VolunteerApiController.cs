namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Description;
    using GVSU.Contracts;

    public class VolunteerController : ServiceApiControllerBase<IVolunteerService>
    {
        [ResponseType(typeof(IEnumerable<IVolunteer>))]
        public IHttpActionResult Get()
        {
            return Ok(this.Service.GetAllVolunteers());
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(this.Service.GetVolunteerById(id));
        }

        public IHttpActionResult Post([FromBody]IVolunteer volunteer)
        {
            return Ok(this.Service.CreateVolunteer(volunteer));
        }
    }
}
