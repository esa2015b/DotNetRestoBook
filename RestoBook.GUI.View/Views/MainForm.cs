using RestoBook.Common.Business.Managers;
using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RestoBook.GUI.View.Views
{
    public partial class MainForm : Form
    {
        #region MEMBERS
        //private bool foodTypeTabIsInstantiated;
        //private bool restaurantsTabIsInstantiated;
        //private bool oneRestaurantTabIsInstantiated;
        //private bool reservationsTabIsInstantiated;
        #endregion MEMBERS

        #region CONSTRUCTOR
        public MainForm()
        {
            InitializeComponent();
            //// set all the "xxxIsInstantiated" properties to false.
            //// Every time one of these properties is loaded, the value is set to "True",
            //// so that the same usercontrol won't be reloaded over and over again.
            //this.foodTypeTabIsInstantiated = false;
            //this.restaurantsTabIsInstantiated = false;
            //this.oneRestaurantTabIsInstantiated = false;
            //this.reservationsTabIsInstantiated = false;
        }
        #endregion CONSTRUCTOR

        #region EVENTS
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.tabControlOneRestaurantOwnerFirstName_Selecting(this.tcRestoBook, new TabControlCancelEventArgs(tabPageFoodType, 0, false, TabControlAction.Selected));
        }

        /// <summary>
        /// Loads the required control to the selected tab.
        /// </summary>
        /// <param name="sender">The tabcontrolRestobook</param>
        /// <param name="e">The selected tab.</param>
        private void tabControlOneRestaurantOwnerFirstName_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabPageRestaurants /*&& !this.restaurantsTabIsInstantiated*/)
            {
                RestaurantsView restaurantsView = new RestaurantsView();
                tabPageRestaurants.Controls.Add(restaurantsView);
                //this.restaurantsTabIsInstantiated = true;
            }
            else if (e.TabPage == tabPageFoodType /*&& !this.foodTypeTabIsInstantiated*/)
            {
                FoodTypeView foodTypeView = new FoodTypeView();
                tabPageFoodType.Controls.Add(foodTypeView);
                //this.foodTypeTabIsInstantiated = true;
            }
            else if(e.TabPage == tabPageReservations /*&& !this.reservationsTabIsInstantiated*/)
            {
                //this.reservationsTabIsInstantiated = true;
            }

        }
        #endregion


    }
}
