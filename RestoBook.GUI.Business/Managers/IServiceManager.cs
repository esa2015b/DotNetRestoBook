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

        /// <summary>
        /// Creates a new service row.
        /// </summary>
        /// <param name="service">The service row to create.</param>
        /// <param name="restaurantId">The service's restaurant identifier.</param>
        /// <returns>True in case of successful update, false in case of failure.</returns>
        bool CreateService(Service service, int restaurantId);

    }
}
