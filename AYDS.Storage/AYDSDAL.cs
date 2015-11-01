using AYDS.BO.BusinessObject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AYDS.Storage
{
    class AYDSDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName">EmailId / Mobile No</param>
        /// <param name="password">Pasword can be email or mobile no</param>
        public tblAYDSUserLoginDetail ValidateUser(string userName, string password)
        {
            tblAYDSUserLoginDetail userDetails = null;
            try
            {
                using (AtYourDoorStepEntities entity = new AtYourDoorStepEntities())
                {
                    if (userName.Contains('@'))
                        userDetails = entity.tblAYDSUserLoginDetails.Where(a => a.Password == password && a.EmailId == userName).FirstOrDefault();
                    else
                        userDetails = entity.tblAYDSUserLoginDetails.Where(a => a.Password == password && a.MobileNumber == Convert.ToInt32(userName)).FirstOrDefault();
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
        public tblAYDSUserLoginDetail RegisterUser(tblAYDSUserLoginDetail userDetails)
        {
            try
            {
                using (AtYourDoorStepEntities entity = new AtYourDoorStepEntities())
                {
                    userDetails.IsVerified = false;
                    userDetails.IsActivated = false;
                    userDetails.CreatedOn = DateTime.UtcNow;
                    userDetails.LastLogin = DateTime.UtcNow;
                    entity.tblAYDSUserLoginDetails.Add(userDetails);
                    entity.SaveChanges();
                    //Generte & SEND OTP
                    GenerateOTP(userDetails.MobileNumber, userDetails.UserId);
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
        public bool ValidateEmailMobile(string userName)
        {
            tblAYDSUserLoginDetail userDetails = null;
             bool result = true;
            try
            {
                using (AtYourDoorStepEntities entity = new AtYourDoorStepEntities())
                {
                    if (userName.Contains('@'))
                        userDetails = entity.tblAYDSUserLoginDetails.Where(a => a.EmailId == userName).FirstOrDefault();
                    else
                        userDetails = entity.tblAYDSUserLoginDetails.Where(a => a.MobileNumber == Convert.ToInt32(userName)).FirstOrDefault();

                    if(userDetails.UserId > 0)
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
        /// <param name="OTP"></param>
        public void ConfirmOTP(int userId, int OTP)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void CheckFare()
        {

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
                    result = address.AddressInfoId;
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

        public void ViewBookingDetails()
        {
        }

        public void TrckCourrier()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDetails"></param>
        public tblAYDSUserLoginDetail UpdateUserDetails(tblAYDSUserLoginDetail userDetails)
        {
            try
            {
                using (AtYourDoorStepEntities entity = new AtYourDoorStepEntities())
                {
                    entity.tblAYDSUserLoginDetails.Attach(userDetails);
                    entity.Entry(userDetails).State = EntityState.Modified;
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
        /// <param name="userId"></param>
        /// <returns></returns>
        public tblAYDSUserLoginDetail GetUserProfile(int userId)
        {
            tblAYDSUserLoginDetail userDetails = null;
            try
            {
                using (AtYourDoorStepEntities entity = new AtYourDoorStepEntities())
                {
                    userDetails = entity.tblAYDSUserLoginDetails.Where(a => a.UserId == userId).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return userDetails;
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
                    if (senderAddress.AddressInfoId == 0)
                        senderId = SaveAddress(senderAddress);
                    else
                        senderId = senderAddress.AddressInfoId;

                    if (recieverAddress.AddressInfoId == 0)
                        recieverId = SaveAddress(recieverAddress);
                    else
                        recieverId = recieverAddress.AddressInfoId;

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

        /// <summary>
        /// 
        /// </summary>
        public List<tblAYDSCity> GetCityList()
        {
            List<tblAYDSCity> city = null;
            using (AtYourDoorStepEntities entity = new AtYourDoorStepEntities())
            {
                city = entity.tblAYDSCities.Where(a => a.CityId > 0).ToList();
            }
            return city;
        }
    }
}
