using RestoBook.Common.Business.Managers;
using RestoBook.Common.Model.Models;
using RestoBook.Model.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.GUI.View.Controllers
{
	/// <summary>
	/// The restaurant view controller, to process information between the views and the business logic layer.
	/// </summary>
	public class RestaurantController : IRestaurantController
	{
		#region PROPERTIES
		private RestaurantManager restaurantManager;
		private ServiceManager serviceManager;
		private PriceListManager priceListManager;
		private OwnerManager ownerManager;
		private AddressManager addressManager;
        private EmployeeManager employeeManager;
        private FoodTypeManager foodTypeManager;
        //private ReservationManager reservationManager;
		#endregion PROPERTIES


		#region CONSTRUCTOR
		public RestaurantController()
		{
			this.restaurantManager = new RestaurantManager();
			this.serviceManager = new ServiceManager();
			this.priceListManager = new PriceListManager();
			this.ownerManager = new OwnerManager();
			this.addressManager = new AddressManager();
            this.employeeManager = new EmployeeManager();
            this.foodTypeManager = new FoodTypeManager();
            //this.reservationManager = new ReservationManager();
		}
		#endregion CONSTRUCTOR


		#region PUBLIC METHODS
		/// <summary>
		/// Gets a list containing all the existing restaurants names and ids.
		/// </summary>
		/// <returns>A dictionnary containing all the restaurant's id & names.</returns>
		public Dictionary<int,string> GetAllRestaurants()
		{
			return this.restaurantManager.GetAllRestaurants();
		}

		/// <summary>
		/// Gets a given restaurant by it's identifier.
		/// </summary>
		/// <param name="restaurantId">The searched restaurant's id.</param>
		/// <returns>The requested restaurant.</returns>
		public Restaurant GetRestaurantById(int restaurantId)
		{
			Restaurant restaurant = this.restaurantManager.GetRestaurantById(restaurantId);
            if (restaurant != null)
            {
                restaurant.PriceLists = this.priceListManager.GetPriceLists(restaurantId);
                restaurant.Services = this.serviceManager.GetServices(restaurantId);
                //restaurant.Owner = this.ownerManager.GetOwner(restaurant.)
            }
			return restaurant;
		}

		/// <summary>
		/// Creates a new restaurant, and all depending objects.
		/// </summary>
		/// <param name="newRestaurant">The new restaurant to create.</param>
        /// <returns>True in case of successful update, false in case of failure.</returns>
        public bool CreateRestaurant(Restaurant newRestaurant)
		{
			bool successful = false;
			successful = this.ownerManager.CreateOwner(newRestaurant.Owner);

			if (successful)
			{
				successful = this.restaurantManager.CreateRestaurant(newRestaurant);
			}
			if (successful)
			{
				successful = this.addressManager.CreateAddres(newRestaurant.Address, newRestaurant.Id);
			}

			foreach (Service service in newRestaurant.Services)
			{
				if (successful)
				{
					successful = this.serviceManager.CreateService(service, newRestaurant.Id);
				}
			}
			foreach (PriceList priceList in newRestaurant.PriceLists)
			{
				if (successful)
				{
					successful = this.priceListManager.CreatePriceList(priceList, newRestaurant.Id);
				}
			}
			return successful;
		}

        /// <summary>
        /// Deletes a restaurant and all linked table objects.
        /// </summary>
        /// <param name="restaurant">The restaurant to delete.</param>
        /// <returns>True if successful, false if failed.</returns>
        public bool DeleteRestaurant(Restaurant restaurant)
        {
            bool successful = true;
            foreach (PriceList priceList in restaurant.PriceLists)
            {
                if (successful)
                {
                    successful = this.priceListManager.DeletePriceList(priceList, restaurant.Id);
                }
            }
            // TODO : implement the reservation manager & deletion of all reservations.
            foreach (Service service in restaurant.Services)
            {
                if (successful)
                {
                    successful = this.serviceManager.DeleteService(service, restaurant.Id);
                }
            }
            foreach (Employee employee in restaurant.Employees)
            {
                if (successful)
                {
                    successful = this.employeeManager.DeleteEmployee(employee, restaurant.Id);
                }
            }
            if (successful)
            {
                successful = this.addressManager.DeleteAddress(restaurant.Address, restaurant.Id);
            }
            if (successful)
            {
                successful = this.restaurantManager.DeleteRestaurant(restaurant);
            }
            if (successful)
            {
                successful = this.ownerManager.DeleteOwner(restaurant.Owner);
            }
            return successful;
        }


        /// <summary>
        /// Gets the list of existing food types.
        /// </summary>
        /// <returns>A list of existing food type objects.</returns>
        public List<FoodType> GetAllFoodTypes()
        {
            return this.foodTypeManager.GetFoodTypeList();
        }

		#endregion PUBLIC METHODS
	}
}
