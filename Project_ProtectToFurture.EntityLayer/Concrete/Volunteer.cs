using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.EntityLayer.Concrete
{
    public class Volunteer
    {
        public int VolunteerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set;}
        public string City { get; set; }
        public string VolunteerEmail { get; set; }
        public string VolunteerPhone { get; set; }
        public string About { get; set; }
        public bool Status { get; set; } = true;

        

    }
}
