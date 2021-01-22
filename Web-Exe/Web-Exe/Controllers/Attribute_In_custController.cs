using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace cuisin.Models
{
    public class Attribute_In_custController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get(int id)
        {
            try
            {
                Attribute_In_cust attribute_In_cust = new Attribute_In_cust();
                List<Attribute_In_cust> Att_Cust_List = attribute_In_cust.Read(id);
                return Ok(Att_Cust_List);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e);
            }
        }

     

        // POST api/<controller>
        public void Post([FromBody]Attribute_In_cust attribute_In_Cust)
        {
             attribute_In_Cust.Insert();
        }

        // PUT api/<controller>/5
        public void Put([FromBody]Attribute_In_cust attribute_In_Cust)
        {
            attribute_In_Cust.Update();

        }

        // DELETE api/<controller>/5
        public void Delete([FromBody]int id)
        {
            Attribute_In_cust attribute_In_cust = new Attribute_In_cust();
            attribute_In_cust.Delete(id);
        }
    }
}