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
        /// 
        /// </summary>
        /// <param name="foodType"></param>
        /// <returns></returns>
        bool CreateFoodType(FoodType foodType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="foodType"></param>
        /// <returns></returns>
        bool ModifyFoodType(FoodType foodType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="foodTypeId"></param>
        /// <returns></returns>
        bool DeleteFoodType(FoodType foodType);
    }
}
