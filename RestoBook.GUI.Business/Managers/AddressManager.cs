using RestoBook.Common.Model;
using RestoBook.Common.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestoBook.Common.Business.Managers
{
    /// <summary>
    /// The address manager.
    /// </summary>
    public class AddressManager : IAddressManager
    {

        #region PROPERTIES
        private DataProvider dp;
        #endregion PROPERTIES


        #region CONSTRUCTOR
        public AddressManager()
        {
            this.dp = new DataProvider();
            this.dp.PrepareAddressDP();

        }
        #endregion CONSTRUCTOR


        #region PUBLIC METHODS
        /// <summary>
        /// Gets a list of the restaurant's addresses by the restaurant's identifier.
        /// </summary>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>The list of restaurant's addresses.</returns>
        public List<Address> GetAddressesByRestaurantId(int restaurantId)
        {
            this.RefreshDataSet();
            List<Address> addresses = new List<Address>();
            var tempAddress = this.dp.ds.ADDRESS.Where(a => a.RESTAURANTID == restaurantId).ToList();
            tempAddress.ForEach(a =>  addresses.Add(new Address()
                        {
                            City = a.CITY,
                            Country = a.COUNTRY,
                            HeadOffice = a.HEADOFFICE,
                            Id = a.ADDRESSID,
                            IsEnabled = a.ENABLE,
                            Number = a.NUMBER,
                            Street = a.STREET,
                            ZipCode = a.ZIPCODE
                        }));
            return addresses;
        }

        /// <summary>
        /// Creates a new address.
        /// </summary>
        /// <param name="address">The address to create.</param>
        /// <param name="restaurantId">For which restaurant is the address?</param>
        /// <returns>True in case of successful update, false in case of failure.</returns>
        public bool CreateAddres(Address address, int restaurantId)
        {
            int nbrRowsCreated = -1;
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.ADDRESSTableAdapter daAddress = new Model.DataSetRestoBookTableAdapters.ADDRESSTableAdapter())
            {
                nbrRowsCreated = daAddress.Insert(restaurantId,
                                                  address.Street,
                                                  address.Number,
                                                  address.ZipCode,
                                                  address.City,
                                                  address.Country,
                                                  address.HeadOffice,
                                                  address.IsEnabled);
            }
            return nbrRowsCreated > 0;
        }

        /// <summary>
        /// Deletes an address.
        /// </summary>
        /// <param name="address">The address to delete.</param>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>True in case of successful update, false in case of failure.</returns>
        public bool DeleteAddress(Address address, int restaurantId)
        {
            int nbrRowsDeleted = -1;
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.ADDRESSTableAdapter daAddress = new Model.DataSetRestoBookTableAdapters.ADDRESSTableAdapter())
            {
                nbrRowsDeleted = daAddress.Delete(address.Id,
                                                  restaurantId,
                                                  address.Street,
                                                  address.Number,
                                                  address.ZipCode,
                                                  address.City,
                                                  address.Country,
                                                  address.HeadOffice,
                                                  address.IsEnabled);
            }
            return nbrRowsDeleted > 0;
        }

        #endregion PUBLIC METHODS


        #region PRIVATE METHODS
        /// <summary>
        /// Refreshes the dataset, so that the new data from database becomes available.
        /// </summary>
        private void RefreshDataSet()
        {
            // refresh the dataset
            this.dp.ds.Reset();
            this.dp.PrepareAddressDP();
        }
        #endregion PRIVATE METHODS

    }
}
