﻿using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Net;
using System.Linq;
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
            //We need this for list of activities for specific users.
            var currentUserActivities = repo.GetAllActivitiesForCurrentUser(currentUser);
            return currentUserActivities;       
        }
        
        // GET api/<controller>
        public VolunteerActivity Get(int id)
        {
            return repo.GetActivityById(id);
        }

        // POST api/<controller>
        public void Post(VolunteerActivity activity)
        {
            var currentUser = repo.GetUserByUserName(User.Identity.Name);
            activity.VolunteerUser = currentUser;
            repo.AddActivity(activity);
        }

        // PUT api/<controller>
        public void Put(int Id, [FromBody]VolunteerActivity value)
        {
            var foundActivityForUpdate = repo.GetActivityById(Id);
            repo.UpdateActivity(value);
           
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void Delete(int id)
        {
           
            if(id != 0) {
                repo.RemoveActivity(id);
            }
        }
        
    }
}