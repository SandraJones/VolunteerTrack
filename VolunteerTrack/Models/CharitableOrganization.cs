using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VolunteerTrack.Models
{
    public class CharitableOrganization
    {
        [Key]
        public int OrgId { get; set; }

        [Required]
        public string OrgName { get; set;}
        public List<string> Focus { get; set; }
    }
}