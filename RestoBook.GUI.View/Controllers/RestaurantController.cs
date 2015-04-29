using RestoBook.Common.Business.Managers;
using RestoBook.Common.Model.Models;
using RestoBook.Common.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                restaurant.Addresses = this.addressManager.GetAddressesByRestaurantId(restaurantId);
                restaurant.Employees = this.employeeManager.GetEmployees(restaurantId);
                restaurant.PriceLists = this.priceListManager.GetPriceLists(restaurantId);
                restaurant.Services = this.serviceManager.GetServices(restaurantId);
			}
			return restaurant;
		}

		/// <summary>
		/// Creates a new restaurant, and all depending objects.
		/// </summary>
		/// <param name="newRestaurant">The new restaurant to create.</param>
		/// <returns>True in case of successful creation, false in case of failure.</returns>
		public bool CreateRestaurant(Restaurant newRestaurant)
		{
			bool successful = false;
			successful = this.ownerManager.CreateOwner(newRestaurant.Owner);
            newRestaurant.Owner.Id = this.ownerManager.GetOwnerByFirstAndLastName(newRestaurant.Owner.FirstName, newRestaurant.Owner.LastName).LastOrDefault().Id;

			if (successful)
			{
				successful = this.restaurantManager.CreateRestaurant(newRestaurant);
                newRestaurant.Id = this.restaurantManager.GetRestaurantByName(newRestaurant.Name).LastOrDefault().Id;
			}
			if (successful)
			{
                foreach (Address a in newRestaurant.Addresses)
                {
                    successful = this.addressManager.CreateAddres(a, newRestaurant.Id);
                }
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
        /// Modifies a restaurant, and all depending objects, in database.
        /// </summary>
        /// <param name="restaurant">The full restaurant to modify.</param>
        /// <returns>True in case of successful modification, false in case of failure.</returns>
        public bool ModifyRestaurant(Restaurant restaurant)
        {
            bool successful = false;
            successful = this.restaurantManager.ModifyRestaurant(restaurant);

            if (successful)
                successful = this.ownerManager.ModifyOwner(restaurant.Owner);

            return true;
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
                foreach (Address a in restaurant.Addresses)
                {
                    successful = this.addressManager.DeleteAddress(a, restaurant.Id);
                }
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

        /// <summary>
        /// Returns a list containing the days of the week.
        /// </summary>
        /// <returns>The list containing every day of the week.</returns>
        public Dictionary<string,string> GetDaysOfWeek()
        {
            Dictionary<string, string> daysOfWeek = new Dictionary<string, string>();
            CultureInfo belge = new CultureInfo("fr");
            foreach (var day in belge.DateTimeFormat.DayNames)
            {
                daysOfWeek.Add(day.ToString(), day.ToString());
            }
            return daysOfWeek;
        }


        /// <summary>
        /// Creates a new address for a given restaurant.
        /// </summary>
        /// <param name="address">The address to create.</param>
        /// <param name="restaurantId">The address's restaurant identifier.</param>
        /// <returns></returns>
        public bool CreateAddress(Address address, int restaurantId)
        {
            bool successful = this.addressManager.CreateAddres(address, restaurantId);
            return successful;
        }

        /// <summary>
        /// Deletes a given address from the database.
        /// </summary>
        /// <param name="address">The address to delete.</param>
        /// <param name="restaurantId">The address's restaurant identifier.</param>
        /// <returns>True if successfuly deleted, false if failed.</returns>
        public bool DeleteAddress(Address address, int restaurantId)
        {
            bool successful = this.addressManager.DeleteAddress(address, restaurantId);
            return successful;
        }


        /// <summary>
        /// Creates a service for a given restaurant (given by the restaurantId);
        /// </summary>
        /// <param name="service">The service to add to the database.</param>
        /// <param name="restaurantId">The service's restaurant identifier.</param>
        /// <returns>True if successfuly created, false if failed.</returns>
        public bool CreateService(Service service, int restaurantId)
        {
            bool result = this.serviceManager.CreateService(service, restaurantId);
            return result;
        }

        /// <summary>
        /// Gets all the existing services for a given restaurant.
        /// </summary>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>A list of services.</returns>
        public List<Service> GetAllServices(int restaurantId)
        {
            return this.serviceManager.GetServices(restaurantId);
        }

        /// <summary>
        /// Deletes a service for a given restaurant.
        /// </summary>
        /// <param name="service">The service to delete.</param>
        /// <param name="restaurantId">The service's restaurant identifier.</param>
        /// <returns>True if successfuly deleted, false if failed.</returns>
        public bool DeleteService(Service service, int restaurantId)
        {
            return this.serviceManager.DeleteService(service, restaurantId);
        }


        /// <summary>
        /// Gets all the pricelists for a given restaurant.
        /// </summary>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>A list of pricelists.</returns>
        public List<PriceList> GetAllPriceLists(int restaurantId)
        {
            return this.priceListManager.GetPriceLists(restaurantId);
        }

        /// <summary>
        /// Creates a new pricelist entry in the database for a given restaurant.
        /// </summary>
        /// <param name="priceList">The pricelist to insert in the database.</param>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>True if successfuly created, false if failed.</returns>
        public bool CreatePriceList(PriceList priceList, int restaurantId)
        {
            return this.priceListManager.CreatePriceList(priceList, restaurantId);
        }

        /// <summary>
        /// Deletes the pricelist from the database.
        /// </summary>
        /// <param name="priceList">The pricelist to delete.</param>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>True if successfuly deleted, false if failed.</returns>
        public bool DeletePriceList(PriceList priceList, int restaurantId)
        {
            return this.priceListManager.DeletePriceList(priceList, restaurantId);
        }

		#endregion PUBLIC METHODS
	}
}
