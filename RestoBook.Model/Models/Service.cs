using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Common.Model.Models
{
    /// <summary>
    /// A service for a restaurant. Contains all the details for a given service/shift (day and timeshift).
    /// </summary>    
    [DataContract()]
    public class Service
    {
        #region OLD PROPERTIES
        //public int RestaurantId {get; set; }

        //public DateTime ServiceDay { get; set; }

        //public string TypeService { get; set; }

        //public int StartShift { get; set; }

        //public int EndShift { get; set; }

        //public int PlaceQuantity { get; set; }

        //public bool Enable { get; set; }
        #endregion OLD PROPERTIES

        #region PROPERTIES
        /// <summary>
        /// The Service identifier.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int Id { get; set; }

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
        #endregion PROPERTIES

        //public Service (int restaurantid, DayOfWeek serviceday, string typeservice, int startshift, int endshift, int placequantity, bool enable)
        //{
        //    this.Id = restaurantid;
        //    this.ServiceDay = serviceday;
        //    this.TypeService = typeservice;
        //    this.BeginShift = startshift;
        //    this.EndShift = endshift;
        //    this.PlaceQuantity = placequantity;
        //    this.IsEnabled = enable;
        //}
    }
}
