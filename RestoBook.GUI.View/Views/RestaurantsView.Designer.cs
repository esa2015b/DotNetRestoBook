namespace RestoBook.GUI.View.Views
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
            this.comboBoxDayOfClosing = new System.Windows.Forms.ComboBox();
            this.comboBoxFoodType = new System.Windows.Forms.ComboBox();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelMail = new System.Windows.Forms.Label();
            this.labelDayOfClosing = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxPlaceQuantity = new System.Windows.Forms.TextBox();
            this.labelPlaceQuantity = new System.Windows.Forms.Label();
            this.labelFoodType = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxRestaurantsName = new System.Windows.Forms.TextBox();
            this.groupBoxOwner = new System.Windows.Forms.GroupBox();
            this.labelOwnerLastName = new System.Windows.Forms.Label();
            this.textBoxOwnerLastName = new System.Windows.Forms.TextBox();
            this.labelOwnersFirstName = new System.Windows.Forms.Label();
            this.textBoxOwnersFirstName = new System.Windows.Forms.TextBox();
            this.groupBoxServices = new System.Windows.Forms.GroupBox();
            this.buttonRemoveService = new System.Windows.Forms.Button();
            this.buttonAddService = new System.Windows.Forms.Button();
            this.dataGridViewListServices = new System.Windows.Forms.DataGridView();
            this.groupBoxPriceList = new System.Windows.Forms.GroupBox();
            this.dataGridViewListPrice = new System.Windows.Forms.DataGridView();
            this.groupBoxAddress = new System.Windows.Forms.GroupBox();
            this.buttonCancelAddress = new System.Windows.Forms.Button();
            this.buttonDeleteAddress = new System.Windows.Forms.Button();
            this.buttonNewAddress = new System.Windows.Forms.Button();
            this.buttonAddAddress = new System.Windows.Forms.Button();
            this.comboBoxAddresses = new System.Windows.Forms.ComboBox();
            this.checkBoxAddressIsEnabled = new System.Windows.Forms.CheckBox();
            this.checkBoxHeadOffice = new System.Windows.Forms.CheckBox();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.labelCity = new System.Windows.Forms.Label();
            this.textBoxStreetNumber = new System.Windows.Forms.TextBox();
            this.labelStreetNumber = new System.Windows.Forms.Label();
            this.textBoxCountry = new System.Windows.Forms.TextBox();
            this.textBoxZipCode = new System.Windows.Forms.TextBox();
            this.textBoxStreet = new System.Windows.Forms.TextBox();
            this.labelCountry = new System.Windows.Forms.Label();
            this.labelZipCode = new System.Windows.Forms.Label();
            this.labelStreet = new System.Windows.Forms.Label();
            this.comboBoxRestaurants = new System.Windows.Forms.ComboBox();
            this.buttonAddRestaurant = new System.Windows.Forms.Button();
            this.buttonModifyRestaurant = new System.Windows.Forms.Button();
            this.buttonDeleteRestaurant = new System.Windows.Forms.Button();
            this.buttonNewRestaurant = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxRestaurant.SuspendLayout();
            this.groupBoxOwner.SuspendLayout();
            this.groupBoxServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListServices)).BeginInit();
            this.groupBoxPriceList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListPrice)).BeginInit();
            this.groupBoxAddress.SuspendLayout();
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
            this.groupBoxRestaurant.Controls.Add(this.comboBoxDayOfClosing);
            this.groupBoxRestaurant.Controls.Add(this.comboBoxFoodType);
            this.groupBoxRestaurant.Controls.Add(this.textBoxMail);
            this.groupBoxRestaurant.Controls.Add(this.textBoxPhone);
            this.groupBoxRestaurant.Controls.Add(this.labelPhone);
            this.groupBoxRestaurant.Controls.Add(this.labelMail);
            this.groupBoxRestaurant.Controls.Add(this.labelDayOfClosing);
            this.groupBoxRestaurant.Controls.Add(this.textBoxDescription);
            this.groupBoxRestaurant.Controls.Add(this.labelDescription);
            this.groupBoxRestaurant.Controls.Add(this.textBoxPlaceQuantity);
            this.groupBoxRestaurant.Controls.Add(this.labelPlaceQuantity);
            this.groupBoxRestaurant.Controls.Add(this.labelFoodType);
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
            // comboBoxDayOfClosing
            // 
            this.comboBoxDayOfClosing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDayOfClosing.Enabled = false;
            this.comboBoxDayOfClosing.FormattingEnabled = true;
            this.comboBoxDayOfClosing.Location = new System.Drawing.Point(239, 63);
            this.comboBoxDayOfClosing.Name = "comboBoxDayOfClosing";
            this.comboBoxDayOfClosing.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDayOfClosing.TabIndex = 31;
            // 
            // comboBoxFoodType
            // 
            this.comboBoxFoodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFoodType.Enabled = false;
            this.comboBoxFoodType.FormattingEnabled = true;
            this.comboBoxFoodType.Location = new System.Drawing.Point(93, 39);
            this.comboBoxFoodType.Name = "comboBoxFoodType";
            this.comboBoxFoodType.Size = new System.Drawing.Size(260, 21);
            this.comboBoxFoodType.TabIndex = 30;
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
            this.groupBoxServices.Controls.Add(this.buttonRemoveService);
            this.groupBoxServices.Controls.Add(this.buttonAddService);
            this.groupBoxServices.Controls.Add(this.dataGridViewListServices);
            this.groupBoxServices.Location = new System.Drawing.Point(564, 160);
            this.groupBoxServices.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxServices.Name = "groupBoxServices";
            this.groupBoxServices.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxServices.Size = new System.Drawing.Size(799, 241);
            this.groupBoxServices.TabIndex = 20;
            this.groupBoxServices.TabStop = false;
            this.groupBoxServices.Text = "Services";
            // 
            // buttonRemoveService
            // 
            this.buttonRemoveService.Location = new System.Drawing.Point(166, 212);
            this.buttonRemoveService.Name = "buttonRemoveService";
            this.buttonRemoveService.Size = new System.Drawing.Size(135, 23);
            this.buttonRemoveService.TabIndex = 31;
            this.buttonRemoveService.Text = "Remove a service";
            this.buttonRemoveService.UseVisualStyleBackColor = true;
            // 
            // buttonAddService
            // 
            this.buttonAddService.Location = new System.Drawing.Point(16, 212);
            this.buttonAddService.Name = "buttonAddService";
            this.buttonAddService.Size = new System.Drawing.Size(135, 23);
            this.buttonAddService.TabIndex = 30;
            this.buttonAddService.Text = "Add a service";
            this.buttonAddService.UseVisualStyleBackColor = true;
            // 
            // dataGridViewListServices
            // 
            this.dataGridViewListServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListServices.Location = new System.Drawing.Point(4, 17);
            this.dataGridViewListServices.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewListServices.Name = "dataGridViewListServices";
            this.dataGridViewListServices.RowHeadersVisible = false;
            this.dataGridViewListServices.RowTemplate.Height = 24;
            this.dataGridViewListServices.Size = new System.Drawing.Size(791, 188);
            this.dataGridViewListServices.TabIndex = 23;
            // 
            // groupBoxPriceList
            // 
            this.groupBoxPriceList.Controls.Add(this.dataGridViewListPrice);
            this.groupBoxPriceList.Location = new System.Drawing.Point(12, 402);
            this.groupBoxPriceList.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxPriceList.Name = "groupBoxPriceList";
            this.groupBoxPriceList.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxPriceList.Size = new System.Drawing.Size(633, 115);
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
            this.dataGridViewListPrice.Size = new System.Drawing.Size(625, 93);
            this.dataGridViewListPrice.TabIndex = 14;
            // 
            // groupBoxAddress
            // 
            this.groupBoxAddress.Controls.Add(this.buttonCancelAddress);
            this.groupBoxAddress.Controls.Add(this.buttonDeleteAddress);
            this.groupBoxAddress.Controls.Add(this.buttonNewAddress);
            this.groupBoxAddress.Controls.Add(this.buttonAddAddress);
            this.groupBoxAddress.Controls.Add(this.comboBoxAddresses);
            this.groupBoxAddress.Controls.Add(this.checkBoxAddressIsEnabled);
            this.groupBoxAddress.Controls.Add(this.checkBoxHeadOffice);
            this.groupBoxAddress.Controls.Add(this.textBoxCity);
            this.groupBoxAddress.Controls.Add(this.labelCity);
            this.groupBoxAddress.Controls.Add(this.textBoxStreetNumber);
            this.groupBoxAddress.Controls.Add(this.labelStreetNumber);
            this.groupBoxAddress.Controls.Add(this.textBoxCountry);
            this.groupBoxAddress.Controls.Add(this.textBoxZipCode);
            this.groupBoxAddress.Controls.Add(this.textBoxStreet);
            this.groupBoxAddress.Controls.Add(this.labelCountry);
            this.groupBoxAddress.Controls.Add(this.labelZipCode);
            this.groupBoxAddress.Controls.Add(this.labelStreet);
            this.groupBoxAddress.Location = new System.Drawing.Point(649, 405);
            this.groupBoxAddress.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxAddress.Name = "groupBoxAddress";
            this.groupBoxAddress.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxAddress.Size = new System.Drawing.Size(658, 115);
            this.groupBoxAddress.TabIndex = 19;
            this.groupBoxAddress.TabStop = false;
            this.groupBoxAddress.Text = "Adress";
            // 
            // buttonCancelAddress
            // 
            this.buttonCancelAddress.Location = new System.Drawing.Point(354, 84);
            this.buttonCancelAddress.Name = "buttonCancelAddress";
            this.buttonCancelAddress.Size = new System.Drawing.Size(56, 23);
            this.buttonCancelAddress.TabIndex = 18;
            this.buttonCancelAddress.Text = "Cancel";
            this.buttonCancelAddress.UseVisualStyleBackColor = true;
            this.buttonCancelAddress.Click += new System.EventHandler(this.buttonCancelAddress_Click);
            // 
            // buttonDeleteAddress
            // 
            this.buttonDeleteAddress.BackColor = System.Drawing.Color.Crimson;
            this.buttonDeleteAddress.Location = new System.Drawing.Point(545, 84);
            this.buttonDeleteAddress.Name = "buttonDeleteAddress";
            this.buttonDeleteAddress.Size = new System.Drawing.Size(97, 23);
            this.buttonDeleteAddress.TabIndex = 17;
            this.buttonDeleteAddress.Text = "Delete Address";
            this.buttonDeleteAddress.UseVisualStyleBackColor = false;
            this.buttonDeleteAddress.Click += new System.EventHandler(this.buttonDeleteAddress_Click);
            // 
            // buttonNewAddress
            // 
            this.buttonNewAddress.Location = new System.Drawing.Point(292, 84);
            this.buttonNewAddress.Name = "buttonNewAddress";
            this.buttonNewAddress.Size = new System.Drawing.Size(56, 23);
            this.buttonNewAddress.TabIndex = 16;
            this.buttonNewAddress.Text = "New";
            this.buttonNewAddress.UseVisualStyleBackColor = true;
            this.buttonNewAddress.Click += new System.EventHandler(this.buttonNewAddress_Click);
            // 
            // buttonAddAddress
            // 
            this.buttonAddAddress.BackColor = System.Drawing.Color.Chartreuse;
            this.buttonAddAddress.Location = new System.Drawing.Point(442, 84);
            this.buttonAddAddress.Name = "buttonAddAddress";
            this.buttonAddAddress.Size = new System.Drawing.Size(97, 23);
            this.buttonAddAddress.TabIndex = 15;
            this.buttonAddAddress.Text = "Add Address";
            this.buttonAddAddress.UseVisualStyleBackColor = false;
            this.buttonAddAddress.Click += new System.EventHandler(this.buttonAddAddress_Click);
            // 
            // comboBoxAddresses
            // 
            this.comboBoxAddresses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAddresses.FormattingEnabled = true;
            this.comboBoxAddresses.Location = new System.Drawing.Point(532, 14);
            this.comboBoxAddresses.Name = "comboBoxAddresses";
            this.comboBoxAddresses.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAddresses.TabIndex = 14;
            // 
            // checkBoxAddressIsEnabled
            // 
            this.checkBoxAddressIsEnabled.AutoSize = true;
            this.checkBoxAddressIsEnabled.Location = new System.Drawing.Point(125, 88);
            this.checkBoxAddressIsEnabled.Name = "checkBoxAddressIsEnabled";
            this.checkBoxAddressIsEnabled.Size = new System.Drawing.Size(65, 17);
            this.checkBoxAddressIsEnabled.TabIndex = 13;
            this.checkBoxAddressIsEnabled.Text = "Enabled";
            this.checkBoxAddressIsEnabled.UseVisualStyleBackColor = true;
            // 
            // checkBoxHeadOffice
            // 
            this.checkBoxHeadOffice.AutoSize = true;
            this.checkBoxHeadOffice.Location = new System.Drawing.Point(9, 88);
            this.checkBoxHeadOffice.Name = "checkBoxHeadOffice";
            this.checkBoxHeadOffice.Size = new System.Drawing.Size(81, 17);
            this.checkBoxHeadOffice.TabIndex = 12;
            this.checkBoxHeadOffice.Text = "Head office";
            this.checkBoxHeadOffice.UseVisualStyleBackColor = true;
            // 
            // textBoxCity
            // 
            this.textBoxCity.Location = new System.Drawing.Point(175, 39);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(260, 20);
            this.textBoxCity.TabIndex = 11;
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(145, 42);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(24, 13);
            this.labelCity.TabIndex = 10;
            this.labelCity.Text = "City";
            // 
            // textBoxStreetNumber
            // 
            this.textBoxStreetNumber.Location = new System.Drawing.Point(354, 16);
            this.textBoxStreetNumber.Name = "textBoxStreetNumber";
            this.textBoxStreetNumber.Size = new System.Drawing.Size(81, 20);
            this.textBoxStreetNumber.TabIndex = 9;
            // 
            // labelStreetNumber
            // 
            this.labelStreetNumber.AutoSize = true;
            this.labelStreetNumber.Location = new System.Drawing.Point(304, 19);
            this.labelStreetNumber.Name = "labelStreetNumber";
            this.labelStreetNumber.Size = new System.Drawing.Size(44, 13);
            this.labelStreetNumber.TabIndex = 8;
            this.labelStreetNumber.Text = "Number";
            // 
            // textBoxCountry
            // 
            this.textBoxCountry.Location = new System.Drawing.Point(76, 62);
            this.textBoxCountry.Name = "textBoxCountry";
            this.textBoxCountry.Size = new System.Drawing.Size(210, 20);
            this.textBoxCountry.TabIndex = 6;
            // 
            // textBoxZipCode
            // 
            this.textBoxZipCode.Location = new System.Drawing.Point(76, 39);
            this.textBoxZipCode.Name = "textBoxZipCode";
            this.textBoxZipCode.Size = new System.Drawing.Size(63, 20);
            this.textBoxZipCode.TabIndex = 5;
            // 
            // textBoxStreet
            // 
            this.textBoxStreet.Location = new System.Drawing.Point(76, 16);
            this.textBoxStreet.Name = "textBoxStreet";
            this.textBoxStreet.Size = new System.Drawing.Size(210, 20);
            this.textBoxStreet.TabIndex = 4;
            // 
            // labelCountry
            // 
            this.labelCountry.AutoSize = true;
            this.labelCountry.Location = new System.Drawing.Point(6, 65);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(43, 13);
            this.labelCountry.TabIndex = 2;
            this.labelCountry.Text = "Country";
            // 
            // labelZipCode
            // 
            this.labelZipCode.AutoSize = true;
            this.labelZipCode.Location = new System.Drawing.Point(6, 42);
            this.labelZipCode.Name = "labelZipCode";
            this.labelZipCode.Size = new System.Drawing.Size(46, 13);
            this.labelZipCode.TabIndex = 1;
            this.labelZipCode.Text = "Zipcode";
            // 
            // labelStreet
            // 
            this.labelStreet.AutoSize = true;
            this.labelStreet.Location = new System.Drawing.Point(6, 19);
            this.labelStreet.Name = "labelStreet";
            this.labelStreet.Size = new System.Drawing.Size(35, 13);
            this.labelStreet.TabIndex = 0;
            this.labelStreet.Text = "Street";
            // 
            // comboBoxRestaurants
            // 
            this.comboBoxRestaurants.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRestaurants.FormattingEnabled = true;
            this.comboBoxRestaurants.Location = new System.Drawing.Point(16, 36);
            this.comboBoxRestaurants.Name = "comboBoxRestaurants";
            this.comboBoxRestaurants.Size = new System.Drawing.Size(255, 21);
            this.comboBoxRestaurants.TabIndex = 24;
            this.comboBoxRestaurants.SelectedIndexChanged += new System.EventHandler(this.comboBoxRestaurants_SelectedIndexChanged);
            // 
            // buttonAddRestaurant
            // 
            this.buttonAddRestaurant.BackColor = System.Drawing.Color.Chartreuse;
            this.buttonAddRestaurant.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonAddRestaurant.Location = new System.Drawing.Point(20, 538);
            this.buttonAddRestaurant.Name = "buttonAddRestaurant";
            this.buttonAddRestaurant.Size = new System.Drawing.Size(118, 23);
            this.buttonAddRestaurant.TabIndex = 25;
            this.buttonAddRestaurant.Text = "Add Restaurant";
            this.buttonAddRestaurant.UseVisualStyleBackColor = false;
            this.buttonAddRestaurant.Click += new System.EventHandler(this.buttonAddRestaurant_Click);
            // 
            // buttonModifyRestaurant
            // 
            this.buttonModifyRestaurant.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonModifyRestaurant.Location = new System.Drawing.Point(197, 538);
            this.buttonModifyRestaurant.Name = "buttonModifyRestaurant";
            this.buttonModifyRestaurant.Size = new System.Drawing.Size(118, 23);
            this.buttonModifyRestaurant.TabIndex = 26;
            this.buttonModifyRestaurant.Text = "Modify Restaurant";
            this.buttonModifyRestaurant.UseVisualStyleBackColor = false;
            this.buttonModifyRestaurant.Click += new System.EventHandler(this.buttonModifyRestaurant_Click);
            // 
            // buttonDeleteRestaurant
            // 
            this.buttonDeleteRestaurant.BackColor = System.Drawing.Color.Crimson;
            this.buttonDeleteRestaurant.Location = new System.Drawing.Point(375, 538);
            this.buttonDeleteRestaurant.Name = "buttonDeleteRestaurant";
            this.buttonDeleteRestaurant.Size = new System.Drawing.Size(118, 23);
            this.buttonDeleteRestaurant.TabIndex = 27;
            this.buttonDeleteRestaurant.Text = "Delete Restaurant";
            this.buttonDeleteRestaurant.UseVisualStyleBackColor = false;
            this.buttonDeleteRestaurant.Click += new System.EventHandler(this.buttonDeleteRestaurant_Click);
            // 
            // buttonNewRestaurant
            // 
            this.buttonNewRestaurant.Location = new System.Drawing.Point(20, 119);
            this.buttonNewRestaurant.Name = "buttonNewRestaurant";
            this.buttonNewRestaurant.Size = new System.Drawing.Size(118, 23);
            this.buttonNewRestaurant.TabIndex = 28;
            this.buttonNewRestaurant.Text = "New Restaurant";
            this.buttonNewRestaurant.UseVisualStyleBackColor = true;
            this.buttonNewRestaurant.Click += new System.EventHandler(this.buttonNewRestaurant_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(166, 119);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(118, 23);
            this.buttonCancel.TabIndex = 29;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // RestaurantsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonNewRestaurant);
            this.Controls.Add(this.buttonDeleteRestaurant);
            this.Controls.Add(this.buttonModifyRestaurant);
            this.Controls.Add(this.buttonAddRestaurant);
            this.Controls.Add(this.comboBoxRestaurants);
            this.Controls.Add(this.groupBoxAddress);
            this.Controls.Add(this.groupBoxPriceList);
            this.Controls.Add(this.groupBoxServices);
            this.Controls.Add(this.groupBoxOwner);
            this.Controls.Add(this.groupBoxRestaurant);
            this.Controls.Add(this.labelRestaurantsList);
            this.Name = "RestaurantsView";
            this.Size = new System.Drawing.Size(1365, 587);
            this.groupBoxRestaurant.ResumeLayout(false);
            this.groupBoxRestaurant.PerformLayout();
            this.groupBoxOwner.ResumeLayout(false);
            this.groupBoxOwner.PerformLayout();
            this.groupBoxServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListServices)).EndInit();
            this.groupBoxPriceList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListPrice)).EndInit();
            this.groupBoxAddress.ResumeLayout(false);
            this.groupBoxAddress.PerformLayout();
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
        private System.Windows.Forms.Label labelDayOfClosing;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxPlaceQuantity;
        private System.Windows.Forms.Label labelPlaceQuantity;
        private System.Windows.Forms.Label labelFoodType;
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
        private System.Windows.Forms.GroupBox groupBoxAddress;
        private System.Windows.Forms.DataGridView dataGridViewListServices;
        private System.Windows.Forms.ComboBox comboBoxRestaurants;
        private System.Windows.Forms.Button buttonAddRestaurant;
        private System.Windows.Forms.Button buttonModifyRestaurant;
        private System.Windows.Forms.Button buttonDeleteRestaurant;
        private System.Windows.Forms.Button buttonNewRestaurant;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxFoodType;
        private System.Windows.Forms.ComboBox comboBoxDayOfClosing;
        private System.Windows.Forms.Button buttonRemoveService;
        private System.Windows.Forms.Button buttonAddService;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.TextBox textBoxStreetNumber;
        private System.Windows.Forms.Label labelStreetNumber;
        private System.Windows.Forms.TextBox textBoxCountry;
        private System.Windows.Forms.TextBox textBoxZipCode;
        private System.Windows.Forms.TextBox textBoxStreet;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.Label labelZipCode;
        private System.Windows.Forms.Label labelStreet;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.Button buttonAddAddress;
        private System.Windows.Forms.ComboBox comboBoxAddresses;
        private System.Windows.Forms.CheckBox checkBoxAddressIsEnabled;
        private System.Windows.Forms.CheckBox checkBoxHeadOffice;
        private System.Windows.Forms.Button buttonNewAddress;
        private System.Windows.Forms.Button buttonDeleteAddress;
        private System.Windows.Forms.Button buttonCancelAddress;

    }
}
