using System.Runtime.Serialization;

namespace RestoBook.Common.Model.Models
{
    /// <summary>
    /// The pricelist for a given restaurant, for a given timespan.
    /// </summary>
    [DataContract()]
    public class PriceList
    {
        #region OLD PROPERTIES
        //public int PriceListId {get; set;}

        //public string Description { get; set; }

        //public int MinimumPrice { get; set; }

        //public int MaximumPrice { get; set; }

        //public bool Enable { get; set; }
        #endregion OLD PROPERTIES

        #region PROPERTIES
        /// <summary>
        /// The pricelist's identifier.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int Id { get; set; }

        /// <summary>
        /// The pricelist's description.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Description { get; set; }

        /// <summary>
        /// The pricelist's minimumprice (starting price).
        /// </summary>
        [DataMember(IsRequired = true)]
        public int MinimumPrice { get; set; }

        /// <summary>
        /// The pricelist's maximumprice (ending price).
        /// </summary>
        [DataMember(IsRequired = true)]
        public int MaximumPrice { get; set; }

        /// <summary>
        /// Is the pricelist still active?
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool IsEnabled { get; set; }
        #endregion PROPERTIES

    }
}
