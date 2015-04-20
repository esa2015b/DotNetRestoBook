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

        public List<FoodType> GetFoodTypeList()
        {
            List<FoodType> foodType = new List<FoodType>();

            var query = from f in this.dp.ds.FOODTYPE
                        select f;

            query.ToList().ForEach(ft => foodType.Add(new FoodType()
            {
                Id = (int)ft.FOODTYPEID,
                Name = ft.NAME,
                Description = ft.DESCRIPTION,
                IsEnabled = ft.ENABLE

            }));
            return foodType;
        }

        
        public FoodType CreateFoodType(FoodType ft)
        {
            FoodType foodType = new FoodType();

            DataRow row = this.dp.ds.FOODTYPE.NewRow();
            row["NAME"] = ft.Name;
            row["DESCRIPTION"] = ft.Description;
            row["ENABLE"] = true;
            this.dp.ds.FOODTYPE.Rows.Add(row);

            if (row != null)
            {
                foodType = ft;
                foodType.Id = (int)row["FOODTYPEID"];
            }

            return foodType;

        }

        
        public Boolean DeleteFoodType(int id)
        {
            bool delete = false;
            DataRow row = dp.ds.FOODTYPE.Select("FOODTYPEID = '" + id + "'").FirstOrDefault();

            if (row != null) 
            {
                // TODO : Soft Delete.
                dp.ds.FOODTYPE.Rows.Remove(row);
                delete = true;
            }

            return delete;
        }


        public FoodType ModifyFoodTypeType(FoodType ft)
        {
            DataRow row = dp.ds.FOODTYPE.Select("FOODTYPEID = '" + ft.Id + "'").FirstOrDefault();

            row["NAME"] = ft.Name;
            row["DESCRIPTION"] = ft.Description;
            row["ENABLED"] = ft.IsEnabled;
            
            FoodType foodtype = GetFoodTypeById(ft.Id);
            return foodtype;
        }

        #endregion PUBLIC METHODS

    }
}
