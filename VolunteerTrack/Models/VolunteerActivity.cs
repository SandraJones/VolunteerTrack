using Newtonsoft.Json;
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
        [Required]
        public string OrgName { get; set; }
        [Required]
        public DateTime Date { get; set; } 
        //all three below may be null due to being able to contribute w/o spending hours or mileage, etc.
        public int NumberHours { get; set; }
        public int Mileage { get; set; }
        public int DollarsContributed { get; set; }
        [JsonIgnoreAttribute]
        public virtual VolunteerUser VolunteerUser { get; set; }
       
    }
    public class VolunteerActivityViewModel
    {
        [Required]
        public string OrgName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        //all three below may be null due to being able to contribute w/o spending hours or mileage, etc.
        public int NumberHours { get; set; }
        public int Mileage { get; set; }
        public int DollarsContributed { get; set; }
        //add in volunteerUser so it will be added to the table
        public virtual VolunteerUser VolunteerUser { get; set; }
    }
}