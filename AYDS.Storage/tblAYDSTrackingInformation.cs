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
    using System.Collections.Generic;
    
    public partial class tblAYDSTrackingInformation
    {
        public int Id { get; set; }
        public string BookingId { get; set; }
        public System.DateTime CurrentStateDateTime { get; set; }
        public string CurrentLocation { get; set; }
    
        public virtual tblAYDSBookingDetail tblAYDSBookingDetail { get; set; }
    }
}
