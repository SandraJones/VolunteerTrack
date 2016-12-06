using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using VolunteerTrack.Models;

namespace VolunteerTrack.DAL
{
    public class VolunteerContext : DbContext
    {
        // 'virtual' is for Moq during testing
        public virtual DbSet<VolunteerUser> Users { get; set; }
        public virtual DbSet<CharityFocus> Focuses { get; set; } 
        public virtual DbSet<VolunteerActivity> Activities { get; set; }
        public virtual DbSet<CharitableOrganization> CharitableOrganizations { get; set; }
    }

}