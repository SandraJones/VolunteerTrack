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
            Context.Activities.Remove(_activity);
            Context.Activities.Add(_activity);
            Context.SaveChanges();
        }
        public void CalculateYTDDollarContributions(VolunteerActivity UserName)
        {
            var currentUser = UserName;
           // Context.Activities.DollarsContributed.TotalYTD();
            //may do this in Angular app.js file
        }
        //GetActivity method is for editing or deleting of an activity. Have to use the activityID for this possibly.
        public VolunteerActivity GetActivityById(int activity_Id)
        {
            VolunteerActivity found_activity = Context.Activities.FirstOrDefault(i => i.ActivityId == activity_Id);
            if (found_activity != null)
            {
                return found_activity;
            }
            else
            {
                return null;
            }
        } 
         
        public List<VolunteerActivity> GetAllActivitiesForAllUsers()
        {
            return Context.Activities.ToList();
        }

        public List<VolunteerActivity> GetAllActivitiesForCurrentUser(string UserName)
        {
            //this goes thru each activity and checks the username within the baseuser within the volunteeruser table and checks for a match, and adds to list if matched.
            return Context.Activities.Where(activity => activity.VolunteerUser.BaseUser.UserName == UserName).ToList();
        }

        public VolunteerUser GetUserByUserName(string UserName)
        {
            return Context.VolunteerUsers.Where(v => v.BaseUser.UserName == UserName).FirstOrDefault();
        }

        public void CreateVolunteerUser(string UserName)
        {
            var user = GetAppUserByUserName(UserName);
            var VolUser = new VolunteerUser();
            VolUser.BaseUser = user;
            Context.VolunteerUsers.Add(VolUser);
            Context.SaveChanges();
        }

        public ApplicationUser GetAppUserByUserName(string UserName)
        {
            return Context.Users.FirstOrDefault(u => u.UserName == UserName);
        }

        public bool UsernameExists(string e)
        {
            VolunteerUser found_User = Context.VolunteerUsers.FirstOrDefault(s =>s.BaseUser.UserName.ToLower() == e.ToLower());
            if (found_User != null)
            {
                return true;
            }

            return false;

        }

      
    }
}