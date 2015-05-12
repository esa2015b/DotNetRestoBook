namespace RestoBook.GUI.View.Views
{
    partial class ReservationView
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
            this.comboBoxRestaurant = new System.Windows.Forms.ComboBox();
            this.comboBoxService = new System.Windows.Forms.ComboBox();
            this.dataGridViewReservation = new System.Windows.Forms.DataGridView();
            this.Reservations = new System.Windows.Forms.GroupBox();
            this.labelRestaurants = new System.Windows.Forms.Label();
            this.labelServices = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.groupBoxCustomer = new System.Windows.Forms.GroupBox();
            this.textBoxSearchCustomer = new System.Windows.Forms.TextBox();
            this.buttonSearchCustomer = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBoxNewReservation = new System.Windows.Forms.GroupBox();
            this.buttonAddNewReservation = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.labelComment = new System.Windows.Forms.Label();
            this.textBoxPlaceQuantity = new System.Windows.Forms.TextBox();
            this.labelPlaceQuantity = new System.Windows.Forms.Label();
            this.textBoxService = new System.Windows.Forms.TextBox();
            this.labelService = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.labelReservationDate = new System.Windows.Forms.Label();
            this.textBoxCustomerId = new System.Windows.Forms.TextBox();
            this.labelCustomerId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservation)).BeginInit();
            this.Reservations.SuspendLayout();
            this.groupBoxCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxNewReservation.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxRestaurant
            // 
            this.comboBoxRestaurant.FormattingEnabled = true;
            this.comboBoxRestaurant.Location = new System.Drawing.Point(15, 42);
            this.comboBoxRestaurant.Name = "comboBoxRestaurant";
            this.comboBoxRestaurant.Size = new System.Drawing.Size(277, 24);
            this.comboBoxRestaurant.TabIndex = 0;
            this.comboBoxRestaurant.SelectedIndexChanged += new System.EventHandler(this.comboBoxRestaurant_SelectedIndexChanged);
            // 
            // comboBoxService
            // 
            this.comboBoxService.FormattingEnabled = true;
            this.comboBoxService.Location = new System.Drawing.Point(326, 42);
            this.comboBoxService.Name = "comboBoxService";
            this.comboBoxService.Size = new System.Drawing.Size(261, 24);
            this.comboBoxService.TabIndex = 1;
            this.comboBoxService.SelectedIndexChanged += new System.EventHandler(this.comboBoxService_SelectedIndexChanged);
            // 
            // dataGridViewReservation
            // 
            this.dataGridViewReservation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReservation.Location = new System.Drawing.Point(6, 32);
            this.dataGridViewReservation.Name = "dataGridViewReservation";
            this.dataGridViewReservation.RowTemplate.Height = 24;
            this.dataGridViewReservation.Size = new System.Drawing.Size(1081, 291);
            this.dataGridViewReservation.TabIndex = 2;
            this.dataGridViewReservation.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewReservation_CellContentClick);
            // 
            // Reservations
            // 
            this.Reservations.Controls.Add(this.groupBoxNewReservation);
            this.Reservations.Controls.Add(this.buttonDelete);
            this.Reservations.Controls.Add(this.buttonSave);
            this.Reservations.Controls.Add(this.dataGridViewReservation);
            this.Reservations.Location = new System.Drawing.Point(15, 77);
            this.Reservations.Name = "Reservations";
            this.Reservations.Size = new System.Drawing.Size(1093, 587);
            this.Reservations.TabIndex = 7;
            this.Reservations.TabStop = false;
            this.Reservations.Text = "Reservations";
            // 
            // labelRestaurants
            // 
            this.labelRestaurants.AutoSize = true;
            this.labelRestaurants.Location = new System.Drawing.Point(15, 19);
            this.labelRestaurants.Name = "labelRestaurants";
            this.labelRestaurants.Size = new System.Drawing.Size(85, 17);
            this.labelRestaurants.TabIndex = 8;
            this.labelRestaurants.Text = "Restaurants";
            // 
            // labelServices
            // 
            this.labelServices.AutoSize = true;
            this.labelServices.Location = new System.Drawing.Point(326, 19);
            this.labelServices.Name = "labelServices";
            this.labelServices.Size = new System.Drawing.Size(62, 17);
            this.labelServices.TabIndex = 9;
            this.labelServices.Text = "Services";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(842, 335);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(245, 23);
            this.buttonSave.TabIndex = 14;
            this.buttonSave.Text = "Save Changes";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(842, 365);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(245, 23);
            this.buttonDelete.TabIndex = 15;
            this.buttonDelete.Text = "Delete Row";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // groupBoxCustomer
            // 
            this.groupBoxCustomer.Controls.Add(this.dataGridView1);
            this.groupBoxCustomer.Controls.Add(this.buttonSearchCustomer);
            this.groupBoxCustomer.Controls.Add(this.textBoxSearchCustomer);
            this.groupBoxCustomer.Location = new System.Drawing.Point(1115, 77);
            this.groupBoxCustomer.Name = "groupBoxCustomer";
            this.groupBoxCustomer.Size = new System.Drawing.Size(469, 449);
            this.groupBoxCustomer.TabIndex = 10;
            this.groupBoxCustomer.TabStop = false;
            this.groupBoxCustomer.Text = "Customers";
            // 
            // textBoxSearchCustomer
            // 
            this.textBoxSearchCustomer.Location = new System.Drawing.Point(7, 32);
            this.textBoxSearchCustomer.Name = "textBoxSearchCustomer";
            this.textBoxSearchCustomer.Size = new System.Drawing.Size(320, 22);
            this.textBoxSearchCustomer.TabIndex = 0;
            // 
            // buttonSearchCustomer
            // 
            this.buttonSearchCustomer.Location = new System.Drawing.Point(333, 31);
            this.buttonSearchCustomer.Name = "buttonSearchCustomer";
            this.buttonSearchCustomer.Size = new System.Drawing.Size(130, 23);
            this.buttonSearchCustomer.TabIndex = 1;
            this.buttonSearchCustomer.Text = "Search";
            this.buttonSearchCustomer.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(456, 374);
            this.dataGridView1.TabIndex = 2;
            // 
            // groupBoxNewReservation
            // 
            this.groupBoxNewReservation.Controls.Add(this.buttonAddNewReservation);
            this.groupBoxNewReservation.Controls.Add(this.richTextBox1);
            this.groupBoxNewReservation.Controls.Add(this.labelComment);
            this.groupBoxNewReservation.Controls.Add(this.textBoxPlaceQuantity);
            this.groupBoxNewReservation.Controls.Add(this.labelPlaceQuantity);
            this.groupBoxNewReservation.Controls.Add(this.textBoxService);
            this.groupBoxNewReservation.Controls.Add(this.labelService);
            this.groupBoxNewReservation.Controls.Add(this.monthCalendar1);
            this.groupBoxNewReservation.Controls.Add(this.labelReservationDate);
            this.groupBoxNewReservation.Controls.Add(this.textBoxCustomerId);
            this.groupBoxNewReservation.Controls.Add(this.labelCustomerId);
            this.groupBoxNewReservation.Location = new System.Drawing.Point(7, 330);
            this.groupBoxNewReservation.Name = "groupBoxNewReservation";
            this.groupBoxNewReservation.Size = new System.Drawing.Size(829, 247);
            this.groupBoxNewReservation.TabIndex = 16;
            this.groupBoxNewReservation.TabStop = false;
            this.groupBoxNewReservation.Text = "New reservation";
            // 
            // buttonAddNewReservation
            // 
            this.buttonAddNewReservation.Location = new System.Drawing.Point(6, 210);
            this.buttonAddNewReservation.Name = "buttonAddNewReservation";
            this.buttonAddNewReservation.Size = new System.Drawing.Size(491, 23);
            this.buttonAddNewReservation.TabIndex = 24;
            this.buttonAddNewReservation.Text = "Add New Reservation";
            this.buttonAddNewReservation.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(129, 115);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(367, 89);
            this.richTextBox1.TabIndex = 23;
            this.richTextBox1.Text = "";
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Location = new System.Drawing.Point(5, 118);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(67, 17);
            this.labelComment.TabIndex = 22;
            this.labelComment.Text = "Comment";
            // 
            // textBoxPlaceQuantity
            // 
            this.textBoxPlaceQuantity.Location = new System.Drawing.Point(129, 87);
            this.textBoxPlaceQuantity.Name = "textBoxPlaceQuantity";
            this.textBoxPlaceQuantity.Size = new System.Drawing.Size(100, 22);
            this.textBoxPlaceQuantity.TabIndex = 21;
            // 
            // labelPlaceQuantity
            // 
            this.labelPlaceQuantity.AutoSize = true;
            this.labelPlaceQuantity.Location = new System.Drawing.Point(5, 90);
            this.labelPlaceQuantity.Name = "labelPlaceQuantity";
            this.labelPlaceQuantity.Size = new System.Drawing.Size(100, 17);
            this.labelPlaceQuantity.TabIndex = 20;
            this.labelPlaceQuantity.Text = "Place Quantity";
            // 
            // textBoxService
            // 
            this.textBoxService.Location = new System.Drawing.Point(129, 59);
            this.textBoxService.Name = "textBoxService";
            this.textBoxService.Size = new System.Drawing.Size(100, 22);
            this.textBoxService.TabIndex = 19;
            // 
            // labelService
            // 
            this.labelService.AutoSize = true;
            this.labelService.Location = new System.Drawing.Point(5, 62);
            this.labelService.Name = "labelService";
            this.labelService.Size = new System.Drawing.Size(59, 17);
            this.labelService.TabIndex = 18;
            this.labelService.Text = "Service ";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(508, 35);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 17;
            // 
            // labelReservationDate
            // 
            this.labelReservationDate.AutoSize = true;
            this.labelReservationDate.Location = new System.Drawing.Point(378, 32);
            this.labelReservationDate.Name = "labelReservationDate";
            this.labelReservationDate.Size = new System.Drawing.Size(118, 17);
            this.labelReservationDate.TabIndex = 16;
            this.labelReservationDate.Text = "Reservation Date";
            // 
            // textBoxCustomerId
            // 
            this.textBoxCustomerId.Location = new System.Drawing.Point(129, 29);
            this.textBoxCustomerId.Name = "textBoxCustomerId";
            this.textBoxCustomerId.Size = new System.Drawing.Size(102, 22);
            this.textBoxCustomerId.TabIndex = 15;
            // 
            // labelCustomerId
            // 
            this.labelCustomerId.AutoSize = true;
            this.labelCustomerId.Location = new System.Drawing.Point(5, 32);
            this.labelCustomerId.Name = "labelCustomerId";
            this.labelCustomerId.Size = new System.Drawing.Size(85, 17);
            this.labelCustomerId.TabIndex = 14;
            this.labelCustomerId.Text = "Customer ID";
            // 
            // ReservationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxCustomer);
            this.Controls.Add(this.labelServices);
            this.Controls.Add(this.labelRestaurants);
            this.Controls.Add(this.Reservations);
            this.Controls.Add(this.comboBoxService);
            this.Controls.Add(this.comboBoxRestaurant);
            this.Name = "ReservationView";
            this.Size = new System.Drawing.Size(1601, 713);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservation)).EndInit();
            this.Reservations.ResumeLayout(false);
            this.groupBoxCustomer.ResumeLayout(false);
            this.groupBoxCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxNewReservation.ResumeLayout(false);
            this.groupBoxNewReservation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxRestaurant;
        private System.Windows.Forms.ComboBox comboBoxService;
        private System.Windows.Forms.DataGridView dataGridViewReservation;
        private System.Windows.Forms.GroupBox Reservations;
        private System.Windows.Forms.Label labelRestaurants;
        private System.Windows.Forms.Label labelServices;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBoxCustomer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSearchCustomer;
        private System.Windows.Forms.TextBox textBoxSearchCustomer;
        private System.Windows.Forms.GroupBox groupBoxNewReservation;
        private System.Windows.Forms.Button buttonAddNewReservation;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.TextBox textBoxPlaceQuantity;
        private System.Windows.Forms.Label labelPlaceQuantity;
        private System.Windows.Forms.TextBox textBoxService;
        private System.Windows.Forms.Label labelService;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label labelReservationDate;
        private System.Windows.Forms.TextBox textBoxCustomerId;
        private System.Windows.Forms.Label labelCustomerId;
    }
}
