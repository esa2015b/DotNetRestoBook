using RestoBook.Common.Model;
using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Common.Business.Managers
{
    /// <summary>
    /// The Pricelistmanager, deals with the pricelists related to a restaurant.
    /// </summary>
    public class PriceListManager : IPriceListManager
    {
        #region PROPERTIES
        ///// <summary>
        ///// The restobook database connection string.
        ///// </summary>
        //private string connString;

        ///// <summary>
        ///// The connection helper, for database interaction purpose.
        ///// </summary>
        //private ConnectionHelper connHelper;

        private DataProvider dp;
        #endregion PROPERTIES


        #region CONSTRUCTOR
        public PriceListManager()
        {
            this.dp = new DataProvider();
            this.dp.PreparePriceListDP();
        }
        #endregion CONSTRUCTOR


        #region PUBLIC METHODS
        /// <summary>
        /// Gets the pricelists of a certain restaurant.
        /// </summary>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>A list of pricelists.</returns>
        public List<PriceList> GetPriceLists(int restaurantId)
        {
            List<PriceList> priceLists = new List<PriceList>();
            this.dp.ds.PRICELIST.Where(pl => pl.RESTAURANTID == restaurantId)
                                .ToList()
                                .ForEach(pl => priceLists.Add(new PriceList() 
                                                                { 
                                                                    Description = pl.DESCRIPTION, 
                                                                    Id = (int)pl.PRICELISTID, 
                                                                    IsEnabled = pl.ENABLE,
                                                                    MaximumPrice = (int)pl.MAXIMUMPRICE,
                                                                    MinimumPrice = (int)pl.MINIMUMPRICE
                                                                }));


            return priceLists;
        }
        #endregion PUBLIC METHODS

    }
}
