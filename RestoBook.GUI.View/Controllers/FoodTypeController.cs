using RestoBook.Common.Business.Managers;
using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.GUI.View.Controllers
{
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

        public bool CreateFoodType(FoodType foodType)
        {
            bool result = this.foodTypeManager.CreateFoodType(foodType);
            // if the object has been created successfully, the foodtype
            // id should be higher than 0.
            return result;
        }

        public bool ModifyFoodType(FoodType foodType)
        {
            bool result = this.foodTypeManager.ModifyFoodTypeType(foodType);
            return result;
        }

        public bool DeleteFoodType(FoodType foodType)
        {
            bool result = this.foodTypeManager.DeleteFoodType(foodType);
            return result;
        }
        #endregion PUBLIC METHODS
    }
}
