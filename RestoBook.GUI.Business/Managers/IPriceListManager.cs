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
    }
}
