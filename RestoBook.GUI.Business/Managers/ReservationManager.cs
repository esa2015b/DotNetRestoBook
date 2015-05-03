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
        
        /// <summary>
        /// Gets a list of reservation 
        /// Attention actually this methods is not using RestoConformationDate property
        /// It must be review by JLM
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns>A list of reservation</returns>
        public List<Reservation> GetReservationByService(int serviceId)
        {
            List<Reservation> reservations = (from r in dp.ds.RESERVATION
                                              where r.SERVICEID == serviceId
                                              select new Reservation()
                                              {
                                                  Id = r.RESERVATIONID,
                                                  CustomerId = r.CUSTOMERID,
                                                  ServiceId = r.SERVICEID,
                                                  ReservationDate = r.RESERVATIONDATE,
                                                  PlaceQuantity = r.PLACEQUANTITY,
                                                  RestoConfirmation = r.RESTOCONFIRMATION,
                                                  //RestoConfirmationDate = r.RESTOCONFIRMATIONDATE,
                                                  RestoComments = r.RESTOCOMMENTS
                                              }).ToList();
            return reservations;
        }

        /// <summary>
        /// Create a reservation
        /// ReservationDate equals to DateTime.Now
        /// RestoConfirmationDate is a Nullable type
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>

        public bool CreateReservation (Reservation reservation)
        {
            int nbrRowsCreated = -1;

            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.RESERVATIONTableAdapter daReservation = new Model.DataSetRestoBookTableAdapters.RESERVATIONTableAdapter())
            {
                nbrRowsCreated = daReservation.Insert(
                                                        reservation.CustomerId,
                                                        reservation.ServiceId,
                                                        reservation.ReservationDate = DateTime.Now,
                                                        reservation.Service,
                                                        reservation.PlaceQuantity,
                                                        reservation.RestoConfirmation,
                                                        reservation.RestoConfirmationDate,
                                                        reservation.RestoComments,
                                                        reservation.IsEnabled
                                                        );
            }
            return nbrRowsCreated > 0;
          }

/// <summary>
/// This method allow to modify a reservation's properties
/// except ReservationDate, customerId and serviceId
/// A reservation must be deleted and recreated in place to modify customer or service
/// RestoConfirmationDate is a Nullable type then no need to test this value
/// </summary>
/// <param name="reservation"></param>
/// <returns>bool if creation succeed</returns>
        public bool ModifyReservation (Reservation reservation)
        {
            int nbrRowsUpdated = -1;

            DataRow row = dp.ds.RESERVATION.Select(string.Format("RESERVATIONID = '{0}'", reservation.Id)).FirstOrDefault();
            row["PLACEQUANTITY"] = reservation.PlaceQuantity;
            row["RESTOCONFIRMATION"] = reservation.RestoConfirmation;
            row["RESTOCONFIRMATIONDATE"] = reservation.RestoConfirmationDate;
            row["RESTOCOMMENTS"] = reservation.RestoComments;
            row["ENABLE"] = reservation.IsEnabled;

            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.RESERVATIONTableAdapter daReservation = new Model.DataSetRestoBookTableAdapters.RESERVATIONTableAdapter())
            {
                nbrRowsUpdated = daReservation.Update(row);
            }
            return nbrRowsUpdated > 0;
        }

        #region PRIVATE METHODS
        /// <summary>
        /// Refreshes the dataset, so that the new data from database becomes available.
        /// </summary>
        private void RefreshDataSet()
        {
            // refresh the dataset
            this.dp.ds.Reset();
            this.dp.PrepareFoodTypeDP();
        }
        #endregion PRIVATE METHODS

    }
}
