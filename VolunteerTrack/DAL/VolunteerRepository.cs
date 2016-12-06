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
        //for test instan activity and calal repo.addActivity(whatever name instant obj is given)
        //when I use the method I don't put a type in the argument.


        //adding mileage
        //take input from form using angular and enter into table
        //adding hours
        //take input from form using angular and enter into table
        //adding dollar contributions
        //take input from form using angular and enter into table
        //need to be able to update mileage, hours, or dollars contributed for a specific date of activity
        //calculating YTD mileage
        //calculating YTD hours
        //calculating YTD monetary contributions
        public void CalculateYTDDollarContributions(VolunteerActivity _dollarsContributed)
        {
            if (_dollarsContributed != null)
            {

                Context.Activities.DollarsContributed.TotalYTD();
            }

        }



    }
}