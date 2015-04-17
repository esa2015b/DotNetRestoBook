using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Common.Business.Managers
{
    /// <summary>
    /// The ownermanager interface.
    /// </summary>
    public interface IOwnerManager
    {
        /// <summary>
        /// Gets the owner of a restaurant.
        /// </summary>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>The owner of a restaurant.</returns>
        Owner GetOwner(int restaurantId);
    }
}
