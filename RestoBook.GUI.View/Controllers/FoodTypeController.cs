using RestoBook.Common.Business.Managers;
using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.GUI.View.Controllers
{
    /// <summary>
    /// The foodtype controller, to pass information between the views and the business logic layer.
    /// </summary>
    public class FoodTypeController : IFoodTypeController
    {
        #region PROPERTIES
        private FoodTypeManager foodTypeManager;
        #endregion PROPERTIES

        #region CONSTRUCTOR
        public FoodTypeController()
        {
            this.foodTypeManager = new FoodTypeManager();
        }
        #endregion CONSTRUCTOR

        #region PUBLIC METHODS
        /// <summary>
        /// Gets the list of existing food types.
        /// </summary>
        /// <returns>A list of existing food type objects.</returns>
        public List<FoodType> GetAllFoodTypes()
        {
            return this.foodTypeManager.GetFoodTypeList();
        }

        /// <summary>
        /// Creates a FoodType object in the database.
        /// </summary>
        /// <param name="foodType">The new foodtype to create.</param>
        /// <returns>True if successful, false if failed.</returns>
        public bool CreateFoodType(FoodType foodType)
        {
            bool result = this.foodTypeManager.CreateFoodType(foodType);
            // if the object has been created successfully, the foodtype
            // id should be higher than 0.
            return result;
        }

        /// <summary>
        /// Modifies a given foodtype as requested.
        /// </summary>
        /// <param name="foodType">The foodtype to modify.</param>
        /// <returns>True if successful, false if failed.</returns>
        public bool ModifyFoodType(FoodType foodType)
        {
            bool result = this.foodTypeManager.ModifyFoodType(foodType);
            return result;
        }

        /// <summary>
        /// Deletes a given foodtype in the database.
        /// </summary>
        /// <param name="foodTypeId">The identifier for the foodtype to delete.</param>
        /// <returns>True if successful, false if failed.</returns>
        public bool DeleteFoodType(FoodType foodType)
        {
            bool result = this.foodTypeManager.DeleteFoodType(foodType);
            return result;
        }
        #endregion PUBLIC METHODS
    }
}
