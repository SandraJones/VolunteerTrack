﻿using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
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
        public void Delete(VolunteerActivity activity, int ActivityId)
        {
            var foundActivityforRemoval = repo.GetActivityById(ActivityId);
            repo.RemoveActivity(foundActivityforRemoval);
        }
        //this code below is what I sstarted with
        //public void RemoveActivityByActivityId(int Id)
        //{
        //    var foundActivityforRemoval = repo.GetActivityById(Id);
        //    repo.RemoveActivity(foundActivityforRemoval);
        //}
    }
}