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
                restaurant.Employees = this.employeeManager.GetEmployees(restaurantId);
                restaurant.PriceLists = this.priceListManager.GetPriceLists(restaurantId);
                restaurant.Services = this.serviceManager.GetServices(restaurantId);
            }

            return restaurant;
        }
        #endregion PUBLIC METHODS
    }
}
