using System;
using System.Collections.Generic;
using System.Linq;
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
        private CustomerController customerController;
        private ServiceController serviceController;
        private ReservationController reservationController;
        private Dictionary<int, string> services;
        private Dictionary<int, string> customersDictionary;
        #endregion PROPERTIES


        #region CONSTRUCTOR
        public ReservationView()
        {
            InitializeComponent();
            this.restaurantController = new RestaurantController();
            this.serviceController = new ServiceController();
            this.customerController = new CustomerController();
            this.reservationController = new ReservationController();
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

            this.customersDictionary = this.customerController.GetAllCustomerDictionary();

            this.comboBoxCustomer.DataSource = new BindingSource(this.customersDictionary, null);
            this.comboBoxCustomer.DisplayMember = "Value";
            this.comboBoxCustomer.ValueMember = "Key";

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
            this.dataGridViewReservation.Columns[0].Visible = false;
            this.dataGridViewReservation.Columns[1].Visible = false;
            this.dataGridViewReservation.Columns[7].ReadOnly = false;
            this.dataGridViewReservation.Columns[11].Visible = false;

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
            this.BindReservations();
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            DialogResult sure = MessageBox.Show("Are you sure you want to update the selected Reservations?", "Update Reservation", MessageBoxButtons.YesNo);
            if (sure == DialogResult.Yes)
            {
                bool result = false;
                foreach (DataGridViewRow row in this.dataGridViewReservation.SelectedRows)
                {
                    result = this.reservationController.UpdateReservation(this.serviceFocus.Reservations.Where(r => r.Id == (int)row.Cells[0].Value).FirstOrDefault());
                }
                this.PopulateAndBindServiceList();

                this.ResultShowMessagePluralRows(result, "updated");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult sure = MessageBox.Show("Are you sure you want to delete the selected Reservations?", "Delete Reservation", MessageBoxButtons.YesNo);
            if (sure == DialogResult.Yes)
            {
                bool result = false;
                foreach (DataGridViewRow row in this.dataGridViewReservation.SelectedRows)
                {
                    result = this.reservationController.DeleteReservation(this.serviceFocus.Reservations.Where(r => r.Id == (int)row.Cells[0].Value).FirstOrDefault());
                }

                this.PopulateAndBindServiceList();

                this.ResultShowMessagePluralRows(result, "deleted");
            }
        }

        private void buttonAddNewReservation_Click(object sender, EventArgs e)
        {

            Reservation reservation = new Reservation();
            
            reservation.ServiceId = this.serviceFocus.Id;
            reservation.CustomerId = ((KeyValuePair<int, string>)this.comboBoxCustomer.SelectedItem).Key;
            reservation.PlaceQuantity = (int)this.numericUpDownPlaceQuantity.Value;
            reservation.RestoComments = this.richTextBoxComment.Text;
            reservation.ReservationDate = DateTime.Now;
            reservation.Service = this.serviceFocus.TypeService;
            reservation.RestoConfirmation = false;
            reservation.RestoConfirmationDate = DateTime.MaxValue;
            reservation.IsEnabled = true;

            bool result = false;

            result = this.reservationController.CreateReservation(reservation);
            

            this.PopulateAndBindServiceList();

            this.ResultShowMessagePluralRows(result, "added");
        }

        #endregion EVENTS


    }
}
