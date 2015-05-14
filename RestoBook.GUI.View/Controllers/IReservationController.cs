using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.GUI.View.Controllers
{
    /// <summary>
    /// The reservation view controller interface.
    /// </summary>
    public interface IReservationController
    {
        /// <summary>
        /// Delete given reservation
        /// </summary>
        /// <param name="reservation"></param>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        bool DeleteReservation(Reservation reservation);

        /// <summary>
        /// Create given reservaton
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        bool CreateReservation(Reservation reservation);

        /// <summary>
        /// Gets a reservation by it's id
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns></returns>
        Reservation GetReservationById(int reservationId);

    }
}
