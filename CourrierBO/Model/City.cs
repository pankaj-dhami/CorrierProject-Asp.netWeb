using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourrierBO.Model
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int PinCode { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        [ForeignKey("StateId")]
        public State State { get; set; }
    }
}
