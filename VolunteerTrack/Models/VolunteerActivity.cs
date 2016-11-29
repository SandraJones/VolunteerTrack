using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VolunteerTrack.Models
{
    public class VolunteerActivity
    {
        [Key]
        public int ActivityId { get; set; }
        public string OrgName { get; set; }
        public DateTime Date { get; set; }
        public int NumberHours { get; set; }
        public int Mileage { get; set; }
        public int DollarsContributed { get; set; }
       
    }
}