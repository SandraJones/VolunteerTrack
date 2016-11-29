using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VolunteerTrack.Models
{
    public class CharityFocus
    {
        [Key]
        public string FocusId { get; set; }
        public string FocusName { get; set; }      
    }
}