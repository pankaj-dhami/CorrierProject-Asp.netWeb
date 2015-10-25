using System.ComponentModel.DataAnnotations;

namespace CourrierBO.Model
{
    public class BookingStatus
    {
        [Key]
        public int BookingStatusId { get; set; }
        public string BookingStatusType { get; set; }
    }
}
