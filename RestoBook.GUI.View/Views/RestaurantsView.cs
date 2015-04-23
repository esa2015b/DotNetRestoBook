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
        //private List<Restaurant> restaurants;
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

            comboBoxRestaurants.DataSource = new BindingSource(this.restaurants, null);
            this.comboBoxRestaurants.DisplayMember = "Value";
            this.comboBoxRestaurants.ValueMember = "Key";
        }

        /// <summary>
        /// Populates and binds the details for a specific restaurant chosen in the combobox.
        /// </summary>
        private void PopulateAndBindRestaurantDetails()
        {
            this.restaurantFocus = this.restaurantController.GetRestaurantById(((KeyValuePair<int, string>)this.comboBoxRestaurants.SelectedItem).Key);
            this.BindRestaurantDetails();
        }

        private void BindRestaurantDetails()
        {
            dataGridViewListAddresses.DataSource = this.restaurantFocus;
            dataGridViewListAddresses.DataMember = "Address";

            dataGridViewListServices.DataSource = this.restaurantFocus;
            dataGridViewListServices.DataMember = "Services";

            dataGridViewListPrice.DataSource = this.restaurantFocus;
            dataGridViewListPrice.DataMember = "PriceLists";

            // if the page has been loaded before, clear all existing bindings
            // in order to avoid conflicts.
            if (textBoxFoodType.DataBindings.Count > 0)
            {
                this.ClearRestaurantsDataBindings();
            }

            textBoxFoodType.DataBindings.Add("Text", this.restaurantFocus, "FoodType.Name");
            textBoxRestaurantsName.DataBindings.Add("Text", this.restaurantFocus, "Name");
            textBoxPlaceQuantity.DataBindings.Add("Text", this.restaurantFocus, "PlaceQuantity");
            textBoxDescription.DataBindings.Add("Text", this.restaurantFocus, "Description");
            textBoxDayOfClosing.DataBindings.Add("Text", this.restaurantFocus, "DayOfClosing");
            textBoxMail.DataBindings.Add("Text", this.restaurantFocus, "Mail");
            textBoxPhone.DataBindings.Add("Text", this.restaurantFocus, "Phone");

            textBoxOwnersFirstName.DataBindings.Add("Text", this.restaurantFocus, "Owner.FirstName");
            textBoxOwnerLastName.DataBindings.Add("Text", this.restaurantFocus, ("Owner.LastName"));
        }

        /// <summary>
        /// Clears all the restaurant tab's databindings.
        /// </summary>
        private void ClearRestaurantsDataBindings()
        {
            textBoxFoodType.DataBindings.Clear();
            textBoxRestaurantsName.DataBindings.Clear();
            textBoxPlaceQuantity.DataBindings.Clear();
            textBoxDescription.DataBindings.Clear();
            textBoxDayOfClosing.DataBindings.Clear();
            textBoxMail.DataBindings.Clear();
            textBoxPhone.DataBindings.Clear();
            textBoxOwnersFirstName.DataBindings.Clear();
            textBoxOwnerLastName.DataBindings.Clear();
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
            this.comboBoxRestaurants.Enabled = false;
            this.buttonDeleteRestaurant.Enabled = false;
            this.buttonModifyRestaurant.Enabled = false;
            this.buttonCancel.Enabled = true;

            this.restaurantFocus = new Restaurant()
            {
                Address = new Address()
                {
                    City = string.Empty,
                    Country = string.Empty,
                    HeadOffice = true,
                    IsEnabled = true,
                    Number = string.Empty,
                    Street = string.Empty,
                    ZipCode = string.Empty
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
                FoodType = new FoodType()
                {
                    Description = string.Empty,
                    IsEnabled = true,
                    Name = string.Empty
                }
            };

            this.BindRestaurantDetails();

            //this.textBoxRestaurantsName.Text = string.Empty;
            //this.textBoxFoodType.Text = string.Empty;
            //this.textBoxPlaceQuantity.Text = string.Empty;
            //this.textBoxDayOfClosing.Text = string.Empty;
            //this.textBoxDescription.Text = string.Empty;
            //this.textBoxMail.Text = string.Empty;
            //this.textBoxPhone.Text = string.Empty;
            //this.textBoxOwnersFirstName.Text = string.Empty;
            //this.textBoxOwnerLastName.Text = string.Empty;

            //this.restaurantFocus.Address = new Address();
            //this.restaurantFocus.PriceLists = new List<PriceList>();
            //this.restaurantFocus.Services = new List<Service>();
        }

        /// <summary>
        /// Cancels the "create new restaurant" settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.comboBoxRestaurants.Enabled = true;
            this.buttonDeleteRestaurant.Enabled = true;
            this.buttonModifyRestaurant.Enabled = true;
            this.buttonAddRestaurant.Enabled = false;
            this.buttonCancel.Enabled = false;
            this.PopulateAndBindRestaurantList();
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

        }
        #endregion EVENTS
    }
}
