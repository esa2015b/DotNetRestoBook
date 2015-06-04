using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;

namespace RestoBook.Common.Business.Managers
{
    /// <summary>
    /// The restaurantmanager's interface.
    /// Every Manager has one Interface, for testing purpose and loose coupling purpose.
    /// </summary>
    public interface IRestaurantManager
    {
        /// <summary>
        /// Loads a restaurant by searching for the given restaurant id.
        /// </summary>
        /// <param name="restoId">The restaurant identifier.</param>
        /// <returns>The restaurant.</returns>
        Restaurant GetRestaurantById(int restoId);

        /// <summary>
        /// Get list of restaurants which contains given name
        /// </summary>
        /// <param name="restoName"></param>
        /// <returns></returns>
        List<Restaurant> GetRestaurantByName(String restoName);

        /// <summary>
        /// Get list of restaurant which contains given name, foodtype and city
        /// </summary>
        /// <param name="name"></param>
        /// <param name="foodTypeName"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        List<Restaurant> GetRestaurantAdvanced(String name, string foodTypeName, String city);

        /// <summary>
        /// Get list of restaurant which FoodType contains given FT.
        /// </summary>
        /// <param name="foodTypeId"></param>
        /// <returns></returns>
        List<Restaurant> GetRestaurantByFoodType(int foodTypeId);

        /// <summary>
        /// Get a random Restaurant
        /// </summary>
        /// <returns></returns>
        Restaurant GetRandomRestaurant();


        Dictionary<int, string> GetAllRestaurants();

    }
}
