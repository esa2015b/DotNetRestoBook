using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;

namespace RestoBook.Common.Business.Managers
{
    public interface ILightRestaurantManager
    {
        List<LightRestaurant> GetLightRestaurantByName(String restaurantName);
        List<LightRestaurant> GetLightRestaurantAdvanced(string name, string foodTypeName, string city);
        List<LightRestaurant> GetLightRestaurantByFoodType(int foodTypeID);
    }
}
