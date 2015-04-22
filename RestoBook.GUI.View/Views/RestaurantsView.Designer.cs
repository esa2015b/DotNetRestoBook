﻿namespace RestoBook.GUI.View.Views
{
    partial class RestaurantsView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelRestaurantsList = new System.Windows.Forms.Label();
            this.groupBoxRestaurant = new System.Windows.Forms.GroupBox();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelMail = new System.Windows.Forms.Label();
            this.textBoxDayOfClosing = new System.Windows.Forms.TextBox();
            this.labelDayOfClosing = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxPlaceQuantity = new System.Windows.Forms.TextBox();
            this.labelPlaceQuantity = new System.Windows.Forms.Label();
            this.labelFoodType = new System.Windows.Forms.Label();
            this.textBoxFoodType = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxRestaurantsName = new System.Windows.Forms.TextBox();
            this.groupBoxOwner = new System.Windows.Forms.GroupBox();
            this.labelOwnerLastName = new System.Windows.Forms.Label();
            this.textBoxOwnerLastName = new System.Windows.Forms.TextBox();
            this.labelOwnersFirstName = new System.Windows.Forms.Label();
            this.textBoxOwnersFirstName = new System.Windows.Forms.TextBox();
            this.groupBoxServices = new System.Windows.Forms.GroupBox();
            this.groupBoxPriceList = new System.Windows.Forms.GroupBox();
            this.dataGridViewListPrice = new System.Windows.Forms.DataGridView();
            this.dataGridViewListAddresses = new System.Windows.Forms.DataGridView();
            this.groupBoxAddresses = new System.Windows.Forms.GroupBox();
            this.dataGridViewListRestaurants = new System.Windows.Forms.DataGridView();
            this.dataGridViewListServices = new System.Windows.Forms.DataGridView();
            this.groupBoxRestaurant.SuspendLayout();
            this.groupBoxOwner.SuspendLayout();
            this.groupBoxPriceList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListAddresses)).BeginInit();
            this.groupBoxAddresses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListRestaurants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListServices)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRestaurantsList
            // 
            this.labelRestaurantsList.AutoSize = true;
            this.labelRestaurantsList.Location = new System.Drawing.Point(9, 8);
            this.labelRestaurantsList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRestaurantsList.Name = "labelRestaurantsList";
            this.labelRestaurantsList.Size = new System.Drawing.Size(81, 13);
            this.labelRestaurantsList.TabIndex = 21;
            this.labelRestaurantsList.Text = "Restaurant\'s list";
            // 
            // groupBoxRestaurant
            // 
            this.groupBoxRestaurant.Controls.Add(this.textBoxMail);
            this.groupBoxRestaurant.Controls.Add(this.textBoxPhone);
            this.groupBoxRestaurant.Controls.Add(this.labelPhone);
            this.groupBoxRestaurant.Controls.Add(this.labelMail);
            this.groupBoxRestaurant.Controls.Add(this.textBoxDayOfClosing);
            this.groupBoxRestaurant.Controls.Add(this.labelDayOfClosing);
            this.groupBoxRestaurant.Controls.Add(this.textBoxDescription);
            this.groupBoxRestaurant.Controls.Add(this.labelDescription);
            this.groupBoxRestaurant.Controls.Add(this.textBoxPlaceQuantity);
            this.groupBoxRestaurant.Controls.Add(this.labelPlaceQuantity);
            this.groupBoxRestaurant.Controls.Add(this.labelFoodType);
            this.groupBoxRestaurant.Controls.Add(this.textBoxFoodType);
            this.groupBoxRestaurant.Controls.Add(this.labelName);
            this.groupBoxRestaurant.Controls.Add(this.textBoxRestaurantsName);
            this.groupBoxRestaurant.Location = new System.Drawing.Point(12, 160);
            this.groupBoxRestaurant.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxRestaurant.Name = "groupBoxRestaurant";
            this.groupBoxRestaurant.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxRestaurant.Size = new System.Drawing.Size(548, 170);
            this.groupBoxRestaurant.TabIndex = 17;
            this.groupBoxRestaurant.TabStop = false;
            this.groupBoxRestaurant.Text = "Restaurant";
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(93, 146);
            this.textBoxMail.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(260, 20);
            this.textBoxMail.TabIndex = 19;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(401, 146);
            this.textBoxPhone.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(143, 20);
            this.textBoxPhone.TabIndex = 18;
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(360, 149);
            this.labelPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(38, 13);
            this.labelPhone.TabIndex = 17;
            this.labelPhone.Text = "Phone";
            // 
            // labelMail
            // 
            this.labelMail.AutoSize = true;
            this.labelMail.Location = new System.Drawing.Point(5, 151);
            this.labelMail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMail.Name = "labelMail";
            this.labelMail.Size = new System.Drawing.Size(26, 13);
            this.labelMail.TabIndex = 16;
            this.labelMail.Text = "Mail";
            // 
            // textBoxDayOfClosing
            // 
            this.textBoxDayOfClosing.Location = new System.Drawing.Point(237, 63);
            this.textBoxDayOfClosing.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDayOfClosing.Name = "textBoxDayOfClosing";
            this.textBoxDayOfClosing.Size = new System.Drawing.Size(116, 20);
            this.textBoxDayOfClosing.TabIndex = 15;
            // 
            // labelDayOfClosing
            // 
            this.labelDayOfClosing.AutoSize = true;
            this.labelDayOfClosing.Location = new System.Drawing.Point(160, 65);
            this.labelDayOfClosing.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDayOfClosing.Name = "labelDayOfClosing";
            this.labelDayOfClosing.Size = new System.Drawing.Size(74, 13);
            this.labelDayOfClosing.TabIndex = 14;
            this.labelDayOfClosing.Text = "Day of closing";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(93, 86);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(451, 56);
            this.textBoxDescription.TabIndex = 13;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(5, 86);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 12;
            this.labelDescription.Text = "Description";
            // 
            // textBoxPlaceQuantity
            // 
            this.textBoxPlaceQuantity.Location = new System.Drawing.Point(93, 63);
            this.textBoxPlaceQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPlaceQuantity.Name = "textBoxPlaceQuantity";
            this.textBoxPlaceQuantity.Size = new System.Drawing.Size(63, 20);
            this.textBoxPlaceQuantity.TabIndex = 11;
            // 
            // labelPlaceQuantity
            // 
            this.labelPlaceQuantity.AutoSize = true;
            this.labelPlaceQuantity.Location = new System.Drawing.Point(5, 65);
            this.labelPlaceQuantity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlaceQuantity.Name = "labelPlaceQuantity";
            this.labelPlaceQuantity.Size = new System.Drawing.Size(74, 13);
            this.labelPlaceQuantity.TabIndex = 10;
            this.labelPlaceQuantity.Text = "Place quantity";
            // 
            // labelFoodType
            // 
            this.labelFoodType.AutoSize = true;
            this.labelFoodType.Location = new System.Drawing.Point(5, 42);
            this.labelFoodType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFoodType.Name = "labelFoodType";
            this.labelFoodType.Size = new System.Drawing.Size(54, 13);
            this.labelFoodType.TabIndex = 3;
            this.labelFoodType.Text = "Food type";
            // 
            // textBoxFoodType
            // 
            this.textBoxFoodType.Location = new System.Drawing.Point(93, 40);
            this.textBoxFoodType.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxFoodType.Name = "textBoxFoodType";
            this.textBoxFoodType.Size = new System.Drawing.Size(451, 20);
            this.textBoxFoodType.TabIndex = 2;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(5, 20);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name";
            // 
            // textBoxRestaurantsName
            // 
            this.textBoxRestaurantsName.Location = new System.Drawing.Point(93, 17);
            this.textBoxRestaurantsName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxRestaurantsName.Name = "textBoxRestaurantsName";
            this.textBoxRestaurantsName.Size = new System.Drawing.Size(451, 20);
            this.textBoxRestaurantsName.TabIndex = 0;
            // 
            // groupBoxOwner
            // 
            this.groupBoxOwner.Controls.Add(this.labelOwnerLastName);
            this.groupBoxOwner.Controls.Add(this.textBoxOwnerLastName);
            this.groupBoxOwner.Controls.Add(this.labelOwnersFirstName);
            this.groupBoxOwner.Controls.Add(this.textBoxOwnersFirstName);
            this.groupBoxOwner.Location = new System.Drawing.Point(12, 335);
            this.groupBoxOwner.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxOwner.Name = "groupBoxOwner";
            this.groupBoxOwner.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxOwner.Size = new System.Drawing.Size(548, 66);
            this.groupBoxOwner.TabIndex = 18;
            this.groupBoxOwner.TabStop = false;
            this.groupBoxOwner.Text = "Owner";
            // 
            // labelOwnerLastName
            // 
            this.labelOwnerLastName.AutoSize = true;
            this.labelOwnerLastName.Location = new System.Drawing.Point(5, 42);
            this.labelOwnerLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOwnerLastName.Name = "labelOwnerLastName";
            this.labelOwnerLastName.Size = new System.Drawing.Size(56, 13);
            this.labelOwnerLastName.TabIndex = 6;
            this.labelOwnerLastName.Text = "Last name";
            // 
            // textBoxOwnerLastName
            // 
            this.textBoxOwnerLastName.Location = new System.Drawing.Point(74, 40);
            this.textBoxOwnerLastName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxOwnerLastName.Name = "textBoxOwnerLastName";
            this.textBoxOwnerLastName.Size = new System.Drawing.Size(284, 20);
            this.textBoxOwnerLastName.TabIndex = 5;
            // 
            // labelOwnersFirstName
            // 
            this.labelOwnersFirstName.AutoSize = true;
            this.labelOwnersFirstName.Location = new System.Drawing.Point(5, 20);
            this.labelOwnersFirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOwnersFirstName.Name = "labelOwnersFirstName";
            this.labelOwnersFirstName.Size = new System.Drawing.Size(55, 13);
            this.labelOwnersFirstName.TabIndex = 4;
            this.labelOwnersFirstName.Text = "First name";
            // 
            // textBoxOwnersFirstName
            // 
            this.textBoxOwnersFirstName.Location = new System.Drawing.Point(74, 17);
            this.textBoxOwnersFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxOwnersFirstName.Name = "textBoxOwnersFirstName";
            this.textBoxOwnersFirstName.Size = new System.Drawing.Size(284, 20);
            this.textBoxOwnersFirstName.TabIndex = 1;
            // 
            // groupBoxServices
            // 
            this.groupBoxServices.Location = new System.Drawing.Point(564, 160);
            this.groupBoxServices.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxServices.Name = "groupBoxServices";
            this.groupBoxServices.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxServices.Size = new System.Drawing.Size(580, 241);
            this.groupBoxServices.TabIndex = 20;
            this.groupBoxServices.TabStop = false;
            this.groupBoxServices.Text = "Services";
            // 
            // groupBoxPriceList
            // 
            this.groupBoxPriceList.Controls.Add(this.dataGridViewListPrice);
            this.groupBoxPriceList.Location = new System.Drawing.Point(12, 402);
            this.groupBoxPriceList.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxPriceList.Name = "groupBoxPriceList";
            this.groupBoxPriceList.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxPriceList.Size = new System.Drawing.Size(472, 115);
            this.groupBoxPriceList.TabIndex = 22;
            this.groupBoxPriceList.TabStop = false;
            this.groupBoxPriceList.Text = "Prices\'s list";
            // 
            // dataGridViewListPrice
            // 
            this.dataGridViewListPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListPrice.Location = new System.Drawing.Point(4, 17);
            this.dataGridViewListPrice.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewListPrice.Name = "dataGridViewListPrice";
            this.dataGridViewListPrice.Size = new System.Drawing.Size(463, 93);
            this.dataGridViewListPrice.TabIndex = 14;
            // 
            // dataGridViewListAddresses
            // 
            this.dataGridViewListAddresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListAddresses.Location = new System.Drawing.Point(5, 17);
            this.dataGridViewListAddresses.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewListAddresses.Name = "dataGridViewListAddresses";
            this.dataGridViewListAddresses.RowHeadersVisible = false;
            this.dataGridViewListAddresses.RowTemplate.Height = 24;
            this.dataGridViewListAddresses.Size = new System.Drawing.Size(646, 93);
            this.dataGridViewListAddresses.TabIndex = 0;
            // 
            // groupBoxAddresses
            // 
            this.groupBoxAddresses.Controls.Add(this.dataGridViewListAddresses);
            this.groupBoxAddresses.Location = new System.Drawing.Point(489, 402);
            this.groupBoxAddresses.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxAddresses.Name = "groupBoxAddresses";
            this.groupBoxAddresses.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxAddresses.Size = new System.Drawing.Size(656, 115);
            this.groupBoxAddresses.TabIndex = 19;
            this.groupBoxAddresses.TabStop = false;
            this.groupBoxAddresses.Text = "Adresses";
            // 
            // dataGridViewListRestaurants
            // 
            this.dataGridViewListRestaurants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListRestaurants.Location = new System.Drawing.Point(12, 26);
            this.dataGridViewListRestaurants.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewListRestaurants.Name = "dataGridViewListRestaurants";
            this.dataGridViewListRestaurants.RowHeadersVisible = false;
            this.dataGridViewListRestaurants.RowTemplate.Height = 24;
            this.dataGridViewListRestaurants.Size = new System.Drawing.Size(1133, 130);
            this.dataGridViewListRestaurants.TabIndex = 16;
            // 
            // dataGridViewListServices
            // 
            this.dataGridViewListServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListServices.Location = new System.Drawing.Point(568, 180);
            this.dataGridViewListServices.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewListServices.Name = "dataGridViewListServices";
            this.dataGridViewListServices.RowHeadersVisible = false;
            this.dataGridViewListServices.RowTemplate.Height = 24;
            this.dataGridViewListServices.Size = new System.Drawing.Size(572, 215);
            this.dataGridViewListServices.TabIndex = 23;
            // 
            // RestaurantsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewListServices);
            this.Controls.Add(this.groupBoxAddresses);
            this.Controls.Add(this.groupBoxPriceList);
            this.Controls.Add(this.groupBoxServices);
            this.Controls.Add(this.groupBoxOwner);
            this.Controls.Add(this.groupBoxRestaurant);
            this.Controls.Add(this.dataGridViewListRestaurants);
            this.Controls.Add(this.labelRestaurantsList);
            this.Name = "RestaurantsView";
            this.Size = new System.Drawing.Size(1169, 533);
            this.groupBoxRestaurant.ResumeLayout(false);
            this.groupBoxRestaurant.PerformLayout();
            this.groupBoxOwner.ResumeLayout(false);
            this.groupBoxOwner.PerformLayout();
            this.groupBoxPriceList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListAddresses)).EndInit();
            this.groupBoxAddresses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListRestaurants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRestaurantsList;
        private System.Windows.Forms.GroupBox groupBoxRestaurant;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelMail;
        private System.Windows.Forms.TextBox textBoxDayOfClosing;
        private System.Windows.Forms.Label labelDayOfClosing;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxPlaceQuantity;
        private System.Windows.Forms.Label labelPlaceQuantity;
        private System.Windows.Forms.Label labelFoodType;
        private System.Windows.Forms.TextBox textBoxFoodType;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxRestaurantsName;
        private System.Windows.Forms.GroupBox groupBoxOwner;
        private System.Windows.Forms.Label labelOwnerLastName;
        private System.Windows.Forms.TextBox textBoxOwnerLastName;
        private System.Windows.Forms.Label labelOwnersFirstName;
        private System.Windows.Forms.TextBox textBoxOwnersFirstName;
        private System.Windows.Forms.GroupBox groupBoxServices;
        private System.Windows.Forms.GroupBox groupBoxPriceList;
        private System.Windows.Forms.DataGridView dataGridViewListPrice;
        private System.Windows.Forms.DataGridView dataGridViewListAddresses;
        private System.Windows.Forms.GroupBox groupBoxAddresses;
        private System.Windows.Forms.DataGridView dataGridViewListRestaurants;
        private System.Windows.Forms.DataGridView dataGridViewListServices;

    }
}
