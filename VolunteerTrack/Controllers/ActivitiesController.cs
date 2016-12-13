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
        public List<VolunteerActivity> Get()
        {
            var currentUser = User.Identity.Name;
            //need this for list of acti for speci users
            //
           return repo.GetAllActivitiesForCurrentUser(currentUser);
            
        }

        // GET api/<controller>
        public VolunteerActivity Get(int id)
        {
            return repo.GetActivityById(id);
        }

        // POST api/<controller>
        public void Post(VolunteerActivity activity)
        {
            var currentUser = User.Identity.Name;
            int i = 0;
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