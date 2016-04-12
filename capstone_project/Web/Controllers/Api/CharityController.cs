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

    public class CharityController : ServiceApiControllerBase<ICharityService>
    {
        [ResponseType(typeof(IEnumerable<ICharity>))]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(this.Service.GetAllCharities());
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        //NOTE: was not able to make request from view
        //[HttpGet]
        [Route("api/charity/search")]
        public IEnumerable<ICharity> GetCharities(string searchTerm)
        {
            var test = this.Service.GetAllCharities().Where(m => m.Name.Contains(searchTerm)).ToList();
        
            return this.Service.GetAllCharities().Where(m => m.Name.Contains(searchTerm)).ToList(); 
        }
        public IHttpActionResult Get(int id)
        {
            try
            {
                var charity = this.Service.GetCharityById(id);

                if (charity == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(charity);
                }

            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Post([FromBody]ICharity charity)
        {
            try
            {
                // TO-DO: replace with Created 201 response
                return Ok(this.Service.CreateCharity(charity));
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Put(int id, [FromBody]ICharity charity)
        {
            try
            {
                this.Service.UpdateCharity(charity);
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
                this.Service.DeleteCharityById(id);
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