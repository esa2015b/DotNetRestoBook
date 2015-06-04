using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RestoBook.Common.Model.Models
{
    /// <summary>
    /// The full restaurant class, containing all the items related to a restaurant.
    /// </summary>
    [DataContract()]
    public class Restaurant
    {
        #region OLD PROPERTIES
        /// <summary>
        /// The restaurant identifier.
        /// </summary>
        //public int Id { get; set; }

        //public string Name { get; set; }

        //public string Mail { get; set; }

        //public string Phone { get; set; }

        //public string Description { get; set; }

        //public int PlaceQuantity { get; set; }

        //public string DayOfClosing { get; set; }

        //public string PictureLocation { get; set; }

        //public bool IsEnable {get;set;}
        
        //public bool IsPremium { get; set; }

        //public FoodType FoodType { get; set; }

        //public Owner Owner { get; set; }
        
        //public Address Address { get; set; }

        //public Employee Employee { get; set; }
        
        //public List<PriceList> Prices { get; set; }

        //public List<Service> Services { get; set; }
        #endregion OLD PROPERTIES

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
        /// The contact email.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Mail { get; set; }

        /// <summary>
        /// The contact telephone.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Phone { get; set; }

        /// <summary>
        /// The description.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Description { get; set; }

        /// <summary>
        /// The number of available places.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int PlaceQuantity { get; set; }

        /// <summary>
        /// The day of closing.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string DayOfClosing { get; set; }

        /// <summary>
        /// The restaurant's picture location.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string PictureLocation { get; set; }

        /// <summary>
        /// Is the restaurant still active?
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Is the restaurant a premium member?
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool IsPremium { get; set; }

        /// <summary>
        /// The type of food served in the restaurant.
        /// </summary>
        [DataMember(IsRequired = true)]
        public FoodType FoodType { get; set; }

        /// <summary>
        /// The restaurant's employees.
        /// </summary>
        [DataMember(IsRequired = true)]
        public List<Employee> Employees { get; set; }

        /// <summary>
        /// The restaurant's pricelists.
        /// </summary>
        [DataMember(IsRequired = true)]
        public List<PriceList> PriceLists { get; set; }

        /// <summary>
        /// The list of services.
        /// </summary>
        [DataMember(IsRequired = true)]
        public List<Service> Services { get; set; }

        /// <summary>
        /// The restaurant's owner.
        /// </summary>
        [DataMember(IsRequired = true)]
        public Owner Owner { get; set; }

        /// <summary>
        /// The restaurant's address.
        /// </summary>
        [DataMember(IsRequired = true)]
        public List<Address> Addresses { get; set; }
        #endregion PROPERTIES
    }
}
