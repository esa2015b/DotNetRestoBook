namespace RestoBook.GUI.View.Views
{
    partial class FoodTypeView
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
            this.btnDeleteFoodType = new System.Windows.Forms.Button();
            this.btnModifyFoodType = new System.Windows.Forms.Button();
            this.btnAddFoodType = new System.Windows.Forms.Button();
            this.tbFoodTypeDescription = new System.Windows.Forms.TextBox();
            this.lblFoodTypeDescription = new System.Windows.Forms.Label();
            this.lblFoodTypeName = new System.Windows.Forms.Label();
            this.tbFoodTypeName = new System.Windows.Forms.TextBox();
            this.lblExistingFoodTypes = new System.Windows.Forms.Label();
            this.cbbExistingFoodTypes = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDeleteFoodType
            // 
            this.btnDeleteFoodType.Location = new System.Drawing.Point(570, 293);
            this.btnDeleteFoodType.Name = "btnDeleteFoodType";
            this.btnDeleteFoodType.Size = new System.Drawing.Size(105, 23);
            this.btnDeleteFoodType.TabIndex = 17;
            this.btnDeleteFoodType.Text = "Delete Food Type";
            this.btnDeleteFoodType.UseVisualStyleBackColor = true;
            this.btnDeleteFoodType.Click += new System.EventHandler(this.btnDeleteFoodType_Click);
            // 
            // btnModifyFoodType
            // 
            this.btnModifyFoodType.Location = new System.Drawing.Point(424, 293);
            this.btnModifyFoodType.Name = "btnModifyFoodType";
            this.btnModifyFoodType.Size = new System.Drawing.Size(105, 23);
            this.btnModifyFoodType.TabIndex = 16;
            this.btnModifyFoodType.Text = "Modify Food Type";
            this.btnModifyFoodType.UseVisualStyleBackColor = true;
            this.btnModifyFoodType.Click += new System.EventHandler(this.btnModifyFoodType_Click);
            // 
            // btnAddFoodType
            // 
            this.btnAddFoodType.Location = new System.Drawing.Point(285, 293);
            this.btnAddFoodType.Name = "btnAddFoodType";
            this.btnAddFoodType.Size = new System.Drawing.Size(108, 23);
            this.btnAddFoodType.TabIndex = 15;
            this.btnAddFoodType.Text = "Add Food Type";
            this.btnAddFoodType.UseVisualStyleBackColor = true;
            this.btnAddFoodType.Click += new System.EventHandler(this.btnAddFoodType_Click);
            // 
            // tbFoodTypeDescription
            // 
            this.tbFoodTypeDescription.Location = new System.Drawing.Point(285, 95);
            this.tbFoodTypeDescription.Multiline = true;
            this.tbFoodTypeDescription.Name = "tbFoodTypeDescription";
            this.tbFoodTypeDescription.Size = new System.Drawing.Size(431, 169);
            this.tbFoodTypeDescription.TabIndex = 14;
            // 
            // lblFoodTypeDescription
            // 
            this.lblFoodTypeDescription.AutoSize = true;
            this.lblFoodTypeDescription.Location = new System.Drawing.Point(285, 78);
            this.lblFoodTypeDescription.Name = "lblFoodTypeDescription";
            this.lblFoodTypeDescription.Size = new System.Drawing.Size(114, 13);
            this.lblFoodTypeDescription.TabIndex = 13;
            this.lblFoodTypeDescription.Text = "Food Type Description";
            // 
            // lblFoodTypeName
            // 
            this.lblFoodTypeName.AutoSize = true;
            this.lblFoodTypeName.Location = new System.Drawing.Point(285, 25);
            this.lblFoodTypeName.Name = "lblFoodTypeName";
            this.lblFoodTypeName.Size = new System.Drawing.Size(89, 13);
            this.lblFoodTypeName.TabIndex = 12;
            this.lblFoodTypeName.Text = "Food Type Name";
            // 
            // tbFoodTypeName
            // 
            this.tbFoodTypeName.Location = new System.Drawing.Point(285, 42);
            this.tbFoodTypeName.Name = "tbFoodTypeName";
            this.tbFoodTypeName.Size = new System.Drawing.Size(227, 20);
            this.tbFoodTypeName.TabIndex = 11;
            // 
            // lblExistingFoodTypes
            // 
            this.lblExistingFoodTypes.AutoSize = true;
            this.lblExistingFoodTypes.Location = new System.Drawing.Point(31, 25);
            this.lblExistingFoodTypes.Name = "lblExistingFoodTypes";
            this.lblExistingFoodTypes.Size = new System.Drawing.Size(102, 13);
            this.lblExistingFoodTypes.TabIndex = 10;
            this.lblExistingFoodTypes.Text = "Existing Food Types";
            // 
            // cbbExistingFoodTypes
            // 
            this.cbbExistingFoodTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbExistingFoodTypes.FormattingEnabled = true;
            this.cbbExistingFoodTypes.Location = new System.Drawing.Point(34, 41);
            this.cbbExistingFoodTypes.Name = "cbbExistingFoodTypes";
            this.cbbExistingFoodTypes.Size = new System.Drawing.Size(149, 21);
            this.cbbExistingFoodTypes.TabIndex = 9;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(553, 39);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(76, 23);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(654, 39);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FoodTypeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDeleteFoodType);
            this.Controls.Add(this.btnModifyFoodType);
            this.Controls.Add(this.btnAddFoodType);
            this.Controls.Add(this.tbFoodTypeDescription);
            this.Controls.Add(this.lblFoodTypeDescription);
            this.Controls.Add(this.lblFoodTypeName);
            this.Controls.Add(this.tbFoodTypeName);
            this.Controls.Add(this.lblExistingFoodTypes);
            this.Controls.Add(this.cbbExistingFoodTypes);
            this.Name = "FoodTypeView";
            this.Size = new System.Drawing.Size(747, 340);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteFoodType;
        private System.Windows.Forms.Button btnModifyFoodType;
        private System.Windows.Forms.Button btnAddFoodType;
        private System.Windows.Forms.TextBox tbFoodTypeDescription;
        private System.Windows.Forms.Label lblFoodTypeDescription;
        private System.Windows.Forms.Label lblFoodTypeName;
        private System.Windows.Forms.TextBox tbFoodTypeName;
        private System.Windows.Forms.Label lblExistingFoodTypes;
        private System.Windows.Forms.ComboBox cbbExistingFoodTypes;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCancel;
    }
}
