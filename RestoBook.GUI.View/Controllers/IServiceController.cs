using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.GUI.View.Controllers
{
    public interface IServiceController
    {
        /// <summary>
        /// Gets a dictionary of Services from a restaurant ID.
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        Dictionary<int, string> GetServiceDictionary(int restaurantId);

        /// <summary>
        /// Gets a service by it's ID.
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        Service GetServiceById(int serviceId);

    }
}
