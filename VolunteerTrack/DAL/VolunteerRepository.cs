using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        //methods for using data in database

        // adding a volunteer activity instance
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



    }
}