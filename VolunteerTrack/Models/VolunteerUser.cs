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
        public ApplicationUser BaseUser {get; set;}
   
    }
} 
