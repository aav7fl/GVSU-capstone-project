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
            try
            {
                return Ok(this.Service.GetAllVolunteers());
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var volunteer = this.Service.GetVolunteerById(id);

                if (volunteer == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(volunteer);
                }

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Post([FromBody]IVolunteer volunteer)
        {
            try
            {
                // TO-DO: replace with Created 201 response
                return Ok(this.Service.CreateVolunteer(volunteer));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Put(int id, [FromBody]IVolunteer volunteer)
        {
            try
            {
                // TO-DO: replace with Created 201 response
                return Ok(this.Service.UpdateVolunteer(volunteer));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
