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
        
        public List<Reservation> GetReservationByService(int serviceId)
        {
            List<Reservation> reservations = (from r in dp.ds.RESERVATION
                                              where r.SERVICEID == serviceId
                                              select new Reservation()
                                              {
                                                  Id = r.RESERVATIONID,
                                                  ReservationDate = r.RESERVATIONDATE,
                                                  PlaceQuantity = r.PLACEQUANTITY,
                                                  RestoConfirmation = r.RESTOCONFIRMATION,
                                                  //RestoConfirmationDate = r.RESTOCONFIRMATIONDATE,
                                                  RestoComments = r.RESTOCOMMENTS
                                              }).ToList();
            return reservations;
        }

        public bool CreateReservation (Reservation reservation)
        {
            int nbrRowsCreated = -1;

            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.RESERVATIONTableAdapter daReservation = new Model.DataSetRestoBookTableAdapters.RESERVATIONTableAdapter())
            {
                nbrRowsCreated = daReservation.Insert(
                                                        reservation.CustomerId,
                                                        reservation.ServiceId,
                                                        reservation.ReservationDate,
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


        public bool ModifyReservation (Reservation reservation)
        {
            int nbrRowsUpdated = -1;

            DataRow row = dp.ds.RESERVATION.Select(string.Format("RESERVATIONID = '{0}'", reservation.Id)).FirstOrDefault();
            row["RESERVATIONDATE"] = reservation.ReservationDate;
            row["PLACEQUANTITY"] = reservation.PlaceQuantity;
            row["RESTOCONFIRMATION"] = reservation.RestoConfirmation;
            //row["RESTOCONFIRMATIONDATE"] = reservation.RestoConfirmationDate;
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
