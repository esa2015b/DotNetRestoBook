using RestoBook.Common.Business.Managers;
using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.GUI.View.Controllers
{
	/// <summary>
	/// The restaurant view controller.
	/// </summary>
	public class RestaurantController : IRestaurantController
	{
		#region PROPERTIES
		private RestaurantManager restaurantManager;
		private ServiceManager serviceManager;
		private PriceListManager priceListManager;
		private OwnerManager ownerManager;
		private AddressManager addressManager;
		#endregion PROPERTIES


		#region CONSTRUCTOR
		public RestaurantController()
		{
			this.restaurantManager = new RestaurantManager();
			this.serviceManager = new ServiceManager();
			this.priceListManager = new PriceListManager();
			this.ownerManager = new OwnerManager();
			this.addressManager = new AddressManager();
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
			restaurant.PriceLists = this.priceListManager.GetPriceLists(restaurantId);
			restaurant.Services = this.serviceManager.GetServices(restaurantId);
			//restaurant.Owner = this.ownerManager.GetOwner(restaurant.)
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
		#endregion PUBLIC METHODS
	}
}
