using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestoBook.Common.Model.Models;
using RestoBook.GUI.View.Controllers;

namespace RestoBook.GUI.View.Views
{
    public partial class ReservationView : UserControl
    {
        #region PROPERTIES
        private Dictionary<int, string> restaurants;
        private RestaurantController restaurantController;
        private Service serviceFocus;
        private ServiceController serviceController;
        private Dictionary<int, string> services;
        #endregion PROPERTIES


        #region CONSTRUCTOR
        public ReservationView()
        {
            InitializeComponent();
            this.restaurantController = new RestaurantController();
            this.serviceController = new ServiceController();
            this.PopulateAndBindRestaurantList();
        }
        #endregion CONSTRUCTOR


        #region METHODS
        private void PopulateAndBindRestaurantList()
        {
            this.restaurants = this.restaurantController.GetAllRestaurants();

            this.comboBoxRestaurant.DataSource = new BindingSource(this.restaurants, null);
            this.comboBoxRestaurant.DisplayMember = "Value";
            this.comboBoxRestaurant.ValueMember = "Key";

            this.PopulateAndBindServiceList();


        }

        private void PopulateAndBindServiceList()
        {
            this.services = this.serviceController.GetServiceDictionary(((KeyValuePair<int, string>)this.comboBoxRestaurant.SelectedItem).Key);
            this.BindServices();
        }

        private void BindServices()
        {
            this.comboBoxService.DataSource = new BindingSource(this.services, null);
            this.comboBoxService.DisplayMember = "Value";
            this.comboBoxService.ValueMember = "Key";

            this.BindReservations();
            comboBoxService.DataBindings.Clear();
        }

        private void BindReservations()
        {
            this.serviceFocus = this.serviceController.GetServiceById(((KeyValuePair<int, string>)this.comboBoxService.SelectedItem).Key);

            this.dataGridViewReservation.DataSource = this.serviceFocus;
            this.dataGridViewReservation.DataMember = "Reservations";
            this.dataGridViewReservation.Columns[0].ReadOnly = true;
        }
        public void ClearDGVBindingsAndPopulate(DataGridView dgv, string dataMember)
        {
            dgv.DataSource = null;
            dgv.DataSource = this.serviceFocus;
            dgv.DataMember = dataMember;
            dgv.Refresh();
        }

        private void ResultShowMessagePluralRows(bool result, string action)
        {
            string message = result ?
                                string.Format("All requested records have been successfully {0}.", action) :
                                string.Format("The records could not be {0}, please try again or contact your administrator.", action);
            MessageBox.Show(message);
        }

        #endregion METHODS


        #region EVENTS

        private void comboBoxRestaurant_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulateAndBindServiceList();

        }

        private void comboBoxService_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindServices();
        }

        private void dataGridViewReservation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddNewReservation_Click(object sender, EventArgs e)
        {

        }

        #endregion EVENTS
    }
}
