using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CursProject
{
    partial class ShowClient
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnEditTripClient = new System.Windows.Forms.Button();
            this.btnDeleteTripClient = new System.Windows.Forms.Button();
            this.tripClientGrid = new System.Windows.Forms.DataGridView();
            this.btnSale = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tripClientGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditTripClient
            // 
            this.btnEditTripClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditTripClient.Location = new System.Drawing.Point(623, 538);
            this.btnEditTripClient.Name = "btnEditTripClient";
            this.btnEditTripClient.Size = new System.Drawing.Size(75, 23);
            this.btnEditTripClient.TabIndex = 6;
            this.btnEditTripClient.Text = "Изменить";
            this.btnEditTripClient.UseVisualStyleBackColor = true;
            this.btnEditTripClient.Click += new System.EventHandler(this.btnEditTripClient_Click);
            // 
            // btnDeleteTripClient
            // 
            this.btnDeleteTripClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteTripClient.Location = new System.Drawing.Point(704, 538);
            this.btnDeleteTripClient.Name = "btnDeleteTripClient";
            this.btnDeleteTripClient.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteTripClient.TabIndex = 7;
            this.btnDeleteTripClient.Text = "Удалить";
            this.btnDeleteTripClient.UseVisualStyleBackColor = true;
            this.btnDeleteTripClient.Click += new System.EventHandler(this.btnDeleteTripClient_Click);
            // 
            // tripClientGrid
            // 
            this.tripClientGrid.AllowUserToAddRows = false;
            this.tripClientGrid.AllowUserToDeleteRows = false;
            this.tripClientGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tripClientGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tripClientGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tripClientGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tripClientGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tripClientGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.tripClientGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tripClientGrid.Location = new System.Drawing.Point(12, 12);
            this.tripClientGrid.Name = "tripClientGrid";
            this.tripClientGrid.ReadOnly = true;
            this.tripClientGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tripClientGrid.Size = new System.Drawing.Size(767, 520);
            this.tripClientGrid.TabIndex = 4;
            // 
            // btnSale
            // 
            this.btnSale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSale.Location = new System.Drawing.Point(542, 538);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(75, 23);
            this.btnSale.TabIndex = 11;
            this.btnSale.Text = "Оплачено";
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // ShowClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 573);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.tripClientGrid);
            this.Controls.Add(this.btnEditTripClient);
            this.Controls.Add(this.btnDeleteTripClient);
            this.Name = "ShowClient";
            this.Text = "Система учёта клиентов";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.tripClientGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private int TourSortColumn = 0;
        private SortOrder TourSortOrder = SortOrder.None;
        private string FilterTourFio = "";
        private Button btnEditTripClient;
        private Button btnDeleteTripClient;
        private DataGridView tripClientGrid;
        private Button btnSale;
    }
}

