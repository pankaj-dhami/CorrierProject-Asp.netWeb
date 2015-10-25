using System.ComponentModel.DataAnnotations;

namespace CourrierBO.Model
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CountryShortCode { get; set; }
    }
}
