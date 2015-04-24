namespace RestoBook.GUI.View.Views
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewListServices = new System.Windows.Forms.DataGridView();
            this.tabPageReservations = new System.Windows.Forms.TabPage();
            this.tabPageRestaurants = new System.Windows.Forms.TabPage();
            this.tabPageFoodType = new System.Windows.Forms.TabPage();
            this.tcRestoBook = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListServices)).BeginInit();
            this.tcRestoBook.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewListServices
            // 
            this.dataGridViewListServices.Location = new System.Drawing.Point(6, 21);
            this.dataGridViewListServices.Name = "dataGridViewListServices";
            this.dataGridViewListServices.RowHeadersVisible = false;
            this.dataGridViewListServices.RowTemplate.Height = 24;
            this.dataGridViewListServices.Size = new System.Drawing.Size(761, 275);
            this.dataGridViewListServices.TabIndex = 0;
            // 
            // tabPageReservations
            // 
            this.tabPageReservations.Location = new System.Drawing.Point(4, 22);
            this.tabPageReservations.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageReservations.Name = "tabPageReservations";
            this.tabPageReservations.Size = new System.Drawing.Size(1322, 709);
            this.tabPageReservations.TabIndex = 2;
            this.tabPageReservations.Text = "Reservations";
            this.tabPageReservations.UseVisualStyleBackColor = true;
            // 
            // tabPageRestaurants
            // 
            this.tabPageRestaurants.Location = new System.Drawing.Point(4, 22);
            this.tabPageRestaurants.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageRestaurants.Name = "tabPageRestaurants";
            this.tabPageRestaurants.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageRestaurants.Size = new System.Drawing.Size(1322, 709);
            this.tabPageRestaurants.TabIndex = 1;
            this.tabPageRestaurants.Text = "Restaurants";
            this.tabPageRestaurants.UseVisualStyleBackColor = true;
            // 
            // tabPageFoodType
            // 
            this.tabPageFoodType.Location = new System.Drawing.Point(4, 22);
            this.tabPageFoodType.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageFoodType.Name = "tabPageFoodType";
            this.tabPageFoodType.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageFoodType.Size = new System.Drawing.Size(1452, 709);
            this.tabPageFoodType.TabIndex = 0;
            this.tabPageFoodType.Text = "Food type";
            this.tabPageFoodType.UseVisualStyleBackColor = true;
            // 
            // tcRestoBook
            // 
            this.tcRestoBook.Controls.Add(this.tabPageFoodType);
            this.tcRestoBook.Controls.Add(this.tabPageRestaurants);
            this.tcRestoBook.Controls.Add(this.tabPageReservations);
            this.tcRestoBook.Location = new System.Drawing.Point(10, 11);
            this.tcRestoBook.Margin = new System.Windows.Forms.Padding(2);
            this.tcRestoBook.Name = "tcRestoBook";
            this.tcRestoBook.SelectedIndex = 0;
            this.tcRestoBook.Size = new System.Drawing.Size(1460, 735);
            this.tcRestoBook.TabIndex = 0;
            this.tcRestoBook.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControlOneRestaurantOwnerFirstName_Selecting);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 757);
            this.Controls.Add(this.tcRestoBook);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "RestoBook - administration - main menu";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListServices)).EndInit();
            this.tcRestoBook.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewListServices;
        private System.Windows.Forms.TabPage tabPageReservations;
        private System.Windows.Forms.TabPage tabPageRestaurants;
        private System.Windows.Forms.TabPage tabPageFoodType;
        private System.Windows.Forms.TabControl tcRestoBook;
    }
}

