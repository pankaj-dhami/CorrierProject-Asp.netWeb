using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYDS.BO
{
    class UserDetails
    {
        public int UserId { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public int MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }  
}
