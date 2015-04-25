namespace RestoBook
{
    using RestoBook.Common.Business.Managers;
    using RestoBook.Common.Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Text;

    /// <summary>
    /// The restobook webservice.
    /// Essentialy for the Java website project use.
    /// </summary>
    public class RestoBookService : IRestoBookService
    {
        #region PROPERTIES
        private RestaurantManager restaurantManager;
        private OwnerManager ownerManager;
        private EmployeeManager employeeManager;
        private ServiceManager serviceManager;
        private PriceListManager priceListManager;
        private FoodTypeManager foodTypeManager;
        private AddressManager addressManager;
        private LightRestaurantManager lightRestaurantManager;
        #endregion PROPERTIES

        #region CONSTRUCTOR
        public RestoBookService()
        {
            this.restaurantManager = new RestaurantManager();
            this.ownerManager = new OwnerManager();
            this.employeeManager = new EmployeeManager();
            this.serviceManager = new ServiceManager();
            this.priceListManager = new PriceListManager();
            this.foodTypeManager = new FoodTypeManager();
            this.addressManager = new AddressManager();
            this.lightRestaurantManager = new LightRestaurantManager();
        }
        #endregion CONSTRUCTOR

        #region PUBLIC METHODS
        /// <summary>
        /// Gets a restaurant by it's identifier.
        /// </summary>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>A full restaurant object.</returns>
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

        public List<Restaurant> GetRestaurantByName(string restaurantName)
        {

            List<Restaurant> restaurant = this.restaurantManager.GetRestaurantByName(restaurantName);

            if(restaurant != null)
            {
                foreach (Restaurant r in restaurant)
                {
                    int restaurantId = r.Id;

                    r.FoodType = this.foodTypeManager.GetFoodTypeById(restaurantId);
                    r.Owner = this.ownerManager.GetOwner(restaurantId);
                    r.Employees = this.employeeManager.GetEmployees(restaurantId);
                    r.PriceLists = this.priceListManager.GetPriceLists(restaurantId);
                    r.Services = this.serviceManager.GetServices(restaurantId);
                }

            }

            return restaurant;

        }

        public List<Restaurant> GetRestaurantAdvanced(string name, string foodTypeName, string city)
        {
            List<Restaurant> restaurant = this.restaurantManager.GetRestaurantAdvanced(name, foodTypeName, city);
            
            if (restaurant != null)
            {
                foreach (Restaurant r in restaurant)
                {
                    int restaurantId = r.Id;

                    r.FoodType = this.foodTypeManager.GetFoodTypeById(restaurantId);
                    r.Owner = this.ownerManager.GetOwner(restaurantId);
                    r.Employees = this.employeeManager.GetEmployees(restaurantId);
                    r.PriceLists = this.priceListManager.GetPriceLists(restaurantId);
                    r.Services = this.serviceManager.GetServices(restaurantId);
                }

            }

            return restaurant;
        }

        public List<Restaurant> GetRestaurantByFoodType(int foodTypeId)
        {
            List<Restaurant> restaurant = this.restaurantManager.GetRestaurantByFoodType(foodTypeId);

            if (restaurant != null)
            {
                foreach (Restaurant r in restaurant)
                {
                    int restaurantId = r.Id;

                    r.FoodType = this.foodTypeManager.GetFoodTypeById(restaurantId);
                    r.Owner = this.ownerManager.GetOwner(restaurantId);
                    r.Employees = this.employeeManager.GetEmployees(restaurantId);
                    r.PriceLists = this.priceListManager.GetPriceLists(restaurantId);
                    r.Services = this.serviceManager.GetServices(restaurantId);
                }
            }

            return restaurant;
        }

        public Restaurant GetRandomRestaurant()
        {
            Restaurant restaurant = restaurantManager.GetRandomRestaurant();

            if (restaurant != null)
            {
                int id = restaurant.Id;

                restaurant.FoodType = this.foodTypeManager.GetFoodTypeById(id);
                restaurant.Owner = this.ownerManager.GetOwner(id);
                restaurant.Employees = this.employeeManager.GetEmployees(id);
                restaurant.PriceLists = this.priceListManager.GetPriceLists(id);
                restaurant.Services = this.serviceManager.GetServices(id);
            }

            return restaurant;
        }

        public List<FoodType> GetFoodTypeList()
        {
            List<FoodType> ft = foodTypeManager.GetFoodTypeList();

            return ft;
        }

        public List<LightRestaurant> GetLightRestaurantAdvanced(string name, string foodTypeName, string city)
        {
            List<LightRestaurant> restaurant = lightRestaurantManager.GetLightRestaurantAdvanced(name, foodTypeName, city);
            if (restaurant != null)
            {
                foreach (LightRestaurant r in restaurant)
                {
                    r.FoodTypeName = this.foodTypeManager.GetFoodTypeById(r.Id).Name;
                }

            }

            return restaurant;
        }

        public List<LightRestaurant> GetLightRestaurantByFoodType(int foodTypeId)
        {
            List<LightRestaurant> restaurant = this.lightRestaurantManager.GetLightRestaurantByFoodType(foodTypeId);

            if (restaurant != null)
            {
                foreach (LightRestaurant r in restaurant)
                {
                    r.FoodTypeName = this.foodTypeManager.GetFoodTypeById(r.Id).Name;
                }
            }

            return restaurant;
        }

        public List<LightRestaurant> GetLightRestaurantByName(string restaurantName)
        {

            List<LightRestaurant> restaurant = this.lightRestaurantManager.GetLightRestaurantByName(restaurantName);

            if (restaurant != null)
            {
                foreach (LightRestaurant r in restaurant)
                {
                    r.FoodTypeName = this.foodTypeManager.GetFoodTypeById(r.Id).Name;
                }

            }

            return restaurant;

        }


        #endregion PUBLIC METHODS
    }
}
