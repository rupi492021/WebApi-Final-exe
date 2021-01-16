﻿using resturantwebApp.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace resturantwebApp.Controllers
{
    public class CampaignController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try
            {
                Campaign campaigns = new Campaign();
                List<Campaign> campaignsList = campaigns.Read();
                return Ok(campaignsList);
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
        public int Post([FromBody]Campaign campaign)
        {
            return campaign.Insert();
        }

        // PUT api/<controller>/5
        public int Put([FromBody]Campaign campaign)
        {
            
            return campaign.Update_Budget(campaign.Id, campaign.Budget); 
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("api/Campaign/{id}")]
        public int Put(int id)
        {
            Campaign campaign = new Campaign();
            return campaign.DeleteCampain(id);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}