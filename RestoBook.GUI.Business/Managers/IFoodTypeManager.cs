using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Common.Business.Managers
{
    /// <summary>
    /// The food type manager's interface.
    /// </summary>
    public interface IFoodTypeManager
    {
        /// <summary>
        /// Gets the type of food for a restaurant.
        /// </summary>
        /// <param name="foodTypeId">The foodtype identifier.</param>
        /// <returns>The FoodType for a restaurant.</returns>
        FoodType GetFoodTypeById(int foodTypeId);
    }
}
