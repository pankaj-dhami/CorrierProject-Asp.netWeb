using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourrierWeb.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public int MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
    }
}