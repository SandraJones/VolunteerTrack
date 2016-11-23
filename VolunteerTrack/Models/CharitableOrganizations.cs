using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VolunteerTrack.Models
{
    public class CharitableOrganizations
    {   
        [Key]
        public string OrgId { get; set; }//assigned by DB
        public string OrganizationName { get; set; }
        public int numberHours { get; set; }
        public int YTDHours { get; set; }
        public DateTime date { get; set; }
        public int mileage { get; set; }
        public int YTDMileage { get; set; }
        public int DollarsContributed { get; set; }
        public int YTDDollarsContributed { get; set; }

    }
}