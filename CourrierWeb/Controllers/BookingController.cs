using AYDS.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CourrierWeb.Controllers
{
    public class BookingController : ApiController
    {
        private AYDSDAL dal = new AYDSDAL();

        #region Booking
        [ResponseType(typeof(int))]
        public int PostAddress(tblAYDSAddressInformation address)
        {
            int addressId;
            if (!ModelState.IsValid)
            {
                return -1;
            }

            addressId = dal.SaveAddress(address);

            return addressId;
        }

        public bool PostAddress(tblAYDSAddressInformation senderAddress, tblAYDSAddressInformation recieverAddress, int userId, int parcleType)
        {
            bool resulr;
            if (!ModelState.IsValid)
            {
                return false;
            }

            resulr = dal.BookParcle(senderAddress, recieverAddress, userId, parcleType);

            return resulr;
        }
        #endregion

        #region FareCalculator
        
        #endregion

        #region TrackingAndHistory
        
        #endregion
    }
}
