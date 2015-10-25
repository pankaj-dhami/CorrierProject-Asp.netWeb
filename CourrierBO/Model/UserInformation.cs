using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourrierBO.Model
{
    public class UserInformation
    {
        [Key]
        public int UserInfoId { get; set; }        
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public int MobileNumber { get; set; }
        public string EmailId { get; set; }
        public int Country { get; set; }
        public int City { get; set; }
        public string CountryCode { get; set; }

        [ForeignKey("UserId")]
        public UserLoginDetails UserLoginDetails  { get; set; }
    }
}
