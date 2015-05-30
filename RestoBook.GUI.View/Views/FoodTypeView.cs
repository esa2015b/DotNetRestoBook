using RestoBook.Common.Model.Models;
using RestoBook.GUI.View.Controllers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RestoBook.GUI.View.Views
{
    public partial class FoodTypeView : UserControl
    {
        #region PROPERTIES
        private List<FoodType> foodTypes;
        private FoodTypeController foodTypeController;
        private FoodType newFoodType;
        #endregion PROPERTIES

        #region CONSTRUCTOR
        public FoodTypeView()
        {
            InitializeComponent();
            this.foodTypeController = new FoodTypeController();
            this.PopulateAndBindFoodTypes();
            this.btnCancel.Enabled = false;
        }
        #endregion CONSTRUCTOR

        #region METHODS
        /// <summary>
        /// Populates the local foodtypes list with the foodtypes from database.
        /// </summary>
        private void PopulateAndBindFoodTypes()
        {
            this.foodTypes = null;
            this.foodTypes = this.foodTypeController.GetAllFoodTypes();
            this.BindFoodTypes();
        }

        /// <summary>
        /// Binds the local foodtypes list with the combobox.
        /// </summary>
        private void BindFoodTypes()
        {
            this.cbbExistingFoodTypes.DataSource = this.foodTypes;
            this.cbbExistingFoodTypes.DisplayMember = "Name";
            this.cbbExistingFoodTypes.ValueMember = "Id";

            if (tbFoodTypeName.DataBindings.Count > 0)
            {
                this.tbFoodTypeName.DataBindings.Clear();
                this.tbFoodTypeDescription.DataBindings.Clear();
            }

            this.tbFoodTypeName.DataBindings.Add("Text", this.foodTypes, "Name");
            this.tbFoodTypeDescription.DataBindings.Add("Text", this.foodTypes, "Description");
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

        #endregion METHODS

        #region EVENTS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFoodType_Click(object sender, EventArgs e)
        {
            this.newFoodType = new FoodType()
            {
                Id = 0,
                Name = this.tbFoodTypeName.Text,
                Description = this.tbFoodTypeDescription.Text
            };

            bool result = this.foodTypeController.CreateFoodType(this.newFoodType);
            this.ResultShowMessage(result, "created");
            if (result)
            {
                this.PopulateAndBindFoodTypes();
                this.btnClear.Enabled = true;
                this.btnCancel.Enabled = false;
                this.btnModifyFoodType.Enabled = true;
                this.btnDeleteFoodType.Enabled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.btnClear.Enabled = false;
            this.btnCancel.Enabled = true;
            this.tbFoodTypeName.Text = string.Empty;
            this.tbFoodTypeDescription.Text = string.Empty;
            this.btnModifyFoodType.Enabled = false;
            this.btnDeleteFoodType.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.btnClear.Enabled = true;
            this.btnCancel.Enabled = false;
            this.btnModifyFoodType.Enabled = true;
            this.btnDeleteFoodType.Enabled = true;
            this.PopulateAndBindFoodTypes();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyFoodType_Click(object sender, EventArgs e)
        {
            bool result = this.foodTypeController.ModifyFoodType(this.foodTypes[this.cbbExistingFoodTypes.SelectedIndex]);
            this.ResultShowMessage(result, "modified");

            if (result)
            {
                this.PopulateAndBindFoodTypes();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteFoodType_Click(object sender, EventArgs e)
        {
            bool result = this.foodTypeController.DeleteFoodType(this.foodTypes[this.cbbExistingFoodTypes.SelectedIndex]);
            this.ResultShowMessage(result, "deleted");
            if (result)
            {
                this.PopulateAndBindFoodTypes();
            }
        }

        #endregion EVENTS
    }
}
