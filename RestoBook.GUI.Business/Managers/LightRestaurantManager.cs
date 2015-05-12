using RestoBook.Common;
using RestoBook.Common.Model;
using RestoBook.Common.Model.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System;

namespace RestoBook.Common.Business.Managers
{
    public class LightRestaurantManager : ILightRestaurantManager
    {
        #region PROPERTIES
        DataProvider dp;
        #endregion PROPERTIES


        #region CONSTRUCTOR
        public LightRestaurantManager()
        {
            this.dp = new DataProvider();
            this.dp.PrepareRestaurantDP();
            this.dp.PrepareFoodTypeDP();
        }
        #endregion CONSTRUCTOR


        #region PUBLIC METHODS

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restaurantName"></param>
        /// <returns></returns>
        public List<LightRestaurant> GetLightRestaurantByName(String restaurantName)
        {
            this.RefreshDataSet();
            List<LightRestaurant> restaurants = new List<LightRestaurant>();

            restaurants = (from r in this.dp.ds.RESTAURANT
                         where r.NAME.ToLower().Contains(restaurantName.ToLower())
                           join f in this.dp.ds.FOODTYPE on r.FOODTYPEID equals f.FOODTYPEID
                         select new LightRestaurant()
                         {
                             Id = (int)r.RESTAURANTID,
                             Name = r.NAME,
                             Description = r.DESCRIPTION,
                             IsEnabled = r.ENABLE,
                             PictureLocation = r.PICTURELOCATION,
                             FoodTypeId = f.FOODTYPEID,
                             FoodTypeName = f.NAME
                         }).ToList();

            if (restaurants == null)
            {
                throw new Exception("No restaurant found with this name.");
            }
            return restaurants;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="foodTypeName"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        public List<LightRestaurant> GetLightRestaurantAdvanced(string name, string foodTypeName, string city)
        {
            this.RefreshDataSet();
            List<LightRestaurant> restaurants = new List<LightRestaurant>();

            restaurants = (from r in this.dp.ds.RESTAURANT
                           where r.NAME.ToLower().Contains(name.ToLower())
                           join f in this.dp.ds.FOODTYPE on r.FOODTYPEID equals f.FOODTYPEID
                           where f.NAME.ToLower().Contains(foodTypeName)
                           join a in this.dp.ds.ADDRESS on r.RESTAURANTID equals a.RESTAURANTID
                           where a.CITY.ToLower().Contains(city) || a.ZIPCODE.ToLower().Contains(city)
                           select new LightRestaurant()
                           {
                               Id = (int)r.RESTAURANTID,
                               Name = r.NAME,
                               Description = r.DESCRIPTION,
                               IsEnabled = r.ENABLE,
                               PictureLocation = r.PICTURELOCATION,
                               FoodTypeId = f.FOODTYPEID,
                               FoodTypeName = f.NAME
                           }).ToList();

            return restaurants;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ft"></param>
        /// <returns></returns>
        public List<LightRestaurant> GetLightRestaurantByFoodType(int foodTypeID)
        {
            this.RefreshDataSet();
            List<LightRestaurant> restaurants = new List<LightRestaurant>();

            restaurants = (from r in this.dp.ds.RESTAURANT
                           where r.FOODTYPEID == foodTypeID
                           join f in this.dp.ds.FOODTYPE on r.FOODTYPEID equals f.FOODTYPEID
                           select new LightRestaurant()
                           {
                               Id = (int)r.RESTAURANTID,
                               Name = r.NAME,
                               Description = r.DESCRIPTION,
                               IsEnabled = r.ENABLE,
                               PictureLocation = r.PICTURELOCATION,
                               FoodTypeId = f.FOODTYPEID,
                               FoodTypeName = f.NAME
                           }).ToList();

            return restaurants;
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
            this.dp.PrepareRestaurantDP();
            this.dp.PrepareFoodTypeDP();
            this.dp.PrepareAddressDP();
        }
        #endregion PRIVATE METHODS
    }
}
