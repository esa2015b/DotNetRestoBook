using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestoBook
{
    /// <summary>
    /// The Restobook webservice's interface.
    /// </summary>
    [ServiceContract]
    public interface IRestoBookService
    {
        /// <summary>
        /// Gets a specific restaurant by passing his identifier.
        /// </summary>
        /// <param name="restaurantId">The restaurant's identifier.</param>
        /// <returns>The requested restaurant.</returns>
        [OperationContract()]
        Restaurant GetRestaurantById(int restaurantId);

        /// <summary>
        /// Gets a list of restaurants by passing their name (or part of)
        /// </summary>
        /// <param name="restaurantName"></param>
        /// <returns>List of restaurants</returns>
        [OperationContract()]
        List<Restaurant> GetRestaurantByName(string restaurantName);

        /// <summary>
        /// Gets a list of restaurants by passing their name, foodtype and city
        /// </summary>
        /// <param name="name"></param>
        /// <param name="foodTypeName"></param>
        /// <param name="city"></param>
        /// <returns>List of restaurants</returns>
        [OperationContract()]
        List<Restaurant> GetRestaurantAdvanced(string name, string foodTypeName, string city);

        /// <summary>
        /// Gets a list of restaurants by passing their food type
        /// </summary>
        /// <param name="foodTypeId"></param>
        /// <returns>List of restaurants</returns>
        [OperationContract()]
        List<Restaurant> GetRestaurantByFoodType(int foodTypeId);

        /// <summary>
        /// Gets a random restaurant
        /// </summary>
        /// <returns>A restaurant</returns>
        [OperationContract()]
        Restaurant GetRandomRestaurant();

        /// <summary>
        /// Gets the list of all food types
        /// </summary>
        /// <returns>List of Food Type</returns>
        [OperationContract()]
        List<FoodType> GetFoodTypeList();

        [OperationContract()]
        List<LightRestaurant> GetLightRestaurantAdvanced(string name, string foodTypeName, string city);

        [OperationContract()]
        List<LightRestaurant> GetLightRestaurantByFoodType(int foodTypeId);

        [OperationContract()]
        List<LightRestaurant> GetLightRestaurantByName(string restaurantName);
    }
}
