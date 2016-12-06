using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolunteerTrack.Models
{
    public class CharitableOrganization
    {
        public int OrgId { get; set; }
        public string OrgName { get; set;}
        public List<string> Focus { get; set; }
    }
}