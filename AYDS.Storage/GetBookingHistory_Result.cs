//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AYDS.Storage
{
    using System;
    
    public partial class GetBookingHistory_Result
    {
        public string BookingId { get; set; }
        public Nullable<System.DateTime> BookingDateTime { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderLastName { get; set; }
        public Nullable<int> SourceCity { get; set; }
        public string RecieverFirstName { get; set; }
        public string RecieverLastName { get; set; }
        public Nullable<int> DestinationCity { get; set; }
    }
}