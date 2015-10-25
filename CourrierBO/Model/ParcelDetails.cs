using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourrierBO.Model
{
    public class ParcelDetails
    {
        [Key]
        public int ParcelId { get; set; }
        public int ParcleTypeId { get; set; }
        public decimal Weight { get; set; }
        public decimal Width { get; set; }
        public decimal Breadth { get; set; }
        public decimal Height { get; set; }

        [ForeignKey("ParcleTypeId")]
        public ParcelType ParcelType { get; set; }
    }
}
