using RestoBook.Common;
using RestoBook.Common.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System;
using RestoBook.Common.Model.Models;
using RestoBook.Model.Common.Models;

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
            dp = new DataProvider();
            dp.PrepareFullDataProvider();
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
            List<LightRestaurant> restaurant = new List<LightRestaurant>();

            var query = from r in this.dp.ds.RESTAURANT
                        where r.NAME.ToLower().Contains(restaurantName.ToLower())
                        join f in this.dp.ds.FOODTYPE on r.FOODTYPEID equals f.FOODTYPEID
                        select r;

            query.ToList().ForEach(r => restaurant.Add(new LightRestaurant()
            {
                Id = (int)r.RESTAURANTID,
                Name = r.NAME,
                Description = r.DESCRIPTION,
                PictureLocation = r.PICTURELOCATION,

            }));

            if (restaurant == null)
            {
                throw new Exception("No restaurant found with this name.");
            }
            return restaurant;
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
            List<LightRestaurant> restaurant = new List<LightRestaurant>();

            var query = from r in this.dp.ds.RESTAURANT
                        where r.NAME.ToLower().Contains(name.ToLower())
                        join f in this.dp.ds.FOODTYPE on r.FOODTYPEID equals f.FOODTYPEID
                        where f.NAME.ToLower().Contains(foodTypeName)
                        select r;
            query.ToList().ForEach(r => restaurant.Add(new LightRestaurant()
            {
                Id = (int)r.RESTAURANTID,
                Name = r.NAME,
                Description = r.DESCRIPTION,
                PictureLocation = r.PICTURELOCATION,
                IsEnabled = r.ENABLE

            }));

            return restaurant;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ft"></param>
        /// <returns></returns>
        public List<LightRestaurant> GetLightRestaurantByFoodType(int foodTypeID)
        {
            List<LightRestaurant> restaurant = new List<LightRestaurant>();

            var query = from r in this.dp.ds.RESTAURANT
                        where r.FOODTYPEID == foodTypeID
                        select r;

            query.ToList().ForEach(r => restaurant.Add(new LightRestaurant()
            {
                Id = (int)r.RESTAURANTID,
                Name = r.NAME,
                Description = r.DESCRIPTION,
                PictureLocation = r.PICTURELOCATION,
                IsEnabled = r.ENABLE

            }));

            return restaurant;
        }
        #endregion PUBLIC METHODS

    }
}
