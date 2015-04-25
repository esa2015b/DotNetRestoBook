using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.GUI.View.Controllers
{
    /// <summary>
    /// The foodtypecontroller's interface.
    /// </summary>
    public interface IFoodTypeController
    {
        /// <summary>
        /// Gets the list of existing food types.
        /// </summary>
        /// <returns>A list of existing food type objects.</returns>
        List<FoodType> GetAllFoodTypes();

        /// <summary>
        /// Creates a FoodType object in the database.
        /// </summary>
        /// <param name="foodType">The new foodtype to create.</param>
        /// <returns>True if successful, false if failed.</returns>
        bool CreateFoodType(FoodType foodType);

        /// <summary>
        /// Modifies a given foodtype as requested.
        /// </summary>
        /// <param name="foodType">The foodtype to modify.</param>
        /// <returns>True if successful, false if failed.</returns>
        bool ModifyFoodType(FoodType foodType);

        /// <summary>
        /// Deletes a given foodtype in the database.
        /// </summary>
        /// <param name="foodTypeId">The identifier for the foodtype to delete.</param>
        /// <returns>True if successful, false if failed.</returns>
        bool DeleteFoodType(FoodType foodType);
    }
}
