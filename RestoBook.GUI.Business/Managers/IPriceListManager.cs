using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Common.Business.Managers
{
    /// <summary>
    /// The pricelistmanager interface.
    /// </summary>
    public interface IPriceListManager
    {
        /// <summary>
        /// Gets the pricelists of a certain restaurant.
        /// </summary>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>A list of pricelists.</returns>
        List<PriceList> GetPriceLists(int restaurantId);

        /// <summary>
        /// Creates a new pricelist for a given restaurant.
        /// </summary>
        /// <param name="priceList">The pricelist to create.</param>
        /// <param name="restaurantId">The pricelist's restaurant.</param>
        /// <returns>True in case of successful update, false in case of failure.</returns>
        bool CreatePriceList(PriceList priceList, int restaurantId);
    }
}
