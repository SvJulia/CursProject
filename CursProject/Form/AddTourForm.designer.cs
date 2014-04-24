namespace CursProject.Form
{
    partial class AddTourForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labelNameForClients = new System.Windows.Forms.Label();
            this.txtNameForClients = new System.Windows.Forms.TextBox();
            this.labelCityId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlCities = new System.Windows.Forms.ComboBox();
            this.ddlCountries = new System.Windows.Forms.ComboBox();
            this.lbExcursions = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(265, 358);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(184, 358);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(83, 11);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(63, 13);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "Название: ";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(152, 8);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(188, 20);
            this.txtName.TabIndex = 0;
            // 
            // labelNameForClients
            // 
            this.labelNameForClients.AutoSize = true;
            this.labelNameForClients.Location = new System.Drawing.Point(12, 37);
            this.labelNameForClients.Name = "labelNameForClients";
            this.labelNameForClients.Size = new System.Drawing.Size(134, 13);
            this.labelNameForClients.TabIndex = 6;
            this.labelNameForClients.Text = "Название для клиентов: ";
            // 
            // txtNameForClients
            // 
            this.txtNameForClients.Location = new System.Drawing.Point(152, 34);
            this.txtNameForClients.MaxLength = 255;
            this.txtNameForClients.Name = "txtNameForClients";
            this.txtNameForClients.Size = new System.Drawing.Size(188, 20);
            this.txtNameForClients.TabIndex = 1;
            // 
            // labelCityId
            // 
            this.labelCityId.AutoSize = true;
            this.labelCityId.Location = new System.Drawing.Point(103, 90);
            this.labelCityId.Name = "labelCityId";
            this.labelCityId.Size = new System.Drawing.Size(43, 13);
            this.labelCityId.TabIndex = 6;
            this.labelCityId.Text = "Город: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Страна: ";
            // 
            // ddlCities
            // 
            this.ddlCities.FormattingEnabled = true;
            this.ddlCities.Location = new System.Drawing.Point(152, 87);
            this.ddlCities.Name = "ddlCities";
            this.ddlCities.Size = new System.Drawing.Size(188, 21);
            this.ddlCities.TabIndex = 10;
            // 
            // ddlCountries
            // 
            this.ddlCountries.FormattingEnabled = true;
            this.ddlCountries.Location = new System.Drawing.Point(152, 60);
            this.ddlCountries.Name = "ddlCountries";
            this.ddlCountries.Size = new System.Drawing.Size(188, 21);
            this.ddlCountries.TabIndex = 11;
            this.ddlCountries.TextChanged += new System.EventHandler(this.ddlCountries_TextChanged);
            // 
            // lbExcursions
            // 
            this.lbExcursions.FormattingEnabled = true;
            this.lbExcursions.Location = new System.Drawing.Point(152, 114);
            this.lbExcursions.Name = "lbExcursions";
            this.lbExcursions.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbExcursions.Size = new System.Drawing.Size(188, 238);
            this.lbExcursions.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Экскурсии: ";
            // 
            // AddTourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 388);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbExcursions);
            this.Controls.Add(this.ddlCountries);
            this.Controls.Add(this.ddlCities);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.txtNameForClients);
            this.Controls.Add(this.labelNameForClients);
            this.Controls.Add(this.labelCityId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddTourForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "тур";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
	
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox txtNameForClients;
        private System.Windows.Forms.Label labelNameForClients;
        private System.Windows.Forms.Label labelCityId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlCities;
        private System.Windows.Forms.ComboBox ddlCountries;
        private System.Windows.Forms.ListBox lbExcursions;
        private System.Windows.Forms.Label label2;

    }
}
