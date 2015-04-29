﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace RestoBook.Common.Model.Models
{
    /// <summary>
    /// A reservation
    /// </summary>
    [DataContract()]
    public class Reservation
    {
        #region PROPERTIES
        /// <summary>
        /// Reservation's id
        /// </summary>
        [DataMember(IsRequired = true)]
        public int Id { get; set; }

        /// <summary>
        /// Reservation's date.
        /// Ideally the resto confirmation must be sent into 24 hours
        /// </summary>
        [DataMember(IsRequired = true)]
        public DateTime ReservationDate { get; set; }

        /// <summary>
        /// Number of place reserved
        /// </summary>
        [DataMember(IsRequired = true)]
        public int PlaceQuantity { get; set; }

        /// <summary>
        /// Is this reservation confirmed ?
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool RestoConfirmation { get; set; }

        /// <summary>
        /// Date of confirmation
        /// ideally in 24 hours of reservation date
        /// </summary>
        [DataMember(IsRequired = true)]
        public DateTime RestoCofirmationDate { get; set; }

        /// <summary>
        /// Comments from restaurant for this reservation
        /// </summary>
        [DataMember(IsRequired = true)]
        public string RestoComments { get; set; }

        /// <summary>
        /// Is this reservation always available ?
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool IsEnabled { get; set; }

        #endregion

    }
}