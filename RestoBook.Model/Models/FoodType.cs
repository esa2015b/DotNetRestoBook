using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Common.Model.Models
{
    /// <summary>
    /// The type of food served at a restaurant.
    /// </summary>
    [DataContract()]
    public class FoodType
    {
        public FoodType()
        {
            this.Name = string.Empty;
            this.Description = string.Empty;
        }

        #region OLD PROPERTIES
        //public int Id { get; set; }

        //public string Name { get; set; }

        //public string Description { get; set; }

        //public bool Enable { get; set; }
        #endregion OLD PROPERTIES

        #region PROPERTIES

        /// <summary>
        /// The foodtype's identifier.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int Id { get; set; }

        /// <summary>
        /// The foodtype's name.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        /// <summary>
        /// The foodtype's description.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Description { get; set; }

        /// <summary>
        /// Is the foodtype still active?
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool IsEnabled { get; set; }
        #endregion PROPERTIES
    }
}
