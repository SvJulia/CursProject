namespace CursProject.Form
{
    partial class AddClientForm
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
            this.labelFio = new System.Windows.Forms.Label();
            this.txtFio = new System.Windows.Forms.TextBox();
            this.labelDocType = new System.Windows.Forms.Label();
            this.txtDocType = new System.Windows.Forms.TextBox();
            this.labelDocData = new System.Windows.Forms.Label();
            this.txtDocData = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(238, 116);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "������";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(157, 116);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "��������";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelFio
            // 
            this.labelFio.AutoSize = true;
            this.labelFio.Location = new System.Drawing.Point(79, 15);
            this.labelFio.Name = "labelFio";
            this.labelFio.Size = new System.Drawing.Size(40, 13);
            this.labelFio.TabIndex = 6;
            this.labelFio.Text = "���: ";
            // 
            // txtFio
            // 
            this.txtFio.Location = new System.Drawing.Point(125, 12);
            this.txtFio.MaxLength = 255;
            this.txtFio.Name = "txtFio";
            this.txtFio.Size = new System.Drawing.Size(188, 20);
            this.txtFio.TabIndex = 2;
            // 
            // labelDocType
            // 
            this.labelDocType.AutoSize = true;
            this.labelDocType.Location = new System.Drawing.Point(30, 41);
            this.labelDocType.Name = "labelDocType";
            this.labelDocType.Size = new System.Drawing.Size(89, 13);
            this.labelDocType.TabIndex = 6;
            this.labelDocType.Text = "��� ���������: ";
            // 
            // txtDocType
            // 
            this.txtDocType.Location = new System.Drawing.Point(125, 38);
            this.txtDocType.MaxLength = 255;
            this.txtDocType.Name = "txtDocType";
            this.txtDocType.Size = new System.Drawing.Size(188, 20);
            this.txtDocType.TabIndex = 3;
            // 
            // labelDocData
            // 
            this.labelDocData.AutoSize = true;
            this.labelDocData.Location = new System.Drawing.Point(8, 67);
            this.labelDocData.Name = "labelDocData";
            this.labelDocData.Size = new System.Drawing.Size(111, 13);
            this.labelDocData.TabIndex = 6;
            this.labelDocData.Text = "������ ���������: ";
            // 
            // txtDocData
            // 
            this.txtDocData.Location = new System.Drawing.Point(125, 64);
            this.txtDocData.MaxLength = 255;
            this.txtDocData.Name = "txtDocData";
            this.txtDocData.Size = new System.Drawing.Size(188, 20);
            this.txtDocData.TabIndex = 4;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(78, 93);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(41, 13);
            this.labelEmail.TabIndex = 6;
            this.labelEmail.Text = "E-mail: ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(125, 90);
            this.txtEmail.MaxLength = 255;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(188, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // AddClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 147);
            this.Controls.Add(this.txtFio);
            this.Controls.Add(this.labelFio);
            this.Controls.Add(this.txtDocType);
            this.Controls.Add(this.labelDocType);
            this.Controls.Add(this.txtDocData);
            this.Controls.Add(this.labelDocData);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "������";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtFio;
        private System.Windows.Forms.Label labelFio;
        private System.Windows.Forms.TextBox txtDocType;
        private System.Windows.Forms.Label labelDocType;
        private System.Windows.Forms.TextBox txtDocData;
        private System.Windows.Forms.Label labelDocData;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label labelEmail;

    }
}
