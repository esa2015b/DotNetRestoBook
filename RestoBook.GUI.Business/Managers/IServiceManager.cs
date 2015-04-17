using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Common.Business.Managers
{
    /// <summary>
    /// The servicemanager interface.
    /// </summary>
    public interface IServiceManager
    {
        /// <summary>
        /// Gets a list of services linked to the restaurant.
        /// </summary>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>A list of services.</returns>
        List<Service> GetServices(int restaurantId);
    }
}
