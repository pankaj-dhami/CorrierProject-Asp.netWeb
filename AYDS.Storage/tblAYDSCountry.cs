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
    
    public partial class tblAYDSCountry
    {
        public tblAYDSCountry()
        {
            this.tblAYDSAddressInformations = new HashSet<tblAYDSAddressInformation>();
            this.tblAYDSCities = new HashSet<tblAYDSCity>();
            this.tblAYDSStates = new HashSet<tblAYDSState>();
            this.tblAYDSUserInformations = new HashSet<tblAYDSUserInformation>();
        }
    
        public int CountryId { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string CountryShortCode { get; set; }
    
        public virtual ICollection<tblAYDSAddressInformation> tblAYDSAddressInformations { get; set; }
        public virtual ICollection<tblAYDSCity> tblAYDSCities { get; set; }
        public virtual ICollection<tblAYDSState> tblAYDSStates { get; set; }
        public virtual ICollection<tblAYDSUserInformation> tblAYDSUserInformations { get; set; }
    }
}