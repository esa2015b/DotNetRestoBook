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

        #region PUBLIC METHODS
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

            if(tbFoodTypeName.DataBindings.Count > 0)
            {
                this.tbFoodTypeName.DataBindings.Clear();
                this.tbFoodTypeDescription.DataBindings.Clear();
            }

            this.tbFoodTypeName.DataBindings.Add("Text", this.foodTypes, "Name");
            this.tbFoodTypeDescription.DataBindings.Add("Text", this.foodTypes, "Description");
        }
        #endregion PUBLIC METHODS

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

            this.foodTypeController.CreateFoodType(this.newFoodType);
            this.PopulateAndBindFoodTypes();
            this.btnClear.Enabled = true;
            this.btnCancel.Enabled = false;
            this.btnModifyFoodType.Enabled = true;
            this.btnDeleteFoodType.Enabled = true;
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
            this.foodTypeController.ModifyFoodType(this.foodTypes[this.cbbExistingFoodTypes.SelectedIndex]);
            this.PopulateAndBindFoodTypes();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteFoodType_Click(object sender, EventArgs e)
        {
            this.foodTypeController.DeleteFoodType(this.foodTypes[this.cbbExistingFoodTypes.SelectedIndex]);
            this.PopulateAndBindFoodTypes();
        }
    }
}
