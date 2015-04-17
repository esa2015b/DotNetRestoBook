using RestoBook.Common.Business.Managers;
using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RestoBook.GUI.View
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PopulateAndBindTabRestaurant();
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

        private void buttonTest_Click(object sender, EventArgs e)
        {
            int restaurantId = int.Parse(comboBoxTest.SelectedItem.ToString());

            Restaurant resto = new Restaurant();
            RestaurantManager rm = new RestaurantManager();
            resto = rm.GetRestaurantById(restaurantId);
            //resto = RestaurantManager.LoadResto(restaurantId);

            textBoxOneRestaurantName.Text = resto.Name.ToString();
            textBoxOneRestaurantDescription.Text = resto.Description.ToString();
            textBoxOneRestaurantFoodType.Text = resto.FoodType.Name.ToString();
            textBoxOneRestaurantOwnerFirstName.Text = resto.Owner.FirstName.ToString();
            textBoxOneRestauantLastName.Text = resto.Owner.LastName.ToString();
            textBoxOneRestaurantMail.Text = resto.Mail.ToString();
            textBoxOneRestaurantPhone.Text = resto.Phone.ToString();
            textBoxOneRestaurantPlaceQuantity.Text = resto.PlaceQuantity.ToString();
            textBoxOneRestaurantDayOfClosing.Text = resto.DayOfClosing.ToString();
        }
    }
}
