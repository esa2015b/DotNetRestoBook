using RestoBook.Common.Model;
using RestoBook.Common.Model.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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
            this.RefreshDataSet();

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

        /// <summary>
        /// Get all Food Types
        /// </summary>
        /// <returns></returns>
        public List<FoodType> GetFoodTypeList()
        {
            List<FoodType> foodType = new List<FoodType>();
            this.RefreshDataSet();

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

        /// <summary>
        /// Creates a new Food Type
        /// </summary>
        /// <param name="ft">The foodtype to insert in the database.</param>
        /// <returns>True in case of successful creation, false in case of failure.</returns>
        public bool CreateFoodType(FoodType ft)
        {
            int nbrRowsCreated = -1;
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.FOODTYPETableAdapter daFoodType = new RestoBook.Common.Model.DataSetRestoBookTableAdapters.FOODTYPETableAdapter())
            {
                nbrRowsCreated = daFoodType.Insert(ft.Name, ft.Description, true);
            }
            return nbrRowsCreated > 0;
        }

        /// <summary>
        /// Delete a Food Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFoodType(FoodType ft)
        {
            int nbrRowsDeleted = -1;
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.FOODTYPETableAdapter daFoodType = new RestoBook.Common.Model.DataSetRestoBookTableAdapters.FOODTYPETableAdapter())
            {
                nbrRowsDeleted = daFoodType.Delete(ft.Id, ft.Name, ft.Description, ft.IsEnabled);
            }
            return nbrRowsDeleted > 0;
        }

        /// <summary>
        /// Modify a Food Type
        /// </summary>
        /// <param name="ft"></param>
        /// <returns></returns>
        public bool ModifyFoodType(FoodType ft)
        {
            int nbrRowsUpdated = -1;
            DataRow row = dp.ds.FOODTYPE.Select("FOODTYPEID = '" + ft.Id + "'").FirstOrDefault();
            row["NAME"] = ft.Name;
            row["DESCRIPTION"] = ft.Description;
            row["ENABLE"] = ft.IsEnabled;
            
            //FoodType foodtype = GetFoodTypeById(ft.Id);
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.FOODTYPETableAdapter daFoodType = new RestoBook.Common.Model.DataSetRestoBookTableAdapters.FOODTYPETableAdapter())
            {
                nbrRowsUpdated = daFoodType.Update(row);
            }
            return nbrRowsUpdated > 0;
        }

        #endregion PUBLIC METHODS


        #region PRIVATE METHODS
        /// <summary>
        /// Refreshes the dataset, so that the new data from database becomes available.
        /// </summary>
        private void RefreshDataSet()
        {
            // refresh the dataset
            this.dp.ds.Reset();
            this.dp.PrepareFoodTypeDP();
        }
        #endregion PRIVATE METHODS
    }
}
