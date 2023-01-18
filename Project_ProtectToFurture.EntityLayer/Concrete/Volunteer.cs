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
        public string Surname { get; set; }
        public string City { get; set; }
        public string volunteerEmail { get; set; }
        public string volunteerPhone { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
