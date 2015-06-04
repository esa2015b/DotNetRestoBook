using RestoBook.Common.Model;
using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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

        public Dictionary<int,string> GetAllRestaurants()
        {
            this.RefreshDataSet();
            Dictionary<int, string> restaurants = new Dictionary<int, string>();
            this.dp.ds.RESTAURANT.Select(r => new { r.RESTAURANTID, r.NAME })
                                 .ToList()
                                 .ForEach(r => restaurants.Add((int)r.RESTAURANTID, r.NAME));
            return restaurants;
        }

        /// <summary>
        /// Static method that retrieve datas for one restaurant using method getRestaurant
        /// from RestoBook.GUI.Model layer
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        public Restaurant GetRestaurantById(int restaurantId)
        {
            this.RefreshDataSet();
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
                //throw new Exception("No restaurant found with this id.");
            }
            return resto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restaurantName"></param>
        /// <returns></returns>
        public List<Restaurant> GetRestaurantByName(String restaurantName)
        {
            this.RefreshDataSet();
            List<Restaurant> restaurant = new List<Restaurant>();

            var query = from r in this.dp.ds.RESTAURANT
                        where r.NAME.ToLower().Contains(restaurantName.ToLower())
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
                                              };
            restaurant = query.ToList();
            
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
        public List<Restaurant> GetRestaurantAdvanced(string name, string foodTypeName, string city)
        {
            this.RefreshDataSet();
            List<Restaurant> restaurant = new List<Restaurant>();

            var query = from r in this.dp.ds.RESTAURANT
                        where r.NAME.ToLower().Contains(name.ToLower())
                        join o in this.dp.ds.OWNER on r.OWNERID equals o.OWNERID
                        join f in this.dp.ds.FOODTYPE on r.FOODTYPEID equals f.FOODTYPEID
                        where f.NAME.ToLower().Contains(foodTypeName)
                        select r;
            query.ToList().ForEach(r => restaurant.Add(new Restaurant()
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
                IsEnabled = r.ENABLE

            }));

            return restaurant;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ft"></param>
        /// <returns></returns>
        public List<Restaurant> GetRestaurantByFoodType(int foodTypeID)
        {
            this.RefreshDataSet();
            List<Restaurant> restaurant = new List<Restaurant>();

            var query = from r in this.dp.ds.RESTAURANT
                        where r.FOODTYPEID == foodTypeID
                        select r;
            
            query.ToList().ForEach(r => restaurant.Add(new Restaurant()
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
                IsEnabled = r.ENABLE

            }));

            return restaurant;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Restaurant GetRandomRestaurant()
        {
            this.RefreshDataSet();
            Restaurant restaurant = new Restaurant();

            restaurant = (from r in this.dp.ds.RESTAURANT
                          join f in this.dp.ds.FOODTYPE on r.FOODTYPEID equals f.FOODTYPEID
                          join o in this.dp.ds.OWNER on r.OWNERID equals o.OWNERID
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
                        }).OrderBy(x => Guid.NewGuid()).First();
            return restaurant;
        }

        /// <summary>
        /// Creates a new restaurant.
        /// </summary>
        /// <param name="r">The restaurant to create.</param>
        /// <returns>True in case of successful update, false in case of failure.</returns>
        public bool CreateRestaurant(Restaurant r)
        {
            int nbrRowsCreated = -1;

            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.RESTAURANTTableAdapter daRestaurant = new Model.DataSetRestoBookTableAdapters.RESTAURANTTableAdapter())
            {
                nbrRowsCreated = daRestaurant.Insert(r.Owner.Id,
                                                     r.FoodType.Id,
                                                     r.Name,
                                                     r.Mail,
                                                     r.Phone,
                                                     r.Description,
                                                     r.PlaceQuantity,
                                                     r.DayOfClosing,
                                                     r.PictureLocation == null ? string.Empty : r.PictureLocation,
                                                     r.IsEnabled,
                                                     r.IsPremium);
            }
            return nbrRowsCreated > 0;
        }

        /// <summary>
        /// Deletes a restaurant.
        /// </summary>
        /// <param name="r">The restaurant to delete.</param>
        /// <returns>True in case of successful update, false in case of failure.</returns>
        public bool DeleteRestaurant(Restaurant r)
        {
            int nbrRowsDeleted = -1;
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.RESTAURANTTableAdapter daRestaurant = new Model.DataSetRestoBookTableAdapters.RESTAURANTTableAdapter())
            {
                nbrRowsDeleted = daRestaurant.Delete(r.Id, 
                                                     r.Owner.Id,
                                                     r.FoodType.Id,
                                                     r.Name,
                                                     r.Mail,
                                                     r.Phone,
                                                     r.Description,
                                                     r.PlaceQuantity,
                                                     r.DayOfClosing,
                                                     r.PictureLocation,
                                                     r.IsEnabled,
                                                     r.IsPremium);
            }
            return nbrRowsDeleted > 0;
        }

        /// <summary>
        /// Modifies a restaurant.
        /// </summary>
        /// <param name="r">The modified restaurant.</param>
        /// <returns>True in case of successful update, false in case of failure.</returns>
        public bool ModifyRestaurant(Restaurant r)
        {
            int nbrRowsUpdated = -1;

            DataRow row = dp.ds.RESTAURANT.Select(string.Format("RESTAURANTID = '{0}'", r.Id)).FirstOrDefault();
            row["NAME"] = r.Name;
            row["MAIL"] = r.Mail;
            row["PHONE"] = r.Phone;
            row["DESCRIPTION"] = r.Description;
            row["PLACEQUANTITY"] = r.PlaceQuantity;
            row["DAYOFCLOSING"] = r.DayOfClosing;
            row["PICTURELOCATION"] = r.PictureLocation;
            row["ENABLE"] = r.IsEnabled;
            row["ISPREMIUM"] = r.IsPremium;

            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.RESTAURANTTableAdapter daRestaurant = new Model.DataSetRestoBookTableAdapters.RESTAURANTTableAdapter())
            {
                nbrRowsUpdated = daRestaurant.Update(row);
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
            this.dp.PrepareFullDataProvider();
        }
        #endregion PRIVATE METHODS

    }
}
