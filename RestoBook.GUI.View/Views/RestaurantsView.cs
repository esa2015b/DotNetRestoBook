using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestoBook.Common.Business.Managers;

namespace RestoBook.GUI.View.Views
{
    public partial class RestaurantsView : UserControl
    {
        public RestaurantsView()
        {
            InitializeComponent();
            this.PopulateAndBindTabRestaurant();
        }

        /// <summary>
        /// Method that binds datas coming from RestoBook.GUI.Business layer to MainForm's controls.
        /// Only to show test datas 
        /// </summary>
        private void PopulateAndBindTabRestaurant()
        {
            DataSet ds = new DataSet();
            RestaurantManager rm = new RestaurantManager();
            ds = rm.GetAllRestaurants();

            dataGridViewListRestaurants.DataSource = ds;
            dataGridViewListRestaurants.DataMember = "Restaurant";

            dataGridViewListAddresses.DataSource = ds;
            dataGridViewListAddresses.DataMember = "Restaurant.Restaurant_Address";

            dataGridViewListServices.DataSource = ds;
            dataGridViewListServices.DataMember = "Restaurant.Restaurant_Service";

            dataGridViewListPrice.DataSource = ds;
            dataGridViewListPrice.DataMember = "Restaurant.Restaurant_PriceList";

            // if the page has been loaded before, clear all existing bindings
            // in order to avoid conflicts.
            if (textBoxFoodType.DataBindings.Count > 0)
            {
                this.ClearRestaurantsDataBindings();
            }

            textBoxFoodType.DataBindings.Add("Text", ds, "Restaurant.Restaurant_FoodType.Name");
            textBoxRestaurantsName.DataBindings.Add("Text", ds, "Restaurant.Name");
            textBoxPlaceQuantity.DataBindings.Add("Text", ds, "Restaurant.PlaceQuantity");
            textBoxDescription.DataBindings.Add("Text", ds, "Restaurant.Description");
            textBoxDayOfClosing.DataBindings.Add("Text", ds, "Restaurant.DayOfClosing");
            textBoxMail.DataBindings.Add("Text", ds, "Restaurant.Mail");
            textBoxPhone.DataBindings.Add("Text", ds, "Restaurant.Phone");

            textBoxOwnersFirstName.DataBindings.Add("Text", ds, "Restaurant.Restaurant_Owner.FirstName");
            textBoxOwnerLastName.DataBindings.Add("Text", ds, ("Restaurant.Restaurant_Owner.LastName"));
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

    }
}
