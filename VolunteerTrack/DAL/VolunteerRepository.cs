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
            //this goes thru each activity and checks the username within the baseuser within the volunteeruser table and checks for a match, and adds to list if matched.
            return Context.Activities.Where(activity => activity.VolunteerUser.BaseUser.UserName == UserName).ToList();
        }
        public VolunteerUser GetUserByUserName(string UserName)
        {
            //var onlyUser = Context.Users.FirstOrDefault();
            //var onlyApplicationUser = Context.VolunteerUsers.FirstOrDefault();
            //onlyApplicationUser.BaseUser = onlyUser;
            //Context.SaveChanges();
            return Context.VolunteerUsers.Where(v => v.BaseUser.UserName == UserName).FirstOrDefault();
        }
        //similar but adjust Tweet is like Activity and Twit is m voluser 
        //public void AddTweet(string username, string tweet_message)
        //{
        //    Twit found_twit = Context.TweeterUsers.FirstOrDefault(u => u.BaseUser.UserName == username);
        //    if (found_twit != null)
        //    {
        //        Tweet new_tweet = new Tweet
        //        {
        //            Message = tweet_message,
        //            CreatedAt = DateTime.Now,
        //            Author = found_twit
        //        };
        //        Context.Tweets.Add(new_tweet);
        //        Context.SaveChanges();
        //    }
        //}
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
}
}

//make sure I'm saving user with rest of the object