using RestoBook.Common;
using RestoBook.Common.Model;
using RestoBook.Common.Model.Models;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Common.Business.Managers
{
    public class ReservationManager
    {
        #region PROPERTIES
        DataProvider dp;
        #endregion

        #region CONSTRUCTOR
        public ReservationManager()
        {
            dp = new DataProvider();
            dp.PrepareFullReservation();
        }
        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// Create a reservation
        /// ReservationDate has value DateTime.Now
        /// RestoConfirmationDate has value DateTime.MaxValue
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public bool CreateReservation(Reservation reservation)
        {
            this.RefreshDataSet();

            int nbrRowsCreated = -1;

            try
            {
                using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.RESERVATIONTableAdapter daReservation = new Model.DataSetRestoBookTableAdapters.RESERVATIONTableAdapter())
                {
                    nbrRowsCreated = daReservation.Insert(
                                                            reservation.CustomerId,
                                                            reservation.ServiceId,
                                                            reservation.ReservationDate,
                                                            reservation.Service,
                                                            reservation.PlaceQuantity,
                                                            reservation.RestoConfirmation = false,
                                                            reservation.RestoConfirmationDate = DateTime.MaxValue.Date,
                                                            reservation.RestoComments = reservation.RestoComments,
                                                            reservation.IsEnabled = true);
                }
                return nbrRowsCreated > 0;
            }

            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }

            catch (System.Data.StrongTypingException)
            {
                return false;
            }

            catch (System.NullReferenceException)
            {
                return false;
            }
        }

        /// <summary>
        /// Only used by backoffice to change all reservation's data except foreign keys (serviceId, customerId)
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public bool ModifyReservationsFromBackOffice(Reservation reservation)
        {
            this.RefreshDataSet();

            int nbrRowsUpdated = -1;

            try
            {
                DataRow row = dp.ds.RESERVATION.Select(string.Format("RESERVATIONID = '{0}'", reservation.Id)).FirstOrDefault();
                row["RESERVATIONDATE"] = reservation.ReservationDate;
                row["PLACEQUANTITY"] = reservation.PlaceQuantity;
                row["SERVICE"] = reservation.Service;
                row["RESTOCONFIRMATION"] = reservation.RestoConfirmation;
                row["RESTOCONFIRMATIONDATE"] = DateTime.Now;
                row["RESTOCOMMENTS"] = reservation.RestoComments;

                using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.RESERVATIONTableAdapter daReservation = new Model.DataSetRestoBookTableAdapters.RESERVATIONTableAdapter())
                {
                    nbrRowsUpdated = daReservation.Update(row);
                }
                return nbrRowsUpdated > 0;
            }

            catch (System.NullReferenceException)
            {
                return false;
            }
        }

        /// <summary>
        /// This method allow customer to modify number of places reserved
        /// Other datas can't be modified
        /// A reservation must be deleted and recreated in place to modify customer or service
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns>bool if creation succeed</returns>
        public bool ModifyReservationFromCustomer(Reservation reservation)
        {
            //this.RefreshDataSet();

            int nbrRowsUpdated = -1;

            try
            {
                DataRow row = dp.ds.RESERVATION.Select(string.Format("RESERVATIONID = '{0}'", reservation.Id)).FirstOrDefault();
                row["PLACEQUANTITY"] = reservation.PlaceQuantity;

                using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.RESERVATIONTableAdapter daReservation = new Model.DataSetRestoBookTableAdapters.RESERVATIONTableAdapter())
                {
                    nbrRowsUpdated = daReservation.Update(row);
                }
                return nbrRowsUpdated > 0;
            }
            catch (System.NullReferenceException)
            {
                return false;
            }
        }

        /// <summary>
        /// Input datas from confirmation by restaurant
        /// - change value from false to true in RestoConfirmation
        /// - change value of RestoConfirmationDate to DateTime.now
        /// - input comments if completed
        /// 
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public bool ConfirmReservationFromResto(Reservation reservation)
        {
            this.RefreshDataSet();

            int nbrRowsUpdated = -1;

            try
            {
                DataRow row = dp.ds.RESERVATION.Select(string.Format("RESERVATIONID = '{0}'", reservation.Id)).FirstOrDefault();
                row["RESTOCONFIRMATION"] = true;
                row["RESTOCONFIRMATIONDATE"] = DateTime.Now;
                row["RESTOCOMMENTS"] = reservation.RestoComments;

                using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.RESERVATIONTableAdapter daReservation = new Model.DataSetRestoBookTableAdapters.RESERVATIONTableAdapter())
                {
                    nbrRowsUpdated = daReservation.Update(row);
                }
                return nbrRowsUpdated > 0;
            }

            catch (System.NullReferenceException)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets all reservations for a given service
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        public List<Reservation> GetReservationByService(int serviceId)
        {
            this.RefreshDataSet();

            List<Reservation> reservations = new List<Reservation>();

            try
            {
                reservations = (from r in dp.ds.RESERVATION
                                where r.SERVICEID == serviceId
                                join s in dp.ds.SERVICE on r.SERVICEID equals s.SERVICEID
                                select new Reservation()
                                {
                                    Id = r.RESERVATIONID,
                                    CustomerId = r.CUSTOMERID,
                                    ServiceId = r.SERVICEID,
                                    ReservationDate = r.RESERVATIONDATE,
                                    PlaceQuantity = r.PLACEQUANTITY,
                                    RestoConfirmation = r.RESTOCONFIRMATION,
                                    RestoConfirmationDate = r.RESTOCONFIRMATIONDATE,
                                    RestoComments = r.RESTOCOMMENTS,
                                    IsEnabled = r.ENABLE
                                }).ToList();
                return reservations;
            }
            catch (System.Data.StrongTypingException)
            {
                return reservations;
            }
        }

        /// <summary>
        /// Gets a list of reservations confirmed and filtred by service 
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns>A list of reservation</returns>
        public List<Reservation> GetReservationConfirmedByService(int serviceId)
        {
            this.RefreshDataSet();

            List<Reservation> reservations = new List<Reservation>();

            try
            {
                reservations = (from r in dp.ds.RESERVATION
                                where ((r.SERVICEID == serviceId) && (r.RESTOCONFIRMATIONDATE.Year != DateTime.MaxValue.Year))
                                select new Reservation()
                                {
                                    Id = r.RESERVATIONID,
                                    CustomerId = r.CUSTOMERID,
                                    ServiceId = r.SERVICEID,
                                    ReservationDate = r.RESERVATIONDATE,
                                    PlaceQuantity = r.PLACEQUANTITY,
                                    RestoConfirmation = r.RESTOCONFIRMATION,
                                    RestoConfirmationDate = r.RESTOCONFIRMATIONDATE,
                                    RestoComments = r.RESTOCOMMENTS,
                                    IsEnabled = r.ENABLE
                                }).ToList();
                return reservations;
            }
            catch (System.Data.StrongTypingException)
            {
                return reservations;
            }
        }

        /// <summary>
        /// Gets a list of reservation not confirmed and filtred by service 
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns>A list of reservation</returns>
        public List<Reservation> GetReservationNotConfirmedByService(int serviceId)
        {
            this.RefreshDataSet();

            List<Reservation> reservations = new List<Reservation>();
            try
            {
                reservations = (from r in dp.ds.RESERVATION
                                where r.SERVICEID == serviceId && r.RESTOCONFIRMATIONDATE.Year == DateTime.MaxValue.Year
                                select new Reservation()
                                {
                                    Id = r.RESERVATIONID,
                                    CustomerId = r.CUSTOMERID,
                                    ServiceId = r.SERVICEID,
                                    PlaceQuantity = r.PLACEQUANTITY,
                                    RestoConfirmation = r.RESTOCONFIRMATION,
                                    ReservationDate = r.RESERVATIONDATE,
                                    RestoConfirmationDate = r.RESTOCONFIRMATIONDATE,
                                    RestoComments = r.RESTOCOMMENTS,
                                    IsEnabled = r.ENABLE
                                }).ToList();

                return reservations;
            }
            catch (System.Data.StrongTypingException)
            {
                return reservations;
            }
        }

        /// <summary>
        /// Gets reservation made within 24 hours     
        /// </summary>
        /// <returns>A List of Reservations</returns>
        public List<Reservation> GetReservationNotConfirmedWithin24Hours()
        {
            this.RefreshDataSet();

            List<Reservation> reservations = new List<Reservation>();

            try
            {
                reservations = (from r in dp.ds.RESERVATION
                                where (r.RESTOCONFIRMATIONDATE.Year == DateTime.MaxValue.Year && (r.RESERVATIONDATE).AddHours(24) >= DateTime.Now)
                                orderby r.RESERVATIONDATE
                                select new Reservation()
                                {
                                    Id = r.RESERVATIONID,
                                    CustomerId = r.CUSTOMERID,
                                    ServiceId = r.SERVICEID,
                                    ReservationDate = r.RESERVATIONDATE,
                                    RestoConfirmationDate = r.RESTOCONFIRMATIONDATE,
                                    PlaceQuantity = r.PLACEQUANTITY,
                                    IsEnabled = r.ENABLE
                                }).ToList();
                return reservations;
            }

            catch (System.Data.StrongTypingException)
            {
                return reservations;
            }
        }

        /// <summary>
        /// Gets reservation by Restaurant
        /// </summary>
        /// <param name="restoId"></param>
        /// <returns></returns>
        public List<Reservation> GetReservationsByRestaurant (int restoId)
        {
            this.RefreshDataSet();

            List<Reservation> reservations = new List<Reservation>();

            try
            {
                reservations = (from r in dp.ds.RESERVATION
                                join c in dp.ds.CUSTOMER on r.CUSTOMERID equals c.CUSTOMERID
                                join s in dp.ds.SERVICE on r.SERVICEID equals s.SERVICEID
                                join rest in dp.ds.RESTAURANT on s.RESTAURANTID equals rest.RESTAURANTID
                                where rest.RESTAURANTID == restoId
                                orderby s.SERVICEDAY
                                select new Reservation()
                                {
                                    Id = r.RESERVATIONID,
                                    CustomerId = r.CUSTOMERID,
                                    ServiceId = r.SERVICEID,
                                    ReservationDate = r.RESERVATIONDATE,
                                    Service = s.TYPESERVICE,
                                    PlaceQuantity = r.PLACEQUANTITY,
                                    RestoConfirmation = r.RESTOCONFIRMATION,
                                    RestoConfirmationDate = r.RESTOCONFIRMATIONDATE,
                                    RestoComments = r.RESTOCOMMENTS,
                                    IsEnabled = r.ENABLE,
                                    Customer = new Customer()
                                                            { Id = c.CUSTOMERID,
                                                              IsEnable = c.ENABLE,
                                                              Mail = c.MAIL,
                                                              Phone = c.PHONE
                                                            }
                                   
                                }).ToList();

                return reservations;
            }

            catch
            {
                return reservations;
            }

            
        }

        /// <summary>
        /// Reteurn all reservations
        /// </summary>
        /// <returns>A list of all reservations</returns>
        public List<Reservation> GetAllReservations()
        {
            this.RefreshDataSet();

            List<Reservation> reservations = new List<Reservation>();

            try
            {
                reservations = (from r in dp.ds.RESERVATION
                                join c in dp.ds.CUSTOMER on r.CUSTOMERID equals c.CUSTOMERID
                                join s in dp.ds.SERVICE on r.SERVICEID equals s.SERVICEID
                                select new Reservation()
                                {
                                    Id = r.RESERVATIONID,
                                    CustomerId = r.CUSTOMERID,
                                    ServiceId = r.SERVICEID,
                                    ReservationDate = r.RESERVATIONDATE,
                                    Service = s.TYPESERVICE,
                                    PlaceQuantity = r.PLACEQUANTITY,
                                    RestoConfirmation = r.RESTOCONFIRMATION,
                                    RestoConfirmationDate = r.RESTOCONFIRMATIONDATE,
                                    RestoComments = r.RESTOCOMMENTS,
                                    IsEnabled = r.ENABLE,
                                    Customer = new Customer() { Id = c.CUSTOMERID, IsEnable = c.ENABLE, Mail = c.MAIL, Phone = c.PHONE }
                                }).ToList();
                return reservations;
            }
            catch (System.Data.StrongTypingException)
            {
                return reservations;
            }
        }

        /// <summary>
        /// Gets a reservation by it's id
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns></returns>
        public Reservation GetReservationById(int reservationId)
        {
            this.RefreshDataSet();
            Reservation reservation = new Reservation();
            reservation = (from r in this.dp.ds.RESERVATION
                           where r.RESERVATIONID == reservationId
                           select new Reservation()
                           {
                               Id = r.RESERVATIONID,
                               CustomerId = r.CUSTOMERID,
                               ServiceId = r.SERVICEID,
                               ReservationDate = r.RESERVATIONDATE,
                               RestoConfirmationDate = r.RESTOCONFIRMATIONDATE,
                               PlaceQuantity = r.PLACEQUANTITY,
                               IsEnabled = r.ENABLE
                           }).FirstOrDefault();
            if (reservation == null)
            {
                //throw new Exception("No reservation found with this id.");
            }
            return reservation;
        }

        /// <summary>
        /// Delete given reservation
        /// </summary>
        /// <param name="reservation"></param>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        public bool DeleteReservation(Reservation reservation)
        {
            this.RefreshDataSet();

            int nbrRowsDeleted = -1;
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.RESERVATIONTableAdapter daReservation = new Model.DataSetRestoBookTableAdapters.RESERVATIONTableAdapter())
            {
                nbrRowsDeleted = daReservation.Delete(reservation.Id,
                                                      reservation.CustomerId,
                                                      reservation.ServiceId,
                                                      reservation.ReservationDate,
                                                      reservation.Service,
                                                      reservation.PlaceQuantity,
                                                      reservation.RestoConfirmation,
                                                      reservation.RestoConfirmationDate,
                                                      reservation.RestoComments,
                                                      reservation.IsEnabled);
            }
            return nbrRowsDeleted > 0;
        }

        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Refreshes the dataset, so that the new data from database becomes available.
        /// </summary>
        private void RefreshDataSet()
        {
            // refresh the dataset
            this.dp.ds.Reset();
            this.dp.PrepareFullReservation();
        }
        #endregion PRIVATE METHODS

    }
}
