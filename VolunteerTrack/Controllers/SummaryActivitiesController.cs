using System;
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
    public class SummaryActivitiesController : ApiController
    {
        VolunteerRepository repo = new VolunteerRepository();

        // GET api/<controller>/
        public CalculationsViewModel Get(string UserName)
        {
            var currentUser = User.Identity.Name;
            repo.GetAllActivitiesForCurrentUser(currentUser);
            var calcVM = new CalculationsViewModel();
            calcVM.totalHours = repo.calculateYTDNumberHours(UserName);
            calcVM.totalMileage = repo.calculateYTDMileage(UserName);
            calcVM.totalDollars = repo.calculateYTDDollarsContributed(UserName);
            return calcVM;   
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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