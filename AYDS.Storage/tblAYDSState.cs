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
    
    public partial class tblAYDSState
    {
        public tblAYDSState()
        {
            this.tblAYDSCities = new HashSet<tblAYDSCity>();
        }
    
        public int Id { get; set; }
        public string StateName { get; set; }
        public int Country { get; set; }
    
        public virtual ICollection<tblAYDSCity> tblAYDSCities { get; set; }
        public virtual tblAYDSCountry tblAYDSCountry { get; set; }
    }
}
