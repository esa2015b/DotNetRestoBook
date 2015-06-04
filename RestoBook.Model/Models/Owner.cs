using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RestoBook.Common.Model.Models
{
    /// <summary>
    /// The owner of a/several restaurants.
    /// </summary>
    [DataContract()]
    public class Owner
    {
        #region OLD PROPERTIES
        //public int Id { get; set; }

        //public string FirstName { get; set; }

        //public string LastName { get; set; }

        //public bool Enable { get; set; }
        #endregion OLD PROPERTIES

        #region PROPERTIES
        /// <summary>
        /// The owner's identifier.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int Id { get; set; }

        /// <summary>
        /// The owner's first name.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string FirstName { get; set; }

        /// <summary>
        /// The owner's last name.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string LastName { get; set; }

        /// <summary>
        /// Is the owner still active.
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// The owner's restaurants.
        /// </summary>
        [DataMember(IsRequired = true)]
        public List<Restaurant> OwnedRestaurants { get; set; }
        #endregion PROPERTIES

    }
}
