using System.ComponentModel.DataAnnotations;

namespace CourrierBO.Model
{
    public class ParcelType
    {
        [Key]
         public int ParcleTypeId { get; set; }
         public string ParcleType { get; set; }
    }
}
