using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolunteerTrack.Models
{
    public class VolunteerUser
    {
        public string organization { get; set; }
        public DateTime date { get; set; }
        public int numberHours { get; set; }
        public int YTDHours { get; set; }
        public int mileage { get; set; }
        public int YTDMileage { get; set; }
        public int DollarsContributed { get; set; }
        public int YTDDollarsContributed { get; set; }
    }
} 
