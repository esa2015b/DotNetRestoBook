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
        private Reservation reservationFocus;
        private List<Customer> customers;
        private CustomerController customerController;
        private ServiceController serviceController;
        private ReservationController reservationController;
        private Dictionary<int, string> services;
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

            this.BindCustomerList();
            this.PopulateAndBindServiceList();


        }

        private void BindCustomerList()
        {
            this.customers = this.customerController.GetAllCustomer();
            this.dataGridViewCustomers.DataSource = this.customers;

            this.dataGridViewCustomers.Columns[0].ReadOnly = true;
            this.dataGridViewCustomers.Columns[1].ReadOnly = true;
            this.dataGridViewCustomers.Columns[2].ReadOnly = true;
            this.dataGridViewCustomers.Columns[3].Visible = false;
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
            this.dataGridViewReservation.Columns[7].ReadOnly = true;
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

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult sure = MessageBox.Show("Are you sure you want to delete the selected Reservations?", "Delete Reservation", MessageBoxButtons.YesNo);
            if (sure == DialogResult.Yes)
            {
                bool result = false;
                foreach (DataGridViewRow row in this.dataGridViewReservation.SelectedRows)
                {
                    if ((int)row.Cells[0].Value == 0)
                    {
                        this.serviceFocus.Reservations.RemoveAt(row.Index);
                        result = true;
                    }
                    else
                    {
                        result = this.reservationController.DeleteReservation(this.serviceFocus.Reservations.Where(r => r.Id == (int)row.Cells[0].Value).FirstOrDefault());
                    }
                }

                this.PopulateAndBindServiceList();

                this.ResultShowMessagePluralRows(result, "deleted");
            }
        }

        private void buttonAddNewReservation_Click(object sender, EventArgs e)
        {
            Reservation reservation = new Reservation();
            /*
            reservation.ServiceId = this.serviceFocus.Id;
            reservation.CustomerId = this.textBoxCustomerId;
            reservation.PlaceQuantity = this.textBoxPlaceQuantity;
            reservation.RestoComments = this.richTextBoxComment;
            reservation.ReservationDate = this.textBoxDate;
            reservation.Service = this.textBoxService;
            reservation.RestoConfirmation = false;
            reservation.RestoConfirmationDate = DateTime.MaxValue;
            reservation.IsEnabled = true;

            bool result = false;

            result = this.reservationController.
            

            this.PopulateAndBindServiceList();

            this.ResultShowMessagePluralRows(result, "deleted");
            */
        }

        #endregion EVENTS

    }
}
