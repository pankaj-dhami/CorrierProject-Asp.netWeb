using System.ComponentModel.DataAnnotations;

namespace CourrierBO.Model
{
    public class AddressType
    {
        [Key]
        public int AddressTypeId { get; set; }
        public string Type { get; set; }

    }
}
