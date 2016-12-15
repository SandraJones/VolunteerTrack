using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VolunteerTrack.Models
{
    public class VolunteerUser
    {
        [Key]
        public int VolunteerUserId { get; set; } 

        //given by Entity and used for login and registration; repre notion of a user
        public ApplicationUser BaseUser {get; set;}
        public virtual List<VolunteerActivity> Activities { get; set; }
    }
} 
