using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Common.Model.Models
{
    /// <summary>
    /// The restaurant's address.
    /// </summary>
    public class Address
    {
        #region PROPERTIES
        /// <summary>
        /// The restaurant's identifier.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int Id { get; set; }

        /// <summary>
        /// The restaurant's name.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string City { get; set; }

        /// <summary>
        /// The contact email.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Number { get; set; }

        /// <summary>
        /// The contact telephone.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string ZipCode { get; set; }

        /// <summary>
        /// The description.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Street { get; set; }

        /// <summary>
        /// The number of available places.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Country { get; set; }


        /// <summary>
        /// Is the restaurant still active?
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool HeadOffice { get; set; }

        /// <summary>
        /// Is the restaurant still active?
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool IsEnabled { get; set; }

        #endregion PROPERTIES
    }
}
