using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourrierBO.Model
{
    class AddressInformation
    {
        public int AddressInfoId { get; set; }
        public int UserId { get; set; }
        public int AddressType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Landmark { get; set; }
        public int Country { get; set; }
        public int City { get; set; }
        public int PinCode { get; set; }
        public int Contact1 { get; set; }
        public int Contact2 { get; set; }
        public string EmailId { get; set; }
        public string AddressNickName { get; set; }
    }
}
