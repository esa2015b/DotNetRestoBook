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
        /// Modifies a restaurant, and all depending objects, in database.
        /// </summary>
        /// <param name="restaurant">The full restaurant to modify.</param>
        /// <returns>True in case of successful modification, false in case of failure.</returns>
        bool ModifyRestaurant(Restaurant restaurant);

        /// <summary>
        /// Deletes a restaurant and all linked table objects.
        /// </summary>
        /// <param name="restaurant">The restaurant to delete.</param>
        /// <returns>True if successful, false if failed.</returns>
        bool DeleteRestaurant(Restaurant restaurant);


        /// <summary>
        /// Gets the list of existing food types.
        /// </summary>
        /// <returns>A list of existing food type objects.</returns>
        List<FoodType> GetAllFoodTypes();

        /// <summary>
        /// Returns a dictionnary containing the days of the week.
        /// </summary>
        /// <returns>The dictionnary containing every day of the week.</returns>
        Dictionary<string, string> GetDaysOfWeek();

        /// <summary>
        /// Creates a new address for a given restaurant.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        bool CreateAddress(Address address, int restaurantId);

        /// <summary>
        /// Deletes a given address from the database.
        /// </summary>
        /// <param name="address">The address to delete.</param>
        /// <param name="restaurantId">The address's restaurant identifier.</param>
        /// <returns>True if successfuly deleted, false if failed.</returns>
        bool DeleteAddress(Address address, int restaurantId);


        /// <summary>
        /// Creates a service for a given restaurant (given by the restaurantId);
        /// </summary>
        /// <param name="service">The service to add to the database.</param>
        /// <param name="restaurantId">The service's restaurant identifier.</param>
        /// <returns>True if successfuly created, false if failed.</returns>
        bool CreateService(Service service, int restaurantId);

        /// <summary>
        /// Gets all the existing services for a given restaurant.
        /// </summary>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>A list of services.</returns>
        List<Service> GetAllServices(int restaurantId);

        /// <summary>
        /// Deletes a service for a given restaurant.
        /// </summary>
        /// <param name="service">The service to delete.</param>
        /// <param name="restaurantId">The service's restaurant identifier.</param>
        /// <returns>True if successfuly deleted, false if failed.</returns>
        bool DeleteService(Service service, int restaurantId);


        /// <summary>
        /// Gets all the pricelists for a given restaurant.
        /// </summary>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>A list of pricelists.</returns>
        List<PriceList> GetAllPriceLists(int restaurantId);

        /// <summary>
        /// Creates a new pricelist entry in the database for a given restaurant.
        /// </summary>
        /// <param name="priceList">The pricelist to insert in the database.</param>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>True if successfuly created, false if failed.</returns>
        bool CreatePriceList(PriceList priceList, int restaurantId);

        /// <summary>
        /// Deletes the pricelist from the database.
        /// </summary>
        /// <param name="priceList">The pricelist to delete.</param>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>True if successfuly deleted, false if failed.</returns>
        bool DeletePriceList(PriceList priceList, int restaurantId);


        /// <summary>
        /// Creates the employee in the database for a given restaurant.
        /// </summary>
        /// <param name="employee">The employee to create.</param>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>True if successfuly created, false if failed.</returns>
        bool CreateEmployee(Employee employee, int restaurantId);

        /// <summary>
        /// Deletes the employee from the database.
        /// </summary>
        /// <param name="employee">The employee that needs to be removed from the database.</param>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>True if successfuly deleted, false if failed.</returns>
        bool DeleteEmployee(Employee employee, int restaurantId);
    }
}
