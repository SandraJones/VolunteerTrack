using Microsoft.AspNet.Identity;
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
           //_activity.ActivityId.CompareTo
        }
        //may handle calulations in front-end
        public void CalculateYTDDollarContributions(VolunteerActivity UserName)
        {
            var currentUser = UserName;
           // Context.Activities.DollarsContributed.TotalYTD();
            //may do this in Angular app.js file
        }
        //GetActivity method is for editing or deleting of an activity. Have to use the activityID for this possibly.
        public VolunteerActivity GetActivityById(int Id)
        {
           return Context.Activities.Find(Id);     
        }
        //get all by user
        //return whole list until I get users implemented User Manager applicationuser
        public List<VolunteerActivity> GetAllActivitiesForAllUsers()
        {
            return Context.Activities.ToList();//this gets all for all users will have to limit at some point to current user
        }
        public List<VolunteerActivity> GetAllActivitiesForCurrentUser(string UserName)
        {
            return Context.Activities.Where(activity => activity.VolunteerUser.BaseUser.UserName == UserName).ToList();
            //this goes thru each activity and checks the username within the baseuser within the volunteeruser table and checks for a match, and adds to list if matched.
        }
    }
}

//make sure I'm saving user with rest of the object