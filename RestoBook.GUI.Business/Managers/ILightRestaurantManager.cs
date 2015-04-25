using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RestoBook.Common.Model.Models;

namespace RestoBook.Common.Business.Managers
{
    public interface ILightRestaurantManager
    {
        List<LightRestaurant> GetLightRestaurantByName(String restaurantName);
        List<LightRestaurant> GetLightRestaurantAdvanced(string name, string foodTypeName, string city);
        List<LightRestaurant> GetLightRestaurantByFoodType(int foodTypeID);
    }
}
