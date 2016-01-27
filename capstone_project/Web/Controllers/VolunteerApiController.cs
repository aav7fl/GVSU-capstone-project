using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers
{
    public class VolunteerApiController : ApiController
    {
        // GET: api/VolunteerApi
        public IEnumerable<string> Get()
        {
            return new string[] { "volunteer1", "volunteer2" };
        }

        // GET: api/VolunteerApi/5
        public string Get(int id)
        {
            return "volunteer" + id;
        }

        // POST: api/VolunteerApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/VolunteerApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/VolunteerApi/5
        public void Delete(int id)
        {
        }
    }
}
