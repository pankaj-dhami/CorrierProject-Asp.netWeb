using AYDS.BO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AYDS.Storage
{
    public class AYDSDAL
    {
        #region User
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName">EmailId / Mobile No</param>
        /// <param name="password">Pasword can be email or mobile no</param>
        public tblAYDSUserInformation ValidateUser(string userName, string password)
        {
            tblAYDSUserInformation userDetails = null;
            try
            {
                using (AtYourDoorStepEntities entity = new AtYourDoorStepEntities())
                {
                    if (userName.Contains('@'))
                        userDetails = entity.tblAYDSUserInformations.Where(a => a.Password == password && a.EmailId == userName).FirstOrDefault();
                    else
                        userDetails = entity.tblAYDSUserInformations.Where(a => a.Password == password && a.MobileNumber == Convert.ToInt32(userName)).FirstOrDefault();
                    //On login update last login time 
                    userDetails.LastLogin = DateTime.UtcNow;
                    entity.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
            return userDetails;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDetails"></param>
        public tblAYDSUserInformation RegisterUser(tblAYDSUserInformation userDetails)
        {
            try
            {
                if (ValidateEmailMobile(userDetails.MobileNumber, userDetails.EmailId))
                {
                    using (AtYourDoorStepEntities entity = new AtYourDoorStepEntities())
                    {
                        userDetails.IsVerified = false;
                        userDetails.IsActivated = false;
                        userDetails.CreatedOn = DateTime.UtcNow;
                        userDetails.LastLogin = DateTime.UtcNow;
                        entity.tblAYDSUserInformations.Add(userDetails);
                        entity.SaveChanges();
                        //Generte & SEND OTP
                        GenerateOTP(userDetails.MobileNumber, userDetails.Id);
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
            }
            return userDetails;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool ValidateEmailMobile(int mobileNumber, string emailId)
        {
            tblAYDSUserInformation userDetails = null;
            bool result = true;
            try
            {
                using (AtYourDoorStepEntities entity = new AtYourDoorStepEntities())
                {
                    userDetails = entity.tblAYDSUserInformations.Where(a => a.EmailId == emailId || a.MobileNumber == mobileNumber).FirstOrDefault();

                    if (userDetails.Id > 0)
                        result = false;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public tblAYDSUserInformation GetUserProfile(int userId)
        {
            tblAYDSUserInformation userDetails = null;
            try
            {
                using (AtYourDoorStepEntities entity = new AtYourDoorStepEntities())
                {
                    userDetails = entity.tblAYDSUserInformations.Where(a => a.Id == userId).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return userDetails;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDetails"></param>
        public tblAYDSUserInformation UpdateUserDetails(tblAYDSUserInformation userDetails)
        {
            try
            {
                using (AtYourDoorStepEntities entity = new AtYourDoorStepEntities())
                {
                    entity.tblAYDSUserInformations.Attach(userDetails);
                    entity.Entry(userDetails).State = EntityState.Modified;
                    entity.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
            return userDetails;
        }
        #endregion       
             
        #region Booking
        /// <summary>
        /// 
        /// </summary>
        public List<FareDetails> CheckFare()
        {
            List<FareDetails> fareDetails =null;
            return fareDetails;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        public int SaveAddress(tblAYDSAddressInformation address)
        {
            int result = 0;
            try
            {
                using (AtYourDoorStepEntities entity = new AtYourDoorStepEntities())
                {
                    entity.tblAYDSAddressInformations.Add(address);
                    entity.SaveChanges();
                    result = address.Id;
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="senderAddress"></param>
        /// <param name="recieverAddress"></param>
        /// <param name="userId"></param>
        /// <param name="parcleType"></param>
        /// <returns></returns>
        public bool BookParcle(tblAYDSAddressInformation senderAddress, tblAYDSAddressInformation recieverAddress, int userId, int parcleType)
        {
            bool result = false;
            int senderId;
            int recieverId;
            tblAYDSBookingDetail bookingDetails = null;
            try
            {
                using (AtYourDoorStepEntities entity = new AtYourDoorStepEntities())
                {
                    if (senderAddress.Id == 0)
                        senderId = SaveAddress(senderAddress);
                    else
                        senderId = senderAddress.Id;

                    if (recieverAddress.Id == 0)
                        recieverId = SaveAddress(recieverAddress);
                    else
                        recieverId = recieverAddress.Id;

                    //Booking Details
                    bookingDetails.UserId = userId;
                    bookingDetails.RecieverId = recieverId;
                    bookingDetails.SenderId = senderId;
                    bookingDetails.ParcleType = parcleType;
                    bookingDetails.BookingDateTime = DateTime.UtcNow;
                    bookingDetails.BookingStatus = 1;
                    entity.tblAYDSBookingDetails.Add(bookingDetails);
                    entity.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
        #endregion       

        #region TrackingAndHistory
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<BookingHistory> GetBookingHistory(int userId)
        {
            List<BookingHistory> bookingHistory = null;
            try
            {
                using (AtYourDoorStepEntities entity = new AtYourDoorStepEntities())
                {

                    //bookingHistory 
                }
            }
            catch (Exception ex)
            {

            }
            return bookingHistory;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ViewBookingDetails()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void TrckCourrier()
        {
        } 
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="OTP"></param>
        public void ConfirmOTP(int userId, int OTP)
        {
        }

        /// <summary>
        /// Method used to generate OTP 
        /// </summary>
        /// <param name="mobileNo">Send OTP to this no</param>
        /// <param name="userId"></param>
        public void GenerateOTP(int mobileNo, int userId)
        {

        }      

        /// <summary>
        /// 
        /// </summary>
        public List<tblAYDSCity> GetCityList()
        {
            List<tblAYDSCity> city = null;
            using (AtYourDoorStepEntities entity = new AtYourDoorStepEntities())
            {
                city = entity.tblAYDSCities.Where(a => a.Id > 0).ToList();
            }
            return city;
        }
    }
}
