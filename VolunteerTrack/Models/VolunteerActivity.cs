using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolunteerTrack.Models
{
    public class VolunteerActivity
    {
        public DateTime date { get; set; }
        public int numberHours { get; set; }
        public int mileage { get; set; }
        public int DollarsContributed { get; set; }
        public string OrgName { get; set; }
    }
}