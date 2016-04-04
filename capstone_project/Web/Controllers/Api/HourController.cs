namespace Web.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Description;
    using GVSU.Contracts;

    public class HourController : ServiceApiControllerBase<IVolunteerService>
    {
        public IHttpActionResult Get(int id)
        {
            try
            {
                IEnumerable<IHour> hours = this.Service.GetHoursByVolunteer(id);

                if (hours.Count() == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(hours);
                }

            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Post([FromBody]IHour hour)
        {
            try
            {
                // TO-DO: replace with Created 201 response
                return Ok(this.Service.CreateHour(hour));
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Put(int id, [FromBody]IHour hour)
        {
            try
            {
                this.Service.UpdateHour(hour);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest();
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                this.Service.DeleteHourById(id);
                return StatusCode(HttpStatusCode.NoContent);

                // Return Not Found status if id is not found
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }
    }
}
