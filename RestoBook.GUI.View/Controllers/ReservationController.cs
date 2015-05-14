using RestoBook.Common.Business.Managers;
using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.GUI.View.Controllers
{
    /// <summary>
    /// The reservation view controller.
    /// </summary>
    public class ReservationController
    {
        #region PROPERTIES
        private ReservationManager reservationManager;
        #endregion PROPERTIES


        #region CONSTRUCTOR
        public ReservationController()
        {
            this.reservationManager = new ReservationManager();
        }
        #endregion CONSTRUCTOR


        #region PUBLIC METHODS

        /// <summary>
        /// Create given reservaton
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public bool CreateReservation(Reservation reservation)
        {
            bool successful = this.reservationManager.CreateReservation(reservation);
            return successful;
        }

        /// <summary>
        /// Delete given reservation
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public bool DeleteReservation(Reservation reservation)
        {
            bool successful = this.reservationManager.DeleteReservation(reservation);
            return successful;
        }

        /// <summary>
        /// Gets a reservation by it's id
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns></returns>
        public Reservation GetReservationById(int reservationId)
        {
            return this.reservationManager.GetReservationById(reservationId);
        }


        #endregion PUBLIC METHODS
    }
}
