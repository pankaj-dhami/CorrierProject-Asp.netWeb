using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourrierBO.Model
{
    class BookingDetails
    {
        public string BookingId { get; set; }
        public int UserId { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public int ParcleType { get; set; }
        public DateTime BookingDateTime { get; set; }
        public DateTime EstimatedDeliveyDateTime { get; set; }
        public int BookingStatus { get; set; }
    }
}
