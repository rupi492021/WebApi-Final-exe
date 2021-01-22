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
        public HttpResponseMessage Post([FromBody]Attribute_In_cust attribute_In_Cust)
        {
            try
            {
                attribute_In_Cust.Insert();
                return Request.CreateResponse(HttpStatusCode.OK, 200);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }

        }

        public HttpResponseMessage Put([FromBody]Attribute_In_cust attribute_In_Cust)
        {
            try
            {
                attribute_In_Cust.Update();
                return Request.CreateResponse(HttpStatusCode.OK, 200);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }

        }

        // DELETE api/<controller>/5
            public void Delete(int id)
        {
        }
    }
}