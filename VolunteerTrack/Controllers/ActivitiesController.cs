using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VolunteerTrack.DAL;
using VolunteerTrack.Models;

namespace VolunteerTrack.Controllers
{
    public class ActivitiesController : ApiController
    {
        VolunteerRepository repo = new VolunteerRepository();

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post(VolunteerActivity activity)
        {
            VolunteerActivity _activity = new VolunteerActivity();
            int i = 0;
            //_activity.OrgName = activity.OrgName;
            //_activity.Date = activity.Date;
            //_activity.NumberHours = activity.NumberHours;
            //_activity.Mileage = activity.Mileage;
            //_activity.DollarsContributed = activity.DollarsContributed;               
            repo.AddActivity(activity);
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