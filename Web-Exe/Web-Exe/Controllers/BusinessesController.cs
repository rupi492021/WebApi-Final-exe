using cuisin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace cuisin.Controllers
{
    public class BusinessesController : ApiController
    {
        // GET api/<controller>

        public List<Businesses> Get()
        {
            Businesses businesses = new Businesses();
            List<Businesses> bList = businesses.Read();
            return bList;
        }

        [HttpGet]
        [Route("api/Businesses/{category}")]
        public List<Businesses> Get(string category)
        {
            Businesses businesses = new Businesses();
            List<Businesses> bList = businesses.Read(category);
            return bList;
        }


        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        //public int Post([FromBody]Businesses businesses)
        //{
           
        //    //return businesses.Insert();
        //}
     


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
