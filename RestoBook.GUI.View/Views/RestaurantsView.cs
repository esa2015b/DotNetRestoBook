using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestoBook.GUI.View.Controllers;
using RestoBook.Common.Model.Models;

namespace RestoBook.GUI.View.Views
{
    public partial class RestaurantsView : UserControl
    {
        #region PROPERTIES
        private Dictionary<int, string> restaurants;
        private Restaurant restaurantFocus;
        private RestaurantController restaurantController;
        private List<FoodType> foodTypes;
        private Dictionary<string, string> daysOfWeek;
        #endregion PROPERTIES


        #region CONSTRUCTOR
        public RestaurantsView()
        {
            InitializeComponent();
            this.restaurantController = new RestaurantController();
            this.PopulateAndBindRestaurantList();
            this.buttonCancel.Enabled = false;
            this.buttonAddRestaurant.Enabled = false;
        }
        #endregion CONSTRUCTOR

        #region METHODS
        /// <summary>
        /// Method that binds datas coming from RestoBook.GUI.Business layer to MainForm's controls.
        /// Only to show test datas 
        /// </summary>
        private void PopulateAndBindRestaurantList()
        {
            this.restaurants = this.restaurantController.GetAllRestaurants();
            this.foodTypes = this.restaurantController.GetAllFoodTypes();
            this.daysOfWeek = this.restaurantController.GetDaysOfWeek();

            this.comboBoxDayOfClosing.DataSource = new BindingSource(this.daysOfWeek, null);
            this.comboBoxDayOfClosing.DisplayMember = "Value";
            this.comboBoxDayOfClosing.ValueMember = "Value";

            this.comboBoxRestaurants.DataSource = new BindingSource(this.restaurants, null);
            this.comboBoxRestaurants.DisplayMember = "Value";
            this.comboBoxRestaurants.ValueMember = "Key";
            
            this.comboBoxFoodType.DataSource = this.foodTypes;
            this.comboBoxFoodType.DisplayMember = "Name";
            this.comboBoxFoodType.ValueMember = "Id";

        }

        /// <summary>
        /// Populates and binds the details for a specific restaurant chosen in the combobox.
        /// </summary>
        private void PopulateAndBindRestaurantDetails()
        {
            this.restaurantFocus = this.restaurantController.GetRestaurantById(((KeyValuePair<int, string>)this.comboBoxRestaurants.SelectedItem).Key);
            this.BindRestaurantDetails();
        }

        /// <summary>
        /// Binds the selected restaurantFocus details to the local items.
        /// </summary>
        private void BindRestaurantDetails()
        {

            dataGridViewListServices.DataSource = this.restaurantFocus;
            dataGridViewListServices.DataMember = "Services";

            dataGridViewListPrice.DataSource = this.restaurantFocus;
            dataGridViewListPrice.DataMember = "PriceLists";

            // if the page has been loaded before, clear all existing bindings
            // in order to avoid conflicts.
            if (textBoxRestaurantsName.DataBindings.Count > 0)
            {
                this.ClearRestaurantsDataBindings();
            }
            this.comboBoxAddresses.DataSource = this.restaurantFocus.Addresses;
            this.comboBoxAddresses.DisplayMember = "City";
            this.comboBoxAddresses.ValueMember = "Id";

            comboBoxFoodType.SelectedValue = this.restaurantFocus.FoodType.Id;
            textBoxRestaurantsName.DataBindings.Add("Text", this.restaurantFocus, "Name");
            textBoxPlaceQuantity.DataBindings.Add("Text", this.restaurantFocus, "PlaceQuantity");
            textBoxDescription.DataBindings.Add("Text", this.restaurantFocus, "Description");
            
            comboBoxDayOfClosing.SelectedValue = this.restaurantFocus.DayOfClosing.ToLower();
            textBoxMail.DataBindings.Add("Text", this.restaurantFocus, "Mail");
            textBoxPhone.DataBindings.Add("Text", this.restaurantFocus, "Phone");

            textBoxOwnersFirstName.DataBindings.Add("Text", this.restaurantFocus, "Owner.FirstName");
            textBoxOwnerLastName.DataBindings.Add("Text", this.restaurantFocus, ("Owner.LastName"));

            comboBoxAddresses.SelectedValue = this.restaurantFocus.Addresses[0].Id;
            textBoxStreet.DataBindings.Add("Text", this.restaurantFocus.Addresses, "Street");
            textBoxStreetNumber.DataBindings.Add("Text", this.restaurantFocus.Addresses, "Number");
            textBoxZipCode.DataBindings.Add("Text", this.restaurantFocus.Addresses, "Zipcode");
            textBoxCity.DataBindings.Add("Text", this.restaurantFocus.Addresses, "City");
            textBoxCountry.DataBindings.Add("Text", this.restaurantFocus.Addresses, "Country");

        }

        /// <summary>
        /// Clears all the restaurant tab's databindings.
        /// </summary>
        private void ClearRestaurantsDataBindings()
        {
            comboBoxFoodType.DataBindings.Clear();
            textBoxRestaurantsName.DataBindings.Clear();
            textBoxPlaceQuantity.DataBindings.Clear();
            textBoxDescription.DataBindings.Clear();

            comboBoxDayOfClosing.DataBindings.Clear();
            textBoxMail.DataBindings.Clear();
            textBoxPhone.DataBindings.Clear();
            textBoxOwnersFirstName.DataBindings.Clear();
            textBoxOwnerLastName.DataBindings.Clear();

            comboBoxAddresses.DataBindings.Clear();
            textBoxStreet.DataBindings.Clear();
            textBoxStreetNumber.DataBindings.Clear();
            textBoxCity.DataBindings.Clear();
            textBoxZipCode.DataBindings.Clear();
            textBoxCountry.DataBindings.Clear();
        }

        private bool CheckCreationConditions()
        {
            if (!string.IsNullOrEmpty(restaurantFocus.DayOfClosing) &&
                !string.IsNullOrEmpty(restaurantFocus.Description) &&
                !string.IsNullOrEmpty(restaurantFocus.Mail) &&
                !string.IsNullOrEmpty(restaurantFocus.Name) &&
                !string.IsNullOrEmpty(restaurantFocus.Phone) &&
                restaurantFocus.PlaceQuantity != 0 &&
                restaurantFocus.Addresses != null &&
                restaurantFocus.Addresses.Count > 0&&

                //!string.IsNullOrEmpty(restaurantFocus.Address.City) &&
                //!string.IsNullOrEmpty(restaurantFocus.Address.Country) &&
                //!string.IsNullOrEmpty(restaurantFocus.Address.Number) &&
                //restaurantFocus.Employees != null &&
                //restaurantFocus.Employees.Count >= 0 &&
                //!string.IsNullOrEmpty(restaurantFocus.Employees[0].Email) &&
                //!string.IsNullOrEmpty(restaurantFocus.Employees[0].FirstName) &&
                //!string.IsNullOrEmpty(restaurantFocus.Employees[0].LastName) &&
                //!string.IsNullOrEmpty(restaurantFocus.Employees[0].Login) &&
                //!string.IsNullOrEmpty(restaurantFocus.Employees[0].Password) &&
                restaurantFocus.FoodType != null &&
                !string.IsNullOrEmpty(restaurantFocus.FoodType.Description) &&
                !string.IsNullOrEmpty(restaurantFocus.FoodType.Name) &&
                restaurantFocus.Owner != null &&
                !string.IsNullOrEmpty(restaurantFocus.Owner.FirstName) &&
                !string.IsNullOrEmpty(restaurantFocus.Owner.LastName) &&
                restaurantFocus.PriceLists != null &&
                restaurantFocus.PriceLists.Count > 0 &&
                !string.IsNullOrEmpty(restaurantFocus.PriceLists[0].Description) &&
                restaurantFocus.PriceLists[0].MaximumPrice > restaurantFocus.PriceLists[0].MinimumPrice &&
                restaurantFocus.PriceLists[0].MinimumPrice > 0 &&
                restaurantFocus.Services != null &&
                restaurantFocus.Services.Count > 0 &&
                !string.IsNullOrEmpty(restaurantFocus.Services[0].TypeService) &&
                restaurantFocus.Services[0].BeginShift < restaurantFocus.Services[0].EndShift &&
                restaurantFocus.Services[0].PlaceQuantity > 0 &&
                restaurantFocus.Services[0].ServiceDate != null &&
                restaurantFocus.Services[0].ServiceDate != DateTime.MinValue
                //restaurantFocus.Services[0].ServiceDay != null
                )
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Enables all the required comboboxes & buttons to enable restaurant browsing.
        /// </summary>
        private void EnableRestaurantSelection()
        {
            this.comboBoxRestaurants.Enabled = true;
            this.comboBoxFoodType.Enabled = false;
            this.comboBoxDayOfClosing.Enabled = false;
            this.buttonDeleteRestaurant.Enabled = true;
            this.buttonModifyRestaurant.Enabled = true;
            this.buttonAddRestaurant.Enabled = false;
            this.buttonCancel.Enabled = false;
            this.PopulateAndBindRestaurantList();
        }

        /// <summary>
        /// Disables all the comboboxes & buttons to prevent restaurant browsing.
        /// </summary>
        private void DisableRestaurantSelection()
        {
            this.comboBoxRestaurants.Enabled = false;
            this.comboBoxFoodType.Enabled = true;
            this.comboBoxDayOfClosing.Enabled = true;
            this.buttonAddRestaurant.Enabled = true;
            this.buttonDeleteRestaurant.Enabled = false;
            this.buttonModifyRestaurant.Enabled = false;
            this.buttonCancel.Enabled = true;
        }       
        #endregion METHODS


        #region EVENTS
        /// <summary>
        /// On selected index change of combobox, call populateandbindrestaurantdetails.
        /// </summary>
        /// <param name="sender">The comboboxRestaurants.</param>
        /// <param name="e">The combobox event args (the keyvaluepair)</param>
        private void comboBoxRestaurants_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulateAndBindRestaurantDetails();
        }

        /// <summary>
        /// In order to create a new restaurant.
        /// This event clears all the fields, and disables certain buttons,
        /// in order to avoid interference.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNewRestaurant_Click(object sender, EventArgs e)
        {
            this.DisableRestaurantSelection();

            this.restaurantFocus = new Restaurant()
            {
                Addresses = new List<Address>
                {
                    new Address()
                    {
                        City = string.Empty,
                        Country = string.Empty,
                        HeadOffice = true,
                        IsEnabled = true,
                        Number = string.Empty,
                        Street = string.Empty,
                        ZipCode = string.Empty
                    }
                },
                Owner = new Owner()
                {
                    FirstName = string.Empty,
                    IsEnabled = true,
                    LastName = string.Empty
                },
                PriceLists = new List<PriceList>()
                {
                    new PriceList
                    {
                        Description = string.Empty,
                        IsEnabled = true,
                        MaximumPrice = 0,
                        MinimumPrice = 0
                    }
                },
                Services = new List<Service>()
                {
                    new Service()
                    {
                        BeginShift = 12,
                        EndShift = 24,
                        IsEnabled = true,
                        PlaceQuantity = 0,
                        ServiceDay = System.DayOfWeek.Monday,
                        TypeService = string.Empty
                    }
                },
                FoodType = this.foodTypes.FirstOrDefault(),
                DayOfClosing = this.daysOfWeek.FirstOrDefault().Value
            };

            this.BindRestaurantDetails();
        }

        /// <summary>
        /// Cancels the "create new restaurant" settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.EnableRestaurantSelection();
        }

        /// <summary>
        /// Creates a new restaurant in the database (sends the request to the controller in order to do so).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddRestaurant_Click(object sender, EventArgs e)
        {
            if (this.CheckCreationConditions())
            {
                bool creationResult = this.restaurantController.CreateRestaurant(this.restaurantFocus);
                string message = creationResult ? "Record successfully added." : "The record could not be added, please try again or contact your administrator.";
                MessageBox.Show(message);
                this.PopulateAndBindRestaurantList();
                this.EnableRestaurantSelection();
            }
        }

        /// <summary>
        /// Modifies the focussed-on restaurant in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonModifyRestaurant_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Deletes the focussed-on restaurant from the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteRestaurant_Click(object sender, EventArgs e)
        {
            bool result = this.restaurantController.DeleteRestaurant(this.restaurantFocus);
            string message = result ? "Record successfully deleted." : "The record could not be deleted, please try again or contact your administrator.";
            MessageBox.Show(message);
            this.PopulateAndBindRestaurantList();
        }

        #endregion EVENTS

    }
}
