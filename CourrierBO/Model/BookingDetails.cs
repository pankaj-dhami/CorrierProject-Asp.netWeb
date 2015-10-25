using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourrierBO.Model
{
    public class BookingDetails
    {
        [Key]
        public string BookingId { get; set; }
        public int UserId { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public int ParcleTypeId { get; set; }
        public DateTime BookingDateTime { get; set; }
        public DateTime EstimatedDeliveyDateTime { get; set; }
        public int BookingStatusId { get; set; }

        [ForeignKey("UserId")]
        public UserLoginDetails UserLoginDetails { get; set; }
        [ForeignKey("ParcleTypeId")]
        public ParcelType ParcelType { get; set; }
        [ForeignKey("BookingStatusId")]
        public BookingStatus BookingStatus { get; set; }
        [ForeignKey("SenderId")]
        public AddressInformation AddressInformationSender { get; set; }
        [ForeignKey("RecieverId")]
        public AddressInformation AddressInformationReciever { get; set; }

    }
}
