using cuisin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace cuisin.Controllers
{
    public class CustomerController : ApiController
    {
        // GET api/<controller>


        // GET api/<controller>/5
        public List<Customer> Get(string mail, string password)
        {
            Customer Customer = new Customer();
            List<Customer> Customer_Islogged = Customer.CheckIfLog(mail, password);
            return Customer_Islogged;
        }

        // POST api/<controller>
        public int Post([FromBody]Customer customer)
        {
            return customer.Insert();
            // return flight;
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