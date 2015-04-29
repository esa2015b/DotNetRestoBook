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
            //this.buttonCancel.Enabled = false;
            //this.buttonAddRestaurant.Enabled = false;
            this.EnableRestaurantSelection();
            this.DisableAddressCreation();
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
            this.dataGridViewListServices.DataSource = this.restaurantFocus;
            this.dataGridViewListServices.DataMember = "Services";
            this.dataGridViewListServices.Columns[0].ReadOnly = true;

            this.dataGridViewListPrice.DataSource = this.restaurantFocus;
            this.dataGridViewListPrice.DataMember = "PriceLists";
            this.dataGridViewListPrice.Columns[0].ReadOnly = true;

            this.dataGridViewEmployees.DataSource = this.restaurantFocus;
            this.dataGridViewEmployees.DataMember = "Employees";
            this.dataGridViewEmployees.Columns[0].ReadOnly = true;

            // if the page has been loaded before, clear all existing bindings
            // in order to avoid conflicts.
            if (textBoxRestaurantsName.DataBindings.Count > 0)
                this.ClearRestaurantsDataBindings();

            // create a new address object if there are no addresses present.
            if (this.restaurantFocus.Addresses.Count < 1)
            {
                this.buttonNewAddress_Click(null, null);
                MessageBox.Show("Please add an address for this restaurant.");
            }

            this.comboBoxAddresses.DataSource = this.restaurantFocus.Addresses;
            this.comboBoxAddresses.DisplayMember = "City";
            this.comboBoxAddresses.ValueMember = "Id";

            this.comboBoxFoodType.SelectedValue = this.restaurantFocus.FoodType.Id;
            this.textBoxRestaurantsName.DataBindings.Add("Text", this.restaurantFocus, "Name");
            this.textBoxPlaceQuantity.DataBindings.Add("Text", this.restaurantFocus, "PlaceQuantity");
            this.textBoxDescription.DataBindings.Add("Text", this.restaurantFocus, "Description");

            this.comboBoxDayOfClosing.SelectedValue = this.restaurantFocus.DayOfClosing.ToLower();
            this.textBoxMail.DataBindings.Add("Text", this.restaurantFocus, "Mail");
            this.textBoxPhone.DataBindings.Add("Text", this.restaurantFocus, "Phone");

            this.textBoxOwnersFirstName.DataBindings.Add("Text", this.restaurantFocus, "Owner.FirstName");
            this.textBoxOwnerLastName.DataBindings.Add("Text", this.restaurantFocus, ("Owner.LastName"));

            this.comboBoxAddresses.SelectedValue = this.restaurantFocus.Addresses[0].Id;
            this.textBoxStreet.DataBindings.Add("Text", this.restaurantFocus.Addresses, "Street");
            this.textBoxStreetNumber.DataBindings.Add("Text", this.restaurantFocus.Addresses, "Number");
            this.textBoxZipCode.DataBindings.Add("Text", this.restaurantFocus.Addresses, "Zipcode");
            this.textBoxCity.DataBindings.Add("Text", this.restaurantFocus.Addresses, "City");
            this.textBoxCountry.DataBindings.Add("Text", this.restaurantFocus.Addresses, "Country");
            this.checkBoxAddressIsEnabled.DataBindings.Add("CheckState", this.restaurantFocus.Addresses, "IsEnabled", true);
            this.checkBoxHeadOffice.DataBindings.Add("CheckState", this.restaurantFocus.Addresses, "HeadOffice", true);
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
            checkBoxAddressIsEnabled.DataBindings.Clear();
            checkBoxHeadOffice.DataBindings.Clear();
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
                restaurantFocus.Addresses.Count > 0 &&

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
            this.groupBoxAddress.Enabled = true;
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
            this.groupBoxAddress.Enabled = false;
            this.buttonCancel.Enabled = true;
        }

        /// <summary>
        /// Enables the address creation items.
        /// </summary>
        private void EnableAddressCreation()
        {
            this.comboBoxAddresses.Enabled = false;
            this.groupBoxOwner.Enabled = false;
            this.groupBoxPriceList.Enabled = false;
            this.groupBoxRestaurant.Enabled = false;
            this.groupBoxServices.Enabled = false;
            this.buttonNewRestaurant.Enabled = false;
            this.comboBoxRestaurants.Enabled = false;
            this.checkBoxAddressIsEnabled.Enabled = true;
            this.checkBoxHeadOffice.Enabled = true;
            this.buttonModifyRestaurant.Enabled = false;
            this.buttonDeleteRestaurant.Enabled = false;

            this.buttonAddAddress.Enabled = true;
            this.buttonDeleteAddress.Enabled = false;
            this.buttonNewAddress.Enabled = false;
            this.buttonCancelAddress.Enabled = true;
        }

        /// <summary>
        /// Disables the address creation items.
        /// </summary>
        private void DisableAddressCreation()
        {
            this.comboBoxAddresses.Enabled = true;
            this.groupBoxOwner.Enabled = true;
            this.groupBoxPriceList.Enabled = true;
            this.groupBoxRestaurant.Enabled = true;
            this.groupBoxServices.Enabled = true;
            this.buttonNewRestaurant.Enabled = true;
            this.comboBoxRestaurants.Enabled = true;
            this.checkBoxAddressIsEnabled.Enabled = false;
            this.checkBoxHeadOffice.Enabled = false;
            this.buttonModifyRestaurant.Enabled = true;
            this.buttonDeleteRestaurant.Enabled = true;

            this.buttonAddAddress.Enabled = false;
            this.buttonDeleteAddress.Enabled = true;
            this.buttonNewAddress.Enabled = true;
            this.buttonCancelAddress.Enabled = false;
        }

        /// <summary>
        /// Resets the address combobox datasource.
        /// </summary>
        private void ResetAddressDataSource()
        {
            this.comboBoxAddresses.DataSource = null;
            this.comboBoxAddresses.DataSource = this.restaurantFocus.Addresses;
            this.comboBoxAddresses.DisplayMember = "City";
            this.comboBoxAddresses.ValueMember = "Id";
        }

        /// <summary>
        /// Shows the result message in a messagebox.
        /// </summary>
        /// <param name="result">True for successful message, false for unsuccessful.</param>
        private void ResultShowMessage(bool result, string action)
        {
            string message = result ?
                                string.Format("Record successfully {0}.", action) :
                                string.Format("The record could not be {0}, please try again or contact your administrator.", action);
            MessageBox.Show(message);
        }

        /// <summary>
        /// Shows the result message for plural rows in a messagebox.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="action"></parparam>
        private void ResultShowMessagePluralRows(bool result, string action)
        {
            string message = result ?
                                string.Format("All requested records have been successfully {0}.", action) :
                                string.Format("The records could not be {0}, please try again or contact your administrator.", action);
            MessageBox.Show(message);
        }

        /// <summary>
        /// Clears the existing datagridview's datasource, and reconnects the required binding.
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="bindingObject"></param>
        /// <param name="dataMember"></param>
        public void ClearDGVBindingsAndPopulate(DataGridView dgv, string dataMember)
        {
            dgv.DataSource = null;
            dgv.DataSource = this.restaurantFocus;
            dgv.DataMember = dataMember;
            dgv.Refresh();
        }
        #endregion METHODS


        #region EVENTS

        #region RESTAURANT

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
        /// Refreshes the data for the current restaurant.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefreshRestaurantData_Click(object sender, EventArgs e)
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
                ResultShowMessage(creationResult, "created");
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
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to modify this restaurant?", "Modify restaurant", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool result = this.restaurantController.ModifyRestaurant(this.restaurantFocus);
                this.ResultShowMessage(result, "modified");
                this.PopulateAndBindRestaurantDetails();
                //this.DisableAddressCreation();
            }
        }

        /// <summary>
        /// Deletes the focussed-on restaurant from the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteRestaurant_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this restaurant?", "Delete restaurant", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool result = this.restaurantController.DeleteRestaurant(this.restaurantFocus);
                string message = result ? "Record successfully deleted." : "The record could not be deleted, please try again or contact your administrator.";
                MessageBox.Show(message);
                this.PopulateAndBindRestaurantList();
            }
        }

        #endregion RESTAURANT

        #region ADDRESS

        /// <summary>
        /// In order to create a new address.
        /// This event clears all the fields of the address, and disables certain buttons
        /// in order to avoid interference.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNewAddress_Click(object sender, EventArgs e)
        {
            this.EnableAddressCreation();
            this.restaurantFocus.Addresses.Add(new Address()
                {
                    City = "<new>",
                    Country = string.Empty,
                    HeadOffice = true,
                    IsEnabled = true,
                    Number = string.Empty,
                    Street = string.Empty,
                    ZipCode = string.Empty
                });

            this.ResetAddressDataSource();
            this.comboBoxAddresses.DataBindings.Clear();
            if (this.restaurantFocus.Addresses != null && this.restaurantFocus.Addresses.Count > 0)
                this.comboBoxAddresses.SelectedIndex = this.restaurantFocus.Addresses.Count - 1;
            this.comboBoxAddresses.Enabled = false;
        }

        /// <summary>
        /// Cancels the "create new address" settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancelAddress_Click(object sender, EventArgs e)
        {
            this.DisableAddressCreation();
            this.restaurantFocus.Addresses.RemoveAt(this.restaurantFocus.Addresses.Count - 1);

            this.ResetAddressDataSource();

            if (this.restaurantFocus.Addresses != null && this.restaurantFocus.Addresses.Count > 0)
                this.comboBoxAddresses.SelectedIndex = 0;
            this.comboBoxAddresses.Enabled = true;
        }

        /// <summary>
        /// Creates an address, by calling the controller, to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddAddress_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.textBoxStreet.Text) &&
                !string.IsNullOrEmpty(this.textBoxStreetNumber.Text) &&
                !string.IsNullOrEmpty(this.textBoxZipCode.Text) &&
                !string.IsNullOrEmpty(this.textBoxCity.Text) &&
                !string.IsNullOrEmpty(this.textBoxCountry.Text)
                )
            {
                bool creationResult = this.restaurantController.CreateAddress(this.restaurantFocus.Addresses.LastOrDefault(), this.restaurantFocus.Id);
                this.ResultShowMessage(creationResult, "created");
                this.PopulateAndBindRestaurantDetails();
                this.DisableAddressCreation();
            }
        }

        /// <summary>
        /// Deletes an address, by calling the controller, from the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteAddress_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this address?", "Delete address", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool result = this.restaurantController.DeleteAddress(this.restaurantFocus.Addresses.Where(a => a.Id == (int)this.comboBoxAddresses.SelectedValue).FirstOrDefault(), this.restaurantFocus.Id);
                this.ResultShowMessage(result, "deleted");
                this.PopulateAndBindRestaurantDetails();
                //this.DisableAddressCreation();
            }
        }

        #endregion ADDRESS

        #region SERVICES

        /// <summary>
        /// Adds a service object to the restaurant object.
        /// A.T.T.E.N.T.I.O.N. => ! ! ! This event doesn't add the object to the database, in  order
        ///                       to do so, you'll need to modify/create the restaurant ! ! !
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddServiceRow_Click(object sender, EventArgs e)
        {
            this.restaurantFocus.Services.Add(new Service()
                {
                    BeginShift = 12,
                    EndShift = 15,
                    IsEnabled = true,
                    PlaceQuantity = 0,
                    ServiceDate = new DateTime(),
                    ServiceDay = DayOfWeek.Monday,
                    TypeService = "Midi"
                });
            this.ClearDGVBindingsAndPopulate(this.dataGridViewListServices, "Services");
            this.dataGridViewListServices.FirstDisplayedScrollingRowIndex = this.dataGridViewListServices.Rows.Count - 1;
            this.dataGridViewListServices.Rows[this.dataGridViewListServices.Rows.Count - 1].Cells[1].Selected = true;

            //this.PopulateAndBindRestaurantDetails();
        }

        /// <summary>
        /// Adds all newly added rows to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddServiceRows_Click(object sender, EventArgs e)
        {
            this.restaurantFocus.Services.Where(s => s.Id == 0).ToList().ForEach(s => this.restaurantController.CreateService(s, this.restaurantFocus.Id));

            this.PopulateAndBindRestaurantDetails();
            this.ResultShowMessagePluralRows(true, "created");
        }

        /// <summary>
        /// Removes the rows from the service collection.
        /// If the rows aren't created in the database yet, they are simply removed from the services in the restaurantFocus object,
        /// otherwise a call is made to the controler in order to also remove them from the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemoveServices_Click(object sender, EventArgs e)
        {
            DialogResult sure = MessageBox.Show("Are you sure you want to delete the selected services?", "Delete Services", MessageBoxButtons.YesNo);
            if (sure == DialogResult.Yes)
            {
                bool result = false;
                foreach (DataGridViewRow row in this.dataGridViewListServices.SelectedRows)
                {
                    if ((int)row.Cells[0].Value == 0)
                        this.restaurantFocus.Services.RemoveAt(row.Index);
                    else
                    {
                        result = this.restaurantController
                                     .DeleteService(this.restaurantFocus.Services.Where(s => s.Id == (int)row.Cells[0].Value).FirstOrDefault(), this.restaurantFocus.Id);
                    }

                }
                this.PopulateAndBindRestaurantDetails();
                this.ResultShowMessagePluralRows(result, "deleted");
            }
        }

        #endregion SERVICES

        #region PRICELISTS
        /// <summary>
        /// Adds a pricelist object to the restaurantFocus.pricelists.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddPriceListRow_Click(object sender, EventArgs e)
        {
            this.restaurantFocus.PriceLists.Add(new PriceList()
                {
                    Id = 0,
                    Description = string.Empty,
                    IsEnabled = true,
                    MaximumPrice = 0,
                    MinimumPrice = 0
                });
            this.ClearDGVBindingsAndPopulate(this.dataGridViewListPrice, "PriceLists");
            this.dataGridViewListPrice.FirstDisplayedScrollingRowIndex = this.dataGridViewListPrice.Rows.Count - 1;
            this.dataGridViewListPrice.Rows[this.dataGridViewListPrice.Rows.Count - 1].Cells[1].Selected = true;
            //this.PopulateAndBindRestaurantDetails();
        }

        /// <summary>
        /// Adds all the newly created pricelists to the database, by calling the controller.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddPricelists_Click(object sender, EventArgs e)
        {
            this.restaurantFocus.PriceLists.Where(p => p.Id == 0).ToList().ForEach(p => this.restaurantController.CreatePriceList(p, this.restaurantFocus.Id));

            this.PopulateAndBindRestaurantDetails();
            this.ResultShowMessagePluralRows(true, "created");
        }

        /// <summary>
        /// Removes the pricelists from the restaurantFocus.PriceLists OR from the database if required.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemovePricelists_Click(object sender, EventArgs e)
        {
            DialogResult sure = MessageBox.Show("Are you sure you want to delete the selected pricelists?", "Delete pricelists", MessageBoxButtons.YesNo);
            if (sure == DialogResult.Yes)
            {
                bool result = false;
                foreach (DataGridViewRow row in this.dataGridViewListPrice.SelectedRows)
                {
                    if ((int)row.Cells[0].Value == 0)
                    { this.restaurantFocus.Services.RemoveAt(row.Index); result = true; }
                    else
                    {
                        result = this.restaurantController
                                     .DeletePriceList(this.restaurantFocus.PriceLists.Where(p => p.Id == (int)row.Cells[0].Value).FirstOrDefault(), this.restaurantFocus.Id);
                    }
                }
                this.PopulateAndBindRestaurantDetails();

                this.ResultShowMessagePluralRows(result, "deleted");
            }
        }

        #endregion PRICELISTS

        #region EMPLOYEES
        /// <summary>
        /// Adds an employee to the restaurantFocus.Employees.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddEmployeeRow_Click(object sender, EventArgs e)
        {
            this.restaurantFocus.Employees.Add(new Employee()
                {
                    Id = 0,
                    Email = string.Empty,
                    FirstName = string.Empty,
                    IsEnabled = true,
                    LastName = string.Empty,
                    Login = string.Empty,
                    Mobile = string.Empty,
                    Password = string.Empty,
                    RestaurantId = new List<int>() { this.restaurantFocus.Id }
                });
            this.ClearDGVBindingsAndPopulate(this.dataGridViewEmployees, "Employees");
            this.dataGridViewEmployees.FirstDisplayedScrollingRowIndex = this.dataGridViewEmployees.Rows.Count - 1;
            this.dataGridViewEmployees.Rows[this.dataGridViewEmployees.Rows.Count - 1].Cells[1].Selected = true;
        }

        /// <summary>
        /// Adds all the newly created employees to the database, by calling the required method from the restaurantcontroller.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddNewEmployees_Click(object sender, EventArgs e)
        {
            this.restaurantFocus.Employees.Where(em => em.Id == 0).ToList().ForEach(em => this.restaurantController.CreateEmployee(em, this.restaurantFocus.Id));

            this.PopulateAndBindRestaurantDetails();
            this.ResultShowMessagePluralRows(true, "created");
        }

        /// <summary>
        /// Removes the selected employees from the restaurantFocus.Employees OR from the database if required.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemoveEmployees_Click(object sender, EventArgs e)
        {
            DialogResult sure = MessageBox.Show("Are you sure you want to delete the selected employees?", "Delete employees", MessageBoxButtons.YesNo);
            if (sure == DialogResult.Yes)
            {
                bool result = false;
                foreach (DataGridViewRow row in this.dataGridViewEmployees.SelectedRows)
                {
                    if ((int)row.Cells[0].Value == 0)
                    {
                        this.restaurantFocus.Services.RemoveAt(row.Index);
                        result = true;
                    }
                    else
                    {
                        result = this.restaurantController.DeleteEmployee(this.restaurantFocus.Employees.Where(em => em.Id == (int)row.Cells[0].Value).FirstOrDefault(), this.restaurantFocus.Id);
                    }
                }

                this.PopulateAndBindRestaurantDetails();

                this.ResultShowMessagePluralRows(result, "deleted");
            }
        }

        #endregion EMPLOYEES

        #endregion EVENTS
    }
}
