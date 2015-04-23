using RestoBook.Common.Model;
using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Creates a new address.
        /// </summary>
        /// <param name="address">The address to create.</param>
        /// <param name="restaurantid">For which restaurant is the address?</param>
        /// <returns>True in case of successful update, false in case of failure.</returns>
        public bool CreateAddres(Address address, int restaurantid)
        {
            int nbrRowsCreated = -1;
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.ADDRESSTableAdapter daAddress = new Model.DataSetRestoBookTableAdapters.ADDRESSTableAdapter())
            {
                nbrRowsCreated = daAddress.Insert(address.Id,
                                                  restaurantid,
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

        #endregion PUBLIC METHODS
    }
}
