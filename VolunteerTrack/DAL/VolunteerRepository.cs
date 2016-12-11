using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VolunteerTrack.Models;

namespace VolunteerTrack.DAL
{
    public class VolunteerRepository
    {
        public VolunteerContext Context {get; set;}
        public VolunteerRepository()
        {
            Context = new VolunteerContext();
        }
        public VolunteerRepository(VolunteerContext _context)
        {
            Context = _context;
        }
        
        public void AddActivity(VolunteerActivity _activity)
        {
            //will have to add in a check for existing activity for that date??
            Context.Activities.Add(_activity);
            Context.SaveChanges();  
        }
        public void RemoveActivity(VolunteerActivity _activity)
        {
            Context.Activities.Remove(_activity);
            Context.SaveChanges();
        }
        public void EditActivity(VolunteerActivity _activity)
        {
           // Context.Activities.???//unsure how to handle this
        }
        //may handle calulations in front-end
        public void CalculateYTDDollarContributions(VolunteerActivity _dollarsContributed)
        {
            //if (_dollarsContributed != null)
            //{
            //    Context.Activities.VolunteerActivity.TotalYTD();
            //}  may do this in Angular app.js file
        }
        //GetActivity method is for editing or deleting of an activity. Have to use the activityID for this possibly.
        public void GetActivity(VolunteerActivity _activity)
        {
            Context.Activities.Find(_activity);
            
        }

        
    }
}