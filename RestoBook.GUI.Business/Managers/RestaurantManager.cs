using RestoBook.Common;
using RestoBook.Common.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System;
using RestoBook.Common.Model.Models;

namespace RestoBook.Common.Business.Managers
{
    public class RestaurantManager : IRestaurantManager
    {
        #region PROPERTIES
        DataProvider dp;
        #endregion PROPERTIES

        #region CONSTRUCTOR
        public RestaurantManager()
        {
            dp = new DataProvider();
            dp.PrepareFullDataProvider();
        }
        #endregion CONSTRUCTOR

        #region PUBLIC METHODS
        /// <summary>
        /// Static method that retrieve datas using method getRestaurantList 
        /// from RestoBook.GUI.Model layer
        /// No modification to datas 
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetAllRestaurants()
        {
            return this.dp.ds;
        }

        /// <summary>
        /// Static method that retrieve datas for one restaurant using method getRestaurant
        /// from RestoBook.GUI.Model layer
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        public Restaurant GetRestaurantById(int restaurantId)
        {
            Restaurant resto = new Restaurant();
            resto =  (from r in this.dp.ds.RESTAURANT
                                              where r.RESTAURANTID == restaurantId
                                              join o in this.dp.ds.OWNER on r.OWNERID equals o.OWNERID
                                              join f in this.dp.ds.FOODTYPE on r.FOODTYPEID equals f.FOODTYPEID
                                              select new Restaurant()
                                              {
                                                  Id = (int)r.RESTAURANTID,
                                                  Name = r.NAME,
                                                  Mail = r.MAIL,
                                                  Phone = r.PHONE,
                                                  Description = r.DESCRIPTION,
                                                  PlaceQuantity = (int)r.PLACEQUANTITY,
                                                  DayOfClosing = r.DAYOFCLOSING,
                                                  PictureLocation = r.PICTURELOCATION,
                                                  IsPremium = r.ISPREMIUM,
                                                  IsEnabled = r.ENABLE,
                                                  FoodType = new FoodType() { Description = f.DESCRIPTION, Id = (int)f.FOODTYPEID, IsEnabled = f.ENABLE, Name = f.NAME },
                                                  Owner = new Owner() { FirstName = o.FIRSTNAME, Id = (int)o.OWNERID, IsEnabled = o.ENABLE, LastName = o.LASTNAME, OwnedRestaurants = new List<Restaurant>() }
                                              }).FirstOrDefault();
            if (resto == null)
            {
                throw new Exception("No restaurant found with this id.");
            }
            return resto;
        }
        #endregion
    }
}
