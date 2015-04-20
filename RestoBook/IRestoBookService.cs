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

        [OperationContract()]
        List<Restaurant> GetRestaurantByName(string restaurantName);

        [OperationContract()]
        List<Restaurant> GetRestaurantAdvanced(string name, string foodTypeName, string city);

        [OperationContract()]
        List<Restaurant> GetRestaurantByFoodType(int foodTypeId);

        [OperationContract()]
        Restaurant GetRandomRestaurant();

    }
}
