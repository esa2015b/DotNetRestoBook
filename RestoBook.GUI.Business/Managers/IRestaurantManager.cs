using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RestoBook.Common.Model.Models;

namespace RestoBook.Common.Business.Managers
{
    /// <summary>
    /// The restaurantmanager's interface.
    /// Every Manager has one Interface, for testing purpose and loose coupling purpose.
    /// </summary>
    public interface IRestaurantManager
    {
        /// <summary>
        /// Loads a restaurant by searching for the given restaurant id.
        /// </summary>
        /// <param name="restoId">The restaurant identifier.</param>
        /// <returns>The restaurant.</returns>
        Restaurant GetRestaurantById(int restoId);

        DataSet GetAllRestaurants();

    }
}
