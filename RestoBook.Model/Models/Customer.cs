﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace RestoBook.Common.Model.Models
{
    /// <summary>
    /// Customer who've made a reservation 
    /// </summary>
    [DataContract()]
    class Customer
    {
        /// <summary>
        /// Customer Id
        /// </summary>
        [DataMember(IsRequired = true)]
        public int Id { get; set; }

        /// <summary>
        /// Customer's mail
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Mail { get; set; }

        /// <summary>
        /// Customer's phone
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Phone { get; set; }

        /// <summary>
        /// Is customer active ?
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool IsEnable { get; set; }

        /// <summary>
        /// List of reservation made by this customer
        /// </summary>
        [DataMember(IsRequired = true)]
        public List<Reservation> Reservation { get; set; }
    }
}