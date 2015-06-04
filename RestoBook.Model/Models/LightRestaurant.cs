using System.Runtime.Serialization;

namespace RestoBook.Common.Model.Models
{
    /// <summary>
    /// The light restaurant class, containing 5 attributes for display purpose.
    /// </summary>
    [DataContract()]
    public class LightRestaurant
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
        public string Name { get; set; }

        /// <summary>
        /// The description.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Description { get; set; }

        /// <summary>
        /// The restaurant's city.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string City { get; set; }

        /// <summary>
        /// The restaurant's picture location.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string PictureLocation { get; set; }

        /// <summary>
        /// The restaurant's food type name.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string FoodTypeName { get; set; }

        /// <summary>
        /// The food type id.
        /// </summary>
        public int FoodTypeId { get; set; }

        /// <summary>
        /// Is the restaurant still active?
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool IsEnabled { get; set; }

        #endregion PROPERTIES
    }
}
