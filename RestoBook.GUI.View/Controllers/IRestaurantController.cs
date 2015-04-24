using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.GUI.View.Controllers
{
	/// <summary>
	/// The restaurant view controller interface.
	/// </summary>
	public interface IRestaurantController
	{
		/// <summary>
		/// Gets a list containing all the existing restaurants names and ids.
		/// </summary>
		/// <returns>A dictionnary containing all the restaurant's id & names.</returns>
		Dictionary<int, string> GetAllRestaurants();

		/// <summary>
		/// Gets a given restaurant by it's identifier.
		/// </summary>
		/// <param name="restaurantId">The searched restaurant's id.</param>
		/// <returns>The requested restaurant.</returns>
		Restaurant GetRestaurantById(int restaurantId);

		/// <summary>
		/// Creates a new restaurant, and all depending objects.
		/// </summary>
		/// <param name="newRestaurant">The new restaurant to create.</param>
		/// <returns>True in case of successful update, false in case of failure.</returns>
		bool CreateRestaurant(Restaurant newRestaurant);

		/// <summary>
		/// Gets the list of existing food types.
		/// </summary>
		/// <returns>A list of existing food type objects.</returns>
		List<FoodType> GetAllFoodTypes();

		/// <summary>
		/// Returns a dictionnary containing the days of the week.
		/// </summary>
		/// <returns>The dictionnary containing every day of the week.</returns>
		Dictionary<string,string> GetDaysOfWeek();

        /// <summary>
        /// Creates a new address for a given restaurant.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        bool CreateAddress(Address address, int restaurantId);

	}
}
