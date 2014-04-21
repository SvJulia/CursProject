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
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(264, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(183, 112);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
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
            this.txtName.TabIndex = 1;
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
            this.txtNameForClients.TabIndex = 2;
            // 
            // labelCityId
            // 
            this.labelCityId.AutoSize = true;
            this.labelCityId.Location = new System.Drawing.Point(102, 63);
            this.labelCityId.Name = "labelCityId";
            this.labelCityId.Size = new System.Drawing.Size(43, 13);
            this.labelCityId.TabIndex = 6;
            this.labelCityId.Text = "Город: ";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(151, 60);
            this.txtCity.MaxLength = 255;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(188, 20);
            this.txtCity.TabIndex = 3;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(151, 86);
            this.txtCountry.MaxLength = 255;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(188, 20);
            this.txtCountry.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Страна: ";
            // 
            // AddTourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 147);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.txtNameForClients);
            this.Controls.Add(this.labelNameForClients);
            this.Controls.Add(this.txtCity);
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
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label labelCityId;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Label label1;

    }
}
