using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourrierBO.Model
{
    public class TrackingInformation
    {
        [Key]
        public int TrackingId { get; set; }
        public string BookingId { get; set; }    
        public DateTime CurrentStateDateTime { get; set; }    
        public string CurrentLocation { get; set; }

        [ForeignKey("BookingId")]
        public BookingDetails BookingDetails { get; set; }
    }
}
