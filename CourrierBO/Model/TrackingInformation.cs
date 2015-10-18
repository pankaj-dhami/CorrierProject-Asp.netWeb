using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourrierBO.Model
{
    class TrackingInformation
    {
        public int TrackingId { get; set; }    
        public string BookingId { get; set; }    
        public DateTime CurrentStateDateTime { get; set; }    
        public int CurrentLocation { get; set; }    
    }
}
