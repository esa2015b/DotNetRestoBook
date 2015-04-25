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
            this.RefreshDataSet();
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

        /// <summary>
        /// Creates a new pricelist for a given restaurant.
        /// </summary>
        /// <param name="priceList">The pricelist to create.</param>
        /// <param name="restaurantId">The pricelist's restaurant.</param>
        /// <returns>True in case of successful update, false in case of failure.</returns>
        public bool CreatePriceList(PriceList priceList, int restaurantId)
        {
            int nbrRowsCreated = -1;
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.PRICELISTTableAdapter daPriceList = new RestoBook.Common.Model.DataSetRestoBookTableAdapters.PRICELISTTableAdapter())
            {
                nbrRowsCreated = daPriceList.Insert(restaurantId,
                                                    priceList.Description,
                                                    priceList.MinimumPrice,
                                                    priceList.MaximumPrice,
                                                    priceList.IsEnabled);
            }
            return nbrRowsCreated > 0;
        }

        /// <summary>
        /// Deletes a pricelist for a given restaurant.
        /// </summary>
        /// <param name="priceList">The pricelist to delete.</param>
        /// <param name="restaurantId">The pricelist's restaurant identifier.</param>
        /// <returns>True in case of successful delete, false in case of failure.</returns>
        public bool DeletePriceList(PriceList priceList, int restaurantId)
        {
            int nbrRowsDeleted = -1;
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.PRICELISTTableAdapter daPriceList = new RestoBook.Common.Model.DataSetRestoBookTableAdapters.PRICELISTTableAdapter())
            {
                nbrRowsDeleted = daPriceList.Delete(priceList.Id,
                                                    restaurantId,
                                                    priceList.Description,
                                                    priceList.MinimumPrice,
                                                    priceList.MaximumPrice,
                                                    priceList.IsEnabled);
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
            this.dp.PreparePriceListDP();
        }
        #endregion PRIVATE METHODS

    }
}
