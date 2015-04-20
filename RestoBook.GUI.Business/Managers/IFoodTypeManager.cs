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
        
        /// <summary>
        /// Get all Food Types
        /// </summary>
        /// <returns></returns>
        List<FoodType> GetFoodTypeList();

        /// <summary>
        /// Create a new Food Type
        /// </summary>
        /// <param name="ft"></param>
        /// <returns></returns>
        FoodType CreateFoodType (FoodType ft);

        /// <summary>
        /// Delete a Food Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Boolean DeleteFoodType (int id);

        /// <summary>
        /// Modify a Food Type
        /// </summary>
        /// <param name="ft"></param>
        /// <returns></returns>
        FoodType ModifyFoodTypeType(FoodType ft);

    }
}
