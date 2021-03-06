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
    public class SummaryActivitiesController : ApiController
    {
        VolunteerRepository repo = new VolunteerRepository();

        // GET api/<controller>/
        public CalculationsViewModel Get()
        {
            var currentUser = User.Identity.Name;
            repo.GetAllActivitiesForCurrentUser(currentUser);
            var calcVM = new CalculationsViewModel();
            calcVM.totalHours = repo.calculateYTDNumberHours(currentUser);
            calcVM.totalMileage = repo.calculateYTDMileage(currentUser);
            calcVM.totalDollars = repo.calculateYTDDollarsContributed(currentUser);
            return calcVM;   
        }
    }
}