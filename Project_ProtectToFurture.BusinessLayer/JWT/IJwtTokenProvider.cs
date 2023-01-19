using Project_ProtectToFurture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProtectToFurture.BusinessLayer.JWT
{
    public interface IJwtTokenProvider
    {
        public string GnerateTokken(AppUser user);
    }
}
