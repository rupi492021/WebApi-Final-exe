using resturantwebApp.Models.DAL;
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

      

        // POST api/<controller>
   
        public IHttpActionResult Post([FromBody]Campaign campaign)
        {
            try
            {
                int count = campaign.Insert();
                return Created(new Uri(Request.RequestUri.AbsoluteUri + campaign.Id), count);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<controller>/5
        //Update budget and balance
        public IHttpActionResult Put([FromBody]Campaign campaign)
        {
            try
            {
                
                int count = campaign.Update_Budget(campaign.Id, campaign.Difference);
                return Created(new Uri(Request.RequestUri.AbsoluteUri + campaign.Id), count);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);


            }

        }

        // PUT api/<controller>/5
        //Delete campaign, reset- balance,click,views
        [HttpPut]
        [Route("api/Campaign/{id}")]
        public IHttpActionResult Put(int id)
        {
            try
            {
                Campaign campaign = new Campaign();
                int count = campaign.DeleteCampain(id);
                return Created(new Uri(Request.RequestUri.AbsoluteUri + campaign.Id), count);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
                
            }
            
        }

        //click campaign
        [HttpPut]
        [Route("api/Campaign/Click/{id}")]
        public IHttpActionResult CampaignClick(int id)
        {
            try
            {
                Campaign campaign = new Campaign();
                int res = campaign.CampaignClick(id);
                return Created(new Uri(Request.RequestUri.AbsoluteUri + campaign.Id), res);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }


        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}