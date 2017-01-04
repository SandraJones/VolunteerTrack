using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteerTrack.Models
{
    public class CalculationsViewModel
    {
        public int totalHours { get; set; }
        public int totalMileage { get; set; }
        public int totalDollars { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
