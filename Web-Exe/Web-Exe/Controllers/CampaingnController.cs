using resturantwebApp.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace resturantwebApp.Controllers
{
    public class CampaingnController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try
            {
                Campaingn campaingn = new Campaingn();
                List<Campaingn> campaingnsList = campaingn.Read();
                return Ok(campaingnsList);
            }
            catch ( Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e);
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}