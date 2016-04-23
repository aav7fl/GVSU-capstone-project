using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GVSU.Contracts;

namespace Web.Api.Controllers
{
    public class SearchController : ServiceApiControllerBase<ICharityService>
    {
        //NOTE: was not able to make request from view
        //[HttpGet]
        [Route("api/charity/search")]
        public IEnumerable<ICharity> Get(string searchTerm)
        {
            var test = this.Service.GetAllCharities().Where(m => m.Name.Contains(searchTerm)).ToList();

            return this.Service.GetAllCharities().Where(m => m.Name.Contains(searchTerm)).ToList();
        }
    }
}
