namespace RestoBook
{
    using RestoBook.Common.Business.Managers;
    using RestoBook.Common.Model.Models;
    using System.Collections.Generic;
    using System.Linq;

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
        private ReservationManager reservationManager;
        private CustomerManager customerManager;
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
            this.reservationManager = new ReservationManager();
            this.customerManager = new CustomerManager();
        }
        #endregion CONSTRUCTOR


        #region PUBLIC METHODS

        #region RESTAURANTS
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

                    r.Addresses = this.addressManager.GetAddressesByRestaurantId(restaurantId);
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

                restaurant.Addresses = this.addressManager.GetAddressesByRestaurantId(id);
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
            List<LightRestaurant> restaurants = lightRestaurantManager.GetLightRestaurantAdvanced(name, foodTypeName, city);
            
            if (restaurants != null)
            {
                foreach (LightRestaurant lr in restaurants)
                {
                    lr.City = this.addressManager.GetAddressesByRestaurantId(lr.Id).FirstOrDefault().City;
                }
            }
            
            return restaurants;
        }

        public List<LightRestaurant> GetLightRestaurantByFoodType(int foodTypeId)
        {
            List<LightRestaurant> restaurants = this.lightRestaurantManager.GetLightRestaurantByFoodType(foodTypeId);

            if (restaurants != null)
            {
                foreach (LightRestaurant lr in restaurants)
                {
                    lr.City = this.addressManager.GetAddressesByRestaurantId(lr.Id).FirstOrDefault().City;
                }
            }

            return restaurants;
        }

        public List<LightRestaurant> GetLightRestaurantByName(string restaurantName)
        {

            List<LightRestaurant> restaurants = this.lightRestaurantManager.GetLightRestaurantByName(restaurantName);

            if (restaurants != null)
            {
                foreach (LightRestaurant lr in restaurants)
                {
                    lr.FoodTypeName = this.foodTypeManager.GetFoodTypeById(lr.Id).Name; lr.City = this.addressManager.GetAddressesByRestaurantId(lr.Id).FirstOrDefault().City;
                }
            }

            return restaurants;
        }
        #endregion

        #region RESERVATIONS
        public bool CreateReservation(Reservation reservation, Customer customer)
        {
            Customer cust;
            cust = this.customerManager.GetCustomerByMail(customer.Mail);
            if (cust == null)
            {
                cust = new Customer();
                this.customerManager.CreateCustomer(customer);
                cust = this.customerManager.GetCustomerByMail(customer.Mail);
            }
            reservation.CustomerId = cust.Id;
            bool createResa = this.reservationManager.CreateReservation(reservation);
            return createResa;
        }

        public bool ModifyReservationsFromCustomer(Reservation reservation)
        {
            return this.reservationManager.ModifyReservationFromCustomer(reservation);
        }

        public bool ModifyReservationsFromBackOffice(Reservation reservation)
        {
            return this.reservationManager.ModifyReservationsFromBackOffice(reservation);
        }

        public bool ConfirmReservationsFromResto(Reservation reservation)
        {
            return this.reservationManager.ConfirmReservationFromResto(reservation);
        }

        public List<Reservation> GetReservationConfirmedByService(int serviceId)
        {
            return this.reservationManager.GetReservationConfirmedByService(serviceId);
        }

        public List<Reservation> GetReservationByService(int serviceId)
        {
            return this.reservationManager.GetReservationConfirmedByService(serviceId);
        }

        public List<Reservation> GetReservationNotConfirmedByService(int serviceId)
        {
            return this.reservationManager.GetReservationNotConfirmedByService(serviceId);
        }

        public List<Reservation> GetReservationNotConfirmedWithin24Hours()
        {
            return this.reservationManager.GetReservationNotConfirmedWithin24Hours();
        }

        public List<Reservation> GetReservationByRestaurant(int restoId)
        {
            List<Reservation> reservations =  this.reservationManager.GetReservationsByRestaurant(restoId);

            reservations = reservations.OrderBy(r => r.ServiceDate).ToList();

            return reservations;
        }

        public List<Reservation> GetAllReservations()
        {
            return this.reservationManager.GetAllReservations();
        }

        #endregion

        #endregion PUBLIC METHODS
    }
}
