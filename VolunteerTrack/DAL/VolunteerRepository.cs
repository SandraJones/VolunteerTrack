using Microsoft.AspNet.Identity;
using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Concurrent;
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
        
        /*
        ADD ACTIVITY
        This method adds a volunteer activity to the database. 
        This is accomplished by the POST method in the C# 
        ActivitiesController.
        
        Arguments:
        Activity - the user inputs the activity on the InputActivity.cshtml page.
        */
        public void AddActivity(VolunteerActivity _activity)
        {
            Context.Activities.Add(_activity);
            Context.SaveChanges();  
        }


        /*
        REMOVE ACTIVITY
        This method deletes a volunteer activity from the database. 
        This is accomplished by the DELETE method in the C# 
        ActivitiesController.
        
        Arguments:
        ActivityId - the id of the activity that the user clicked the 
        delete button for, while on the MyActivities page, Activities.cshtml.
        */
        public void RemoveActivity(int _ActivityId)
        {   
            if(_ActivityId != 0) {

                var Activity = Context.Activities.Find(_ActivityId);
                Context.Activities.Remove(Activity);
                Context.SaveChanges();
            }
        }

        /*
        UPDATE ACTIVITY
        This method edits a volunteer activity from the database. 
        This is accomplished by the PUT method in the C# 
        ActivitiesController.

        Arguments:
        Activity - the activity that the user clicks the edit button for,  
        while on the MyActivities page, Activities.cshtml.
        */

        public void UpdateActivity(VolunteerActivity _activity)
        {
            Context.Entry(_activity).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();     
        }


        /*
        GET ONE ACTIVITY
        This method gets the activity by the activityId from the database. 
        The ActivitiesController GET method that takes an argument is the
        one used here.
        
        Arguments:
        ActivityId - the id of the activity 
        */
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

        /*
       This method gets all activities from the database. 
       This is accomplished by the GET method in the C# 
       ActivitiesController that does not take an argument..

       Arguments:
       None
       */
        public List<VolunteerActivity> GetAllActivitiesForAllUsers()
        {
            return Context.Activities.ToList();
        }

        public List<VolunteerActivity> GetAllActivitiesForCurrentUser(string UserName)
        {
            //this goes thru each activity and checks the username within the baseuser within the volunteeruser table and checks for a match, and adds to list if matched.
            return Context.Activities.Where(activity => activity.VolunteerUser.BaseUser.UserName == UserName).ToList();
        }

        /*
        CALCULATION OF NUMBER OF HOURS
        This method calculates the total number of hours (the user has volunteered) from the database. 
        This is accomplished by the GET method in the C# SummaryActivitiesController.
        
        Arguments:
        UserName - the username of the current user 
        */

        public int calculateYTDNumberHours(string UserName)
        {

            var AllActivities = this.GetAllActivitiesForCurrentUser(UserName);
            var totalHours = AllActivities.Sum(activity => activity.NumberHours);
            return totalHours;//this gets all hours for all dates
        }

        /*
        CALCULATION OF MILEAGE
        This method calculates the total mileage the user has entered into the database from the input form. 
        This is accomplished by the GET method in the C# SummaryActivitiesController.
        
        Arguments:
        UserName - the username of the current user 
        */

        public int calculateYTDMileage(string UserName)
        {
            var AllActivities = this.GetAllActivitiesForCurrentUser(UserName);
            var totalMileage = AllActivities.Sum(activity => activity.Mileage); //this gets all mileage for all dates
            return totalMileage;
        }

        /*
        CALCULATION OF DOLLARS CONTRIBUTED
        This method calculates the total dollars contributed by the user. 
        This is accomplished by the GET method in the C# SummaryActivitiesController.
        
        Arguments:
        UserName - the username of the current user 
        */

        public int calculateYTDDollarsContributed(string UserName)
        {
            var AllActivities = this.GetAllActivitiesForCurrentUser(UserName);
            var totalDollars = AllActivities.Sum(activity => activity.DollarsContributed); //this gets all money contributed to all charities for all dates
            return totalDollars;
        }

        /*
      This method gets an activity from the database. 
      This is accomplished by the GET method in the C# 
      ActivitiesController that takes the argument, UserName.

      Arguments:
      UserName
      */

        public VolunteerUser GetUserByUserName(string UserName)
        {
            return Context.VolunteerUsers.Where(v => v.BaseUser.UserName == UserName).FirstOrDefault();
        }

        /*
        This method is critical for build. Have to be able to create a 
        VolunteerUser with UserName as argument. This was necessary to be able
        to GetUserByUserName  (see above method).
        Arguments: UserName
        */
        public void CreateVolunteerUser(string UserName)
        {
            var user = GetAppUserByUserName(UserName);
            var VolUser = new VolunteerUser();
            VolUser.BaseUser = user;
            Context.VolunteerUsers.Add(VolUser);
            Context.SaveChanges();
        }
        /*
        This method gets the ApplicationUser so that 
        we can search the database for a match with the 
        UserName.
        
        Arguments: UserName
        */
        public ApplicationUser GetAppUserByUserName(string UserName)
        {
            return Context.Users.FirstOrDefault(u => u.UserName == UserName);
        }
        /*This method is a way to see if the UserName exists in the database.
         Arguments: e
         */
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