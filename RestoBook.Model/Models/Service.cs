using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RestoBook.Common.Model.Models
{
    /// <summary>
    /// A service for a restaurant. Contains all the details for a given service/shift (day and timeshift).
    /// </summary>    
    [DataContract()]
    public class Service
    {
        #region PROPERTIES
        /// <summary>
        /// The Service identifier.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int Id { get; set; }

        /// <summary>
        /// The service datetime
        /// </summary>
        [DataMember(IsRequired = true)]
        public DateTime ServiceDate { get; set; }

        /// <summary>
        /// The service day
        /// </summary>
        [DataMember(IsRequired = true)]
        public DayOfWeek ServiceDay { get; set; }

        /// <summary>
        /// The type of the service.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string TypeService { get; set; }

        /// <summary>
        /// The service shift's begin time.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int BeginShift { get; set; }

        /// <summary>
        /// The service shift's end time.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int EndShift { get; set; }

        /// <summary>
        /// The number of available places for this shift.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int PlaceQuantity { get; set; }

        /// <summary>
        /// Is the service still active?
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// The list of reservation for this service
        /// </summary>
        [DataMember(IsRequired = true)]
        public List<Reservation> Reservations { get; set; }

        #endregion PROPERTIES

    }
}
