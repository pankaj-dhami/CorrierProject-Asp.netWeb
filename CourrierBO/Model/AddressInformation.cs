using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourrierBO.Model
{
    public class AddressInformation
    {
        [Key]
        public int AddressInfoId { get; set; }
        public int UserId { get; set; }
        public int AddressTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Landmark { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int PinCode { get; set; }
        public int Contact1 { get; set; }
        public int Contact2 { get; set; }
        public string EmailId { get; set; }
        public string AddressNickName { get; set; }

        [ForeignKey("UserId")]
        public UserLoginDetails UserLoginDetails { get; set; }
        [ForeignKey("AddressTypeId")]
        public AddressType AddressType { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }
        
    }
}
