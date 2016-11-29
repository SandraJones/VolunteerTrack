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
        public int OrgId { get; set; }//assigned by DB
        public string OrgName { get; set; }
        public List<CharityFocus> Focus { get; set; }
    }
}