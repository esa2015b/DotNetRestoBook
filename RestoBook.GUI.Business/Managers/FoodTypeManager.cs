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

            // refresh the dataset
            this.dp.ds.Reset();
            this.dp.PrepareFoodTypeDP();

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

        
        public bool CreateFoodType(FoodType ft)
        {
            int ftId = -1;
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.FOODTYPETableAdapter daFoodType = new RestoBook.Common.Model.DataSetRestoBookTableAdapters.FOODTYPETableAdapter())
            {
                ftId = daFoodType.Insert(ft.Name, ft.Description, true);
            }
            return ft.Id == ftId;
        }

        
        public bool DeleteFoodType(FoodType ft)
        {
            int deletedFoodTypeId = -1;
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.FOODTYPETableAdapter daFoodType = new RestoBook.Common.Model.DataSetRestoBookTableAdapters.FOODTYPETableAdapter())
            {
                deletedFoodTypeId = daFoodType.Delete(ft.Id, ft.Name, ft.Description, ft.IsEnabled);
            }
            return ft.Id == deletedFoodTypeId;
        }


        public bool ModifyFoodTypeType(FoodType ft)
        {
            int ftId = -1;
            DataRow row = dp.ds.FOODTYPE.Select("FOODTYPEID = '" + ft.Id + "'").FirstOrDefault();
            row["NAME"] = ft.Name;
            row["DESCRIPTION"] = ft.Description;
            row["ENABLE"] = ft.IsEnabled;
            
            //FoodType foodtype = GetFoodTypeById(ft.Id);
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.FOODTYPETableAdapter daFoodType = new RestoBook.Common.Model.DataSetRestoBookTableAdapters.FOODTYPETableAdapter())
            {
                ftId = daFoodType.Update(row);
            }
            return ft.Id == ftId;
        }

        #endregion PUBLIC METHODS

    }
}
