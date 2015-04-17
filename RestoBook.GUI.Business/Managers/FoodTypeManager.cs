using RestoBook.Common.Model;
using RestoBook.Common.Model.Models;
using RestoBook.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Common.Business.Managers
{
    /// <summary>
    /// The foodtype manager.
    /// </summary>
    public class FoodTypeManager : IFoodTypeManager
    {
        
        #region PROPERTIES
        private DataProvider dp;
        #endregion PROPERTIES


        #region CONSTRUCTOR
        public FoodTypeManager()
        {
            this.dp = new DataProvider();
            this.dp.PrepareFoodTypeDP();
        }
        #endregion CONSTRUCTOR


        #region PUBLIC METHODS
        /// <summary>
        /// Gets the type of food for a restaurant.
        /// </summary>
        /// <param name="foodTypeId">The foodtype identifier.</param>
        /// <returns>The FoodType for a restaurant.</returns>
        public FoodType GetFoodTypeById(int foodTypeId)
        {
            var res = this.dp.ds.FOODTYPE.Where(ft => ft.FOODTYPEID == foodTypeId).FirstOrDefault();
            // if previously searched res is null, return a null object,
            // else create a new foodtype object and return it.
            return res == null ? null : new FoodType()
            {
                Id = (int)res.FOODTYPEID,
                Description = res.DESCRIPTION,
                IsEnabled = res.ENABLE,
                Name = res.NAME
            };
        }
        #endregion PUBLIC METHODS

    }
}
